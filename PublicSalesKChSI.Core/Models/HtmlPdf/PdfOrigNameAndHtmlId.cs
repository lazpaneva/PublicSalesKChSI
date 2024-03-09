using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Models.HtmlPdf
{
    public class PdfOrigNameAndHtmlId
    {

        public string OriginalName { get; set; } = null!;

        public string UrlPdf { get; set; } = null!;

        public int DublicatedFileNameNum { get; set; }

        public int TempHtmlId { get; set; }
        [ForeignKey(nameof(TempHtmlId))]
        public TempHtml TempHtml { get; set; } = null!;
    }
}
