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
                    Text = ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='title']")
                    + ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='date']")
                    + ExtractTextFromHtml(t.Content, "//div[@class='content']//div[@class='item__wrapper']//div[@class='col col--right']")
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

            // Намиране на елемента с клас "content"
            //HtmlNode contentDiv = doc.DocumentNode.SelectSingleNode("//div[@class='content wrapper']");
            HtmlNode contentDiv = doc.DocumentNode.SelectSingleNode(htmlElement);

            if (contentDiv != null)
            {
                // Извличане на текста от елемента
                string plainText = contentDiv.InnerText;
                return plainText;
            }
            else
            {
                return null;
            }
        }
    }
}
