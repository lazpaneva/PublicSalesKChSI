using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core
{
    public class DataConstantsCore
    {
        //for HtmlPdfService
        public const string PathDownloadHtm = "c:/ksi_html";
        public const string PathDownloadPdf = "c:/ksi_Pdf";

        public const string BcpeaPathAsset = "https://sales.bcpea.org/asset/";
        public const string BcpeaPathVechicle = "https://sales.bcpea.org/vehicles/";
        public const string BcpeaPathProperty = "https://sales.bcpea.org/properties/";

        public const string BeginPosContentInHtml = "<div class=\"content\">";
        public const string EndPosContentInHtml = "<div class=\"regions__container\">";

        public const string BeginPosScanedFile = "<div class=\"label\">Сканирани обявления</div>";
        public const string EndPosScanedFile = "</a></li>";
        public const string PosHref = "href=\"";
        

    }
}
