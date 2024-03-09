using HtmlAgilityPack;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.BrsFile;
using PublicSalesKChSI.Infrastructure.Data.Common;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Services
{
    public class BrsFileService : IBrsFileService
    {
        private readonly IRepository repo;
        public BrsFileService(IRepository _repo)
        {
            repo = _repo;
        }

        public List<BrsOnlyContent> FillBrsFile()
        {
            var htmlList = repo.AllReadOnly<TempHtml>()
                .Select(t => new BrsOnlyContent()
                {
                    Title = ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='title']"),
                    Date = ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='date']"),
                    Price = ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='col col--right']"),
                    NameSI = ExtractTextFromHtml(t.Content, "//div[@class='person_info']//div[@class='title']"),
                    NumberSI = "Рег. № ЧСИ - " +
                             ExtractTextFromHtml(t.Content, "//div[@class='person_info']//div[@class='label__group']//div[@class='info']"),


                    Other = ExtractFromLabelGroupDelimitedWithColon(t.Content)
                })
                .ToList();

            return htmlList;
        }


        //functions
        private static string? ExtractTextFromHtml(string htmlContent, string htmlElement)
        {
            // Използване на HtmlAgilityPack за парсване на HTML
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            // Намиране на елемента - htmlElement
            HtmlNode contentDiv = doc.DocumentNode.SelectSingleNode(htmlElement);

            if (contentDiv != null)
            {
                string plainText = contentDiv.InnerText;
                return plainText;
            }
            else
            {
                return null;
            }
        }
        private static List<String> ExtractFromLabelGroupDelimitedWithColon(string htmlContent)
        {
            List<string> labelGroupInfoList = new List<string>();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            var labelGroups = doc.DocumentNode.SelectNodes("//div[@class='label__group']");
            //var labelGroups = doc.DocumentNode.SelectNodes("/div[@class='col col--info']//div[@class='label__group']");

            if (labelGroups != null)
            {
                foreach (var labelGroup in labelGroups)
                {
                    //закоментираното не върви ???? не е ясно защо
                    //var label = labelGroup.SelectSingleNode(".//div[@class='label']").InnerText.Trim();
                    //var info = labelGroup.SelectSingleNode(".//div[@class='info']").InnerText.Trim();
                    //labelGroupInfoList.Add($"{label}: {info}");
                    labelGroupInfoList.Add($"{labelGroup.InnerText}");
                }
            }

            //изчистване на излишните населени места от ПОДОБНИ ОБЯВИ, които също са с клас=label__group
            int count = 0;
            int listLength = 1;
            foreach (var label in labelGroupInfoList)
            {
                if (label.Contains("НАСЕЛЕНО МЯСТО"))
                {
                    count++;
                }
                if (count > 1 && label.Contains("НАСЕЛЕНО МЯСТО"))
                {
                    break;
                }
                listLength++;
            }
            return labelGroupInfoList.Take(listLength-1).ToList();
        }
    }
}