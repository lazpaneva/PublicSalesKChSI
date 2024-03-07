using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.HtmlPdf;
using PublicSalesKChSI.Infrastructure.Data;
using PublicSalesKChSI.Infrastructure.Data.Common;
using PublicSalesKChSI.Infrastructure.Data.Models;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PublicSalesKChSI.Core.Services
{
    public class HtmlPdfService : IHtmlPdfService
    {
        private readonly IRepository repo;
        //private readonly PublicSalesDbContext dbContext;

        public HtmlPdfService(IRepository _repository)
        {
            repo = _repository;
            //dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<int[]> GetLastNumbers()
        {
            int[] lastNumsForThreeDifferentTypes = new int[3];

            var lastDownNumberAsset = await repo.AllReadOnly<LastDownNumber>()
                .FirstAsync(ident => ident.Id == 1);
            var lastDownNumberVevhicle = await repo.AllReadOnly<LastDownNumber>()
                .FirstAsync(ident => ident.Id == 2);
            var lastDownNumberProperties = await repo.AllReadOnly<LastDownNumber>()
                .FirstAsync(ident => ident.Id == 3);

            lastNumsForThreeDifferentTypes[0] = lastDownNumberAsset.LastNumber;
            lastNumsForThreeDifferentTypes[1] = lastDownNumberVevhicle.LastNumber;
            lastNumsForThreeDifferentTypes[2] = lastDownNumberProperties.LastNumber;

            //delete table TempHtmls, use like transint table. old not necessary
            var htmls = repo.All<TempHtml>();
            foreach (var html in htmls)
            {
                repo.Delete(html);
            }
            //delete directories for downloading if exists
            string filePathDirectoryHtml = DataConstantsCore.pathDownloadHtm;
            DeleteAndCreateDirectory(filePathDirectoryHtml);

            return lastNumsForThreeDifferentTypes;
        }

        [HttpPost]
        public async Task<bool> DownloadHtmlFiles(int numberBegin, int numberEnd, string type)
        {
            bool result = false;
            int sizeUrls = numberEnd - numberBegin + 1;
            string[] urls = new string[sizeUrls];
            string typeBcpeaPath = string.Empty;

            switch (type)
            {
                case "Asset":
                    typeBcpeaPath = "https://sales.bcpea.org/asset/";
                    break;
                case "Vechicle":
                    typeBcpeaPath = "https://sales.bcpea.org/vehicles/";
                    break;
                case "Property":
                    typeBcpeaPath = "https://sales.bcpea.org/properties/";
                    break;
                default:
                    break;
            }

            urls = fillUrlsArray(numberBegin, numberEnd, urls, typeBcpeaPath);
            List<TempHtml> htmlList = new List<TempHtml>();
            
            foreach (string urlAddress in urls)
            {
                string fileName = "html_"+ urlAddress.Substring(urlAddress.LastIndexOf('/')+1).Trim()
                    +".html";
                //string filePath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                //to do, ако се качи в нета
                string filePath = Path.Combine(DataConstantsCore.pathDownloadHtm, fileName);
                                
                TempHtml htmlAdd = new TempHtml();
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string htmlContent = await client.DownloadStringTaskAsync(urlAddress);
                        
                        htmlAdd = new TempHtml()
                        {
                            Type = type,
                            Content = htmlContent,
                            CreatedOn = DateTime.Now,
                            NumberInSite = int.Parse(urlAddress.Substring(urlAddress.LastIndexOf('/') + 1).Trim()),
                        };
                        string htmlAddForDb = ShrinkHtmlContent(htmlContent);
                        htmlList.Add(htmlAdd);

                        await repo.AddAsync(htmlAdd);
                        await repo.SaveChangesAsync();
                        File.WriteAllText(filePath, htmlContent);
                    }
                    catch (WebException ex)
                    {
                        Console.WriteLine($"Error downloading {urlAddress}: {ex.Message}");
                    }
                }
            }

            result = true;
            return result;
        }

        private string ShrinkHtmlContent(string htmContent)
        {
            string result = String.Empty;

            int posOfScript = htmContent.IndexOf("<script");
            while (posOfScript != -1)
            {
                int posOfEndScript = htmContent.IndexOf("</script>");
                htmContent = htmContent.Remove(posOfScript, posOfEndScript - posOfScript);
                posOfScript = htmContent.IndexOf("<script");
            }
            
            int begPos = htmContent.IndexOf(DataConstantsCore.beginPosContentInHtml);
            int endPos = htmContent.IndexOf(DataConstantsCore.endPosContentInHtml);
            result = htmContent.Substring(begPos, endPos - begPos);
            return result;
        }

        private void DeleteAndCreateDirectory(string filePathDirectory)
        {
            if (Directory.Exists(filePathDirectory))
            {
                Directory.Delete(filePathDirectory, true);
            }
            Directory.CreateDirectory(filePathDirectory);
        }

        private string[] fillUrlsArray(int numberBegin, int numberEnd, string[] urlsArr,
            string typeBcpeaPath)
        {
            for (int i = numberBegin; i <= numberEnd; i++)
            {
                urlsArr[i-numberBegin] = typeBcpeaPath + i.ToString();
            }

            return urlsArr;
        }
    }
}
