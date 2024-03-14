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
    public class TempPdfViewModel
    {
        public int PdfFileCount { get; set; }
        public int HtmlFileCount { get; set; }
        public IEnumerable<TempPdfModel> TempPdfModels { get; set; } = 
            new List<TempPdfModel>();

    }
}
