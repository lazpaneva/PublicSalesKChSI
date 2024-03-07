using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core
{
    public class DataConstantsCore
    {
        //директории за сваляне на html-ите и pdf-ите 
        public const string pathDownloadHtm = "c:/ksi_html";
        public const string pathDownloadPdf = "c:/ksi_Pdf";

        public const string beginPosContentInHtml = "<div class=\"content\">";
        public const string endPosContentInHtml = "<div class=\"regions__container\">";

        public const string beginPosScanedFile = "<div class=\"label\">Сканирани обявления</div>";
        public const string endPosScanedFile = "</a></li>";
        
    }
}
