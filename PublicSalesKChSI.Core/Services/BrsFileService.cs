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
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using PublicSalesKChSI.Infrastructure.Data.Models;
using System.Net;

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
                    Address = ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='label__group label__group--double']"),
                    Text = ReplaceSimbolsFromText(ExtractTextFromHtml(t.Content, "//div[@class='label__group label__group-description']//div[@class='info']")),
                    NameSI = ExtractTextFromHtml(t.Content, "//div[@class='person_info']//div[@class='title']"),
                    NumberSI = "Рег. № ЧСИ - " +
                             ExtractTextFromHtml(t.Content, "//div[@class='person_info']//div[@class='label__group']//div[@class='info']"),

                    LabelGroups = ExtractFromLabelGroup(t.Content)

                })
                .ToList();
            //добавяне на ':', където е необходимо, изтриване на ненужна информация
            //и заместване на html-simbols
            foreach (var txtItem in txtList)
            {
                for (int i = 0; i < ArrayForReplacementWithPoints.Length; i++)
                {
                    for (int j = 0; j < txtItem.LabelGroups.Length; j++)
                    {
                        if (txtItem.LabelGroups[j].Contains(ArrayForReplacementWithPoints[i]))
                        {
                            txtItem.LabelGroups[j] = txtItem.LabelGroups[j]
                                .Replace(ArrayForReplacementWithPoints[i], ArrayForReplacementWithPoints[i].Trim()+": ");
                        }
                    }
                }

                if (txtItem.Address != null) 
                {
                    txtItem.Address = txtItem.Address.Replace("Адрес", "Адрес:");
                    txtItem.Address = txtItem.Address.Replace("&quot;", "\""); 
                }

                for (int i = 0; i < ArrayForRemovment.Length; i++)
                {
                    for (int j = 0; j < txtItem.LabelGroups.Length; j++)
                    {
                        if (txtItem.LabelGroups[j].Contains(ArrayForRemovment[i]))
                        {
                            txtItem.LabelGroups[j] = String.Empty;
                        }
                    }
                }
                
                string publDate = GetPublishedDate(txtItem.Date);
                GetKlas(txtItem.LabelGroups);
                GetName(txtItem.Title, txtItem.Price, txtItem.Address, txtItem.LabelGroups);
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
        private static String[] ExtractFromLabelGroup(string htmlContent)
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
                    string labelText = labelGroup.InnerText;
                    labelText = labelText.Replace("&quot;", "\"");
                    labelGroupInfoList.Add(labelText);
                }
            }

            //изчистване на излишните "населени места" от ПОДОБНИ ОБЯВИ, които също са с клас=label__group
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
        private static string ReplaceMultipleSpacesWithNewLine(string input)
        {
            string pattern = @"^(\&nbsp;){3,}";
            Regex regex = new Regex(pattern);
            input = regex.Replace(input, "\n");
            return input;
        }
        private static string ReplaceSimbolsFromText(string str)
        {
            string result = str;
            if (str!= null)
            {
                for (int i = 0; i < ArrayForHtmlSimbols.Length; i++)
                {
                    if (result.Contains(ArrayForHtmlSimbols[i]))
                    {
                        result = result.Replace("&quot;", "\"");
                        result = result.Replace("&rdquo;", "\"");
                        result = result.Replace("&ldquo;", "\"");
                        result = result.Replace("&bdquo;", "\"");
                        result = result.Replace("&ndash;&nbsp;", "- ");
                        result = result.Replace("&nbsp;&ndash;", " -");
                        result = result.Replace("&ndash;", "-");
                        result = result.Replace("&frac12;", "1/2");
                        result = result.Replace("&frac13;", "1/3");
                        result = result.Replace("&frac14;", "1/4");
                        result = result.Replace("&frac15;", "1/5");
                        result = result.Replace("&frac16;", "1/6");
                        result = result.Replace("&frac17;", "1/7");
                        result = result.Replace("&frac18;", "1/8");
                        result = result.Replace("&frac19;", "1/9");
                        result = result.Replace("&frac10;", "1/10");
                        result = result.Replace("&frac111;", "1/11");
                        result = result.Replace("&frac112;", "1/12");
                        result = ReplaceMultipleSpacesWithNewLine(str);
                        result = result.Replace("&nbsp;", " ");
                    }
                }
            }
            return result;
        }

        private string GetPublishedDate(string dateFromBrsOnlyContent)
        {
            string result = string.Empty;
            int begPos = dateFromBrsOnlyContent.IndexOf("Публикувано на ");
            if (begPos != -1)
            {
                result = dateFromBrsOnlyContent.Substring(begPos+15);
                result = result.Substring(0, result.IndexOf(" г."));
                DateTime dt = new DateTime();
                bool IsDateOk = DateTime.TryParse(result, out dt);
                if (IsDateOk)
                {
                    result = dt.ToString("yyyyMMdd");
                }
                else
                {
                    result = DateTime.Now.ToString("yyyyMMdd");
                }
            }
            return result;
        }
        private string GetKlas(string[] labelGroups)
        {
            string result = string.Empty;
            string year = DateTime.Now.Year.ToString();
            result = "KSI" + year.Substring(2) + "_";
            string? town = Array.Find(labelGroups, element => element.Contains("ОКРЪЖЕН СЪД: "));
            town = town?.Substring(town.IndexOf("ОКРЪЖЕН СЪД: ") + 13).Trim().ToUpper();
            string numberTown = string.Empty;

            if (town != null) {
                numberTown = repo.AllReadOnly<Court>()
                    .Where(t => t.Town == town)
                    .FirstOrDefault().Number;
            }
            result += numberTown;

            return result;
        }

        //ЛИПСВА НАСЕЛЕНО МЯСТО В АДРЕСА, освен това дали да го обвързвам с типа на обявата ??? И в tempHtml не се попълва, може би няма да е зле да го мисля???
        private string GetName(string title, string price, string address, string[] other)
        {
            string result = string.Empty;
            string replacedPrice = price.Replace("Начална цена: ", "нач. цена ").Trim();
            replacedPrice = replacedPrice.Substring(0, replacedPrice.IndexOf("лв.") + 3);
            if (address != null && !address.Contains("ВИД НА ТЪРГА"))
            {
                address = address.Substring(address.IndexOf("Адрес:") + 7).Trim();
            }
            string? area = Array.Find(other, element => element.Contains("ПЛОЩ: "));
            area = area?.Substring(area.IndexOf("ПЛОЩ: ") + 6).Trim();
            area = area?.Replace("кв.м", "кв. м");


            result = title + ", " + replacedPrice + ", " + area + ", " + address;

            return result;
        }

    }

}