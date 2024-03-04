using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.HtmlPdf;
using PublicSalesKChSI.Infrastructure.Data.Common;
using PublicSalesKChSI.Infrastructure.Data.Models;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Services
{
    public class HtmlPdfService : IHtmlPdfService
    {
        private readonly IRepository repo;

        public HtmlPdfService(IRepository _repository)
        {
            repo = _repository;
        }

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

            return lastNumsForThreeDifferentTypes;
        }

        public async Task<bool> DownloadHtmlFiles(int numberBegin, int numberEnd, int type)
        {
            bool result = false;
            int sizeUrls = numberEnd - numberBegin + 1;
            string[] urls = new string[sizeUrls];
            string typeBcpeaPath = string.Empty;
            string stringType = string.Empty;
            switch (type)
            {
                case 1:
                    typeBcpeaPath = "https://sales.bcpea.org/asset/";
                    stringType = "Asset";
                    break;
                case 2:
                    typeBcpeaPath = "https://sales.bcpea.org/vehicles/";
                    stringType = "Vehicles";
                    break;
                case 3:
                    typeBcpeaPath = "https://sales.bcpea.org/properties/";
                    stringType = "Properties";
                    break;
                default:
                    break;
            }

            urls = fillUrlsArray(numberBegin, numberEnd, urls, typeBcpeaPath);
            foreach (string url in urls)
            {
                //string fileName = "html_"+ url.Substring(url.LastIndexOf('/')+1).Trim()
                //    +".html";
                //string filePath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                //string filePath = Path.Combine("c:/ksi/", fileName);
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string htmlContent = await client.DownloadStringTaskAsync(url);
                        var htmlAdd = new TempHtml()
                        {
                            Type = stringType,
                            Content = htmlContent,
                            CreatedOn = DateTime.Now,
                            NumberInSite = int.Parse(url.Substring(url.LastIndexOf('/') + 1).Trim()),
                            BrsFileId = -1 //"-1" - means not fill in BRS file yet

                        };
                        await repo.AddAsync(htmlAdd);
                        // System.IO.File.WriteAllText(filePath, htmlContent);
                    }
                    catch (WebException ex)
                    {
                        // Handle any errors that may occur during the download
                        // For example, log the error or take appropriate action
                        Console.WriteLine($"Error downloading {url}: {ex.Message}");
                    }
                    await repo.SaveChangesAsync();
                }
            }

            result = true;

            return result;
        }

        private string[] fillUrlsArray(int numberBegin, int numberEnd, string[] urls,
            string typeBcpeaPath)
        {
            for (int i = numberBegin; i <= numberEnd; i++)
            {
                urls[i-numberBegin] = typeBcpeaPath + i.ToString();
            }

            return urls;
        }
    }
}
