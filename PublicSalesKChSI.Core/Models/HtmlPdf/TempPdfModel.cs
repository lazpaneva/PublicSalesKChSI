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
    public class TempPdfModel
    {
        public string OriginalName { get; set; } = null!;

        public string Url { get; set; } = null!;

        public long SizeOfFile { get; set; }

        public int TempHtmlId { get; set; }

    }
}
