﻿using Microsoft.AspNetCore.Hosting.Server;
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
using System.Text.RegularExpressions;
using static PublicSalesKChSI.Core.DataConstantsCore;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Html;
using System.Security.Cryptography;

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
                //string filePath = Path.Combine(Server.MapPath("~/App_Data"), fileName); //to do, ако се качи в нета
                string filePath = Path.Combine(DataConstantsCore.pathDownloadHtm, fileName);
                                
                TempHtml htmlAdd = new TempHtml();
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string htmlContent = await client.DownloadStringTaskAsync(urlAddress); 
                        string htmlAddForDb = RemoveScriptContent(htmlContent); //delete от <script to </script

                        htmlAdd = new TempHtml()
                        {
                            Type = type,
                            Content = htmlAddForDb,
                            CreatedOn = DateTime.Now,
                            NumberInSite = int.Parse(urlAddress.Substring(urlAddress.LastIndexOf('/') + 1).Trim()),
                        };
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

        [HttpGet]
        public async Task FillTempPDf()
        {
            var pdfContents = repo.AllReadOnly<TempHtml>()
                .Select(html => new PdfOrigNameAndHtmlId()
                {
                    OriginalName = TakePdfName(html.Content),
                    UrlPdf = TakePdfUrl(html.Content),
                    TempHtmlId = html.Id
                })
                .ToList();

            int count = 1;
            foreach (var item in pdfContents)
            {
                TempPdf tempPdf = new TempPdf();
                string numbString = count.ToString("D4");

                tempPdf.TempHtmlId = item.TempHtmlId;
                tempPdf.Url = item.UrlPdf;
                tempPdf.OriginalName = item.OriginalName;
                tempPdf.Name = numbString + "_" + item.OriginalName;

                await repo.AddAsync(tempPdf);
                await repo.SaveChangesAsync();

                count++;
            }
        }

        private static string TakePdfUrl(string content)
        {
            string result = string.Empty;
            int beginPos = content.IndexOf(beginPosScanedFile);
            //content = content.Substring(beginPos);
            int endPos = content.IndexOf(endPosScanedFile, beginPos);
            
            if (beginPos != -1)
            {
                content = content.Substring(beginPos, endPos - beginPos);
                int posOfHref = content.IndexOf("href=\"");
                result = content.Substring(posOfHref+6);
                result = result.Substring(1, result.LastIndexOf("\">")-1).Trim();
            }
            return result;
        }

        private static string TakePdfName(string content)
        {
            string result = TakePdfUrl(content);
            if (result.LastIndexOf("/") != -1)
            {
                result = result.Substring(result.LastIndexOf("/")+1);
            }
            
            return result;
        }

        private string RemoveScriptContent(string input)
        {
            string pattern = @"<script\b[^<]*(?:(?!</script>)<[^<]*)*</script>"; //from chat gpt 
            Regex regex = new Regex(pattern);
            return regex.Replace(input, "");
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
