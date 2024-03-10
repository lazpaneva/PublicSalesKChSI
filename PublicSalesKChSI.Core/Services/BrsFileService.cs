using HtmlAgilityPack;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.BrsFile;
using PublicSalesKChSI.Infrastructure.Data.Common;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
using static PublicSalesKChSI.Core.DataConstantsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            var txtList = repo.AllReadOnly<TempHtml>()
                .Select(t => new BrsOnlyContent()
                {
                    Title = ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='title']"),
                    Date = ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='date']"),
                    Price = ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='col col--right']")
                    .Replace("Начална цена\n", "Начална цена: "),
                    Text = ReplaceSimbolsFromText(ExtractTextFromHtml(t.Content, "//div[@class='label__group label__group-description']//div[@class='info']")),
                    NameSI = ExtractTextFromHtml(t.Content, "//div[@class='person_info']//div[@class='title']"),
                    NumberSI = "Рег. № ЧСИ - " +
                             ExtractTextFromHtml(t.Content, "//div[@class='person_info']//div[@class='label__group']//div[@class='info']"),

                    Other = ExtractFromLabelGroupDelimitedWithColon(t.Content)

                })
                .ToList();
            //добавяне на ':', където е необходимо, изтриване на ненужна информация
            //и заместване на html-simbols
            foreach (var txtItem in txtList)
            {
                for (int i = 0; i < ArrayForReplacementWithPoints.Length; i++)
                {
                    for (int j = 0; j < txtItem.Other.Length; j++)
                    {
                        if (txtItem.Other[j].Contains(ArrayForReplacementWithPoints[i]))
                        {
                            txtItem.Other[j] = txtItem.Other[j]
                                .Replace(ArrayForReplacementWithPoints[i], ArrayForReplacementWithPoints[i].Trim()+": ");
                        }
                    }
                }

                for (int i = 0; i < ArrayForRemovment.Length; i++)
                {
                    for (int j = 0; j < txtItem.Other.Length; j++)
                    {
                        if (txtItem.Other[j].Contains(ArrayForRemovment[i]))
                        {
                            txtItem.Other[j] = String.Empty;
                        }
                    }
                }
            }

            return txtList;
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
        private static String[] ExtractFromLabelGroupDelimitedWithColon(string htmlContent)
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
                    //var label = labelGroup.SelectSingleNode("//div[@class='label']").InnerText.Trim();
                    //var info = labelGroup.SelectSingleNode("//div[@class='info']").InnerText.Trim();
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
            return labelGroupInfoList.Take(listLength-1).ToArray();
        }
        private static string ReplaceMultipleSpacesWithNewLine(string input, int threshold)
        {
            string replacement = Environment.NewLine;

            // Генериране на низ с три &nbsp;
            string multipleSpaces = string.Concat(Enumerable.Repeat("&nbsp; ", threshold));

            // Заместване на повече от три &nbsp; с нов ред
            string result = input.Replace(multipleSpaces, replacement);

            return result;
        }
        private static string ReplaceSimbolsFromText(string str)
        {
            string result = string.Empty;
            if (str!= null)
            {
                for (int i = 0; i < ArrayForHtmlSimbols.Length; i++)
                {
                    if (str.Contains(ArrayForHtmlSimbols[i]))
                    {
                        str = str.Replace("&quot;", "\"");
                        str = str.Replace("&rdquo;", "\"");
                        str = str.Replace("&ldquo;", "\"");
                        str = str.Replace("&bdquo;", "\"");
                        str = str.Replace("&ndash;", "-");
                        str = str.Replace("&frac12;", "1/2");
                        str = str.Replace("&frac13;", "1/3");
                        str = str.Replace("&frac14;", "1/4");
                        str = str.Replace("&frac15;", "1/5");
                        str = str.Replace("&frac16;", "1/6");
                        str = str.Replace("&frac17;", "1/7");
                        str = str.Replace("&frac18;", "1/8");
                        str = str.Replace("&frac19;", "1/9");
                        str = str.Replace("&frac10;", "1/10");
                        str = str.Replace("&frac111;", "1/11");
                        str = str.Replace("&frac112;", "1/12");
                        str = ReplaceMultipleSpacesWithNewLine(str, 3);
                        str = str.Replace("&nbsp;", " ");
                    }
                }
            }
            return result;
        }

    }

}