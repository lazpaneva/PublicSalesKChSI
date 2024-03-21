using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core
{
    public static class DataConstantsCore
    {
        //for HtmlPdfService
        public const string PathDownloadHtm = "~/ksi_html/";
        public const string PathDownloadPdf = "~/ksi_Pdf/";

        public const string BcpeaPathAsset = "https://sales.bcpea.org/asset/";
        public const string BcpeaPathVechicle = "https://sales.bcpea.org/vehicles/";
        public const string BcpeaPathProperty = "https://sales.bcpea.org/properties/";

        public const string BeginPosContentInHtml = "<div class=\"content\">";
        public const string EndPosContentInHtml = "<div class=\"regions__container\">";

        public const string BeginPosScanedFile = "<div class=\"label\">Сканирани обявления</div>";
        public const string EndPosScanedFile = "</a></li>";
        public const string PosHref = "href=\"";

        //for BrsFileService
        public static String[] ArrayForReplacementWithPoints = new string[]
        {
            "Тип Имущество\n",
            "ОКРЪЖЕН СЪД\n",
            "НАСЕЛЕНО МЯСТО\n",
            "Населено място\n",
            "МЯСТО НА ПРОВЕЖДАНЕ\n",
            "ДАТА НА ПРОВЕЖДАНЕ\n",
            "СРОК\n",
            "ОБЯВЯВАНЕ НА\n",
            "ЧАСТЕН СЪДЕБЕН ИЗПЪЛНИТЕЛ\n",
            "РЕГ. № ЧСИ\n",
            "Адрес\n",
            "Окръжен съд\n",
            "Телефон\n",
            "Мобилен телефон\n",
            "ТИП МПС\n",
            "Други\n",
            "ДВИГАТЕЛ\n",
            "Дата на регистрация\n",
            "уебсайт\n",
            "ТИП СТРОИТЕЛСТВО\n",
            "Етаж\n",
            "ПЛОЩ\n",
            "Квартал\n",
            "Район\n",
        };

        public static String[] ArrayForRemovment = new string[]
        {
            "Сканирани обявления\n",
            "email\n",
        };

        //for BrsFileService - text property
        public static String[] ArrayRemovmentFromText = new string[]
        {
            "-ВИЖ СКАНИРАНОТО ОБЯВЛЕНИЕ",
            "ПОДРОБНОСТИ В ПРИКАЧЕНОТО СКАНИРАНО ОБЯВЛЕНИЕ",
            "За повече информация вижте прикаченото обявление!"
        };

        public static String[] ArrayForHtmlSimbols = new string[]
        {
            "&ndash;",
            "&quot;",
            "&rdquo;",
            "&bdquo;",
            "&ldquo;",
            "&frac12;",
            "&frac14;",
            "&frac16;",
            "&frac18;",
            "&nbsp;&nbsp;&nbsp;",
            "&nbsp;",
            "Начална цена\n"
    };

      public static List<int> allPortions = new List<int>
            {
                150,
                300,
                450,
                600,
                750,
                900,
            };

    }
}
