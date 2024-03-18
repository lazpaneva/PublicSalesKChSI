using HtmlAgilityPack;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.BrsFile;
using PublicSalesKChSI.Infrastructure.Data.Common;
using PublicSalesKChSI.Infrastructure.Data.Models;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
using System.Text.RegularExpressions;
using System.Security.Claims;
using static PublicSalesKChSI.Core.DataConstantsCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace PublicSalesKChSI.Core.Services
{
    public class BrsFileService : IBrsFileService
    {
        private readonly IRepository repo;
        public BrsFileService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<BrsFileValidationModel>> FillBrsFile(string userId)
        {
            //транзитен модел, пъхам в LabelGroups всички от //div[@class='label__group'],
            //нямам критерии да ги разделя, после взимам поотделно дата на публикуване, правя name и т.н.
            var txtList = await repo.AllReadOnly<TempHtml>()
                .Select(t => new BrsFileTransitModel()
                {
                    Id = t.Id,
                    BrsFileNumber = repo.AllReadOnly<TempPdf>()
                        .Where(i => i.TempHtmlId == t.Id).First().DublicatedFileNameNum,
                    Title = ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='title']"),
                    Date = ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='date']"),
                    Price = ReplaceSimbolsFromText(ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='col col--right']")),
                    Address = ReplaceSimbolsFromText(ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='label__group label__group--double']")),
                    Text = ReplaceSimbolsFromText(ExtractTextFromHtml(t.Content, "//div[@class='label__group label__group-description']//div[@class='info']")),
                    NameSI = ExtractTextFromHtml(t.Content, "//div[@class='person_info']//div[@class='title']"),
                    NumberInSite = t.NumberInSite,

                    LabelGroups = ExtractFromLabelGroup(t.Content),
                    UrlPdf = repo.AllReadOnly<TempPdf>()
                                .Where(tp => tp.TempHtmlId == t.Id)
                                .Select(tp => new BrsFileUrlPdf()
                                {
                                    UrlPdf = tp.Url
                                }).First().UrlPdf
                })
                .ToListAsync();
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
            }

            ICollection<BrsFile> brsFilesWithValidationError = 
                new List<BrsFile>();
            var txtListGroupedByBrsFileNumber = txtList.GroupBy(x => x.BrsFileNumber);
            foreach (var group in txtListGroupedByBrsFileNumber)
            {
                var brsFile = new BrsFile();
                var firstElement = group.First();
                brsFile.Code = GetCode(firstElement.NumberInSite);
                brsFile.Date = GetPublishedDate(firstElement.Date);
                brsFile.Dcng = GetPublishedDate(firstElement.Date);
                brsFile.Klas = GetKlas(firstElement.LabelGroups);
                brsFile.Name = ReplaceSimbolsInName(GetName(firstElement.Title, firstElement.Price,
                    firstElement.Address, firstElement.LabelGroups));
                brsFile.IsFindDeptor = false;
                brsFile.IsFileReady = false;
                brsFile.IsFileExported = false;
                //brsFile.EmployeeId = userId;
                if (firstElement.UrlPdf != null)
                {
                    brsFile.UrlPdf = firstElement.UrlPdf;
                }
                else
                {
                    brsFile.UrlPdf = "Няма pdf файл.";
                }
                

                //string brsText = String.Join("\n", firstElement.LabelGroups.Take(13));
                string brsText = "----------------------------------------\n";
                string infoSI= string.Empty;
                foreach (var item in group)
                {
                    brsText += item.LabelGroups.Take(13);
                    //if (countElemGroup >= 1 && countElemGroup<=8) 
                    //{
                    //        brsText += ReplaceSimbolsFromText(item.Text); 
                    //}
                    //else if (countElemGroup >= 9 && countElemGroup < 14)
                    //{
                    //    infoSI += ReplaceSimbolsFromText(item.Text);
                    //}
                    brsText += ReplaceSimbolsFromText(item.Text)+ "\n";
                    brsText += "..TEXT:\n";
                    
                    //попълване на virtual list
                    int numSite = item.NumberInSite;
                    TempHtml tempHtml = await repo.All<TempHtml>()
                            .Where(h => h.NumberInSite == numSite)
                            .FirstOrDefaultAsync();
                    
                    brsFile.HtmlFiles.Add(tempHtml);
                    await repo.SaveChangesAsync();
                    //countElemGroup++;
                }
                brsFile.Text += firstElement.NameSI;
                brsFile.Text += infoSI;
                brsFile.Text = ReplaceSimbolsInName(brsText);

                if (!IsValid(brsFile))
                {
                    brsFilesWithValidationError.Add(brsFile);
                }
                else
                {
                    await repo.AddAsync(brsFile);
                    await repo.SaveChangesAsync();
                }
            }

            IEnumerable<BrsFileValidationModel> brsFilesForValidation = brsFilesWithValidationError
                .Select(f => new BrsFileValidationModel()
                {
                    Code = f.Code,
                    Klas = f.Klas,
                    Date = f.Date,
                    Dcng = f.Dcng,
                    Name = f.Name,
                    Text = f.Text,
                    IsFileReady = f.IsFileReady,
                    IsFindDeptor = f.IsFindDeptor,
                })
                .ToList();
            
            return brsFilesForValidation;
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
                                
                return plainText.Trim();
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
                    //int indexPodobni = labelText.IndexOf("Подобни обяви");
                    //if (indexPodobni != -1)
                    //{
                    //    labelText = labelText.Substring(0, indexPodobni);
                    //}

                    labelText = labelText.Replace("&quot;", "\"");
                    labelGroupInfoList.Add(labelText);
                }
            }

            ////изчистване на излишните "населени места" от ПОДОБНИ ОБЯВИ, които също са с клас=label__group
            //int count = 0;
            //int listLength = 1;
            //foreach (var label in labelGroupInfoList)
            //{
            //    if (label.Contains("НАСЕЛЕНО МЯСТО"))
            //    {
            //        count++;
            //    }
            //    if (count > 1 && label.Contains("НАСЕЛЕНО МЯСТО"))
            //    {
            //        break;
            //    }
            //    listLength++;
            //}
            //return labelGroupInfoList.Take(listLength-1).ToArray();
            return labelGroupInfoList.ToArray();
        }
        private static string ReplaceMultipleSpacesWithNewLine(string input)
        {
            string pattern = @"^(\&nbsp;){3,}";
            Regex regex = new Regex(pattern);
            input = regex.Replace(input, "\n");
            return input;
        }
        private static string ReplaceSimbolsFromText(string? str)
        {
            if (str!= null)
            {
                for (int i = 0; i < ArrayForHtmlSimbols.Length; i++)
                {
                    if (str.Contains(ArrayForHtmlSimbols[i]))
                    {
                        str = str.Replace("\t", " ").Trim();
                        str = str.Replace("«", "\"").Trim();
                        str = str.Replace("»", "\"").Trim();
                        str = str.Replace("&quot;", "\"");
                        str = str.Replace("&rdquo;", "\"");
                        str = str.Replace("&ldquo;", "\"");
                        str = str.Replace("&bdquo;", "\"");
                        str = str.Replace("&ndash;&nbsp;", "- ");
                        str = str.Replace("&nbsp;&ndash;", " -");
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
                        str = ReplaceMultipleSpacesWithNewLine(str);
                        str = str.Replace("&nbsp;", " ");
                        str = str.Replace("Начална цена\n", "Начална цена: ");
                    }
                }
                for (int i = 0; i <= 9; i++) 
                {
                    string incorrectSubstr = String.Concat("№", i.ToString());
                    string correctSubstr = String.Concat("№ ", i.ToString());
                    str = str.Replace(incorrectSubstr, correctSubstr);
                }
                str.Replace("\"№", "\" №");
                foreach (var item in ArrayRemovmentFromText)
                {
                    str.Replace(item, "");
                }
                while (str.Contains("  "))
                {
                    str = str.Replace("  ", " ");
                }
            }
            
            return str;
        }

        private static string ReplaceSimbolsInName(string input)
        {
            while (input.Contains(", , "))
            {
                input = input.Replace(", , ",", ");
            }
            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }


            if (input.Length >= 1)
            {
                string substr = input.Substring(input.Length - 1, 1);
                if (substr == ",")
                {
                    input = input.Substring(0, input.Length - 1);
                }
            }
            
            return input.Trim();
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

        private string GetCode(int NumberInSite)
        {
            string result = "3002" + "09" + NumberInSite.ToString("D6");

            return result;
        }
        private string GetKlas(string[] labelGroups)
        {
            string result = string.Empty;
            string year = DateTime.Now.Year.ToString();
            result = string.Concat("KSI", year.Substring(2), "_");
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

            if (address != null)
            {
                address = address.Replace("ВИД НА ТЪРГА\n Публична продан", "");
                int posAddress = address.IndexOf("Адрес:");
                if (posAddress != -1) { address = address.Substring(posAddress + 7).Trim(); }
            }

            //string? area = Array.Find(subOther, element => element.Contains("ПЛОЩ: "));
            string area = String.Empty;
            string town = String.Empty;
            string otherStr = string.Join("\n", other);
            int indexArea = otherStr.IndexOf("ПЛОЩ: ");
            int indexTown = otherStr.IndexOf("НАСЕЛЕНО МЯСТО: ");
            if (indexArea != -1)
            {
                area = otherStr.Substring(indexArea + 6, otherStr.IndexOf("\n", indexArea+6) - indexArea).Trim();
                area = area.Replace("кв.м", "кв. м");
            }

            //string? town = Array.Find(subOther, element => element.Contains("НАСЕЛЕНО МЯСТО: "));
            if (indexTown != -1)
            {
                town = otherStr.Substring(indexTown+16, otherStr.IndexOf("\n", indexTown + 16) - indexTown);
            }

            result = title + ", " + replacedPrice + ", " + area + ", " + town + ", " + address;
            result = ReplaceSimbolsInName(result);

            return result;
        }
        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }


    }

}