using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int HtmlTempNumberInSiteMin = 1;

        public const int PdfTempSizeOfFileMin = 1;
        public const int PdfTempSizeOfFileMax = 10000000;

        public const int PdfTempOriginalNameMin = 1;
        public const int PdfTempOriginalNameMax = 2048;

        public const int PdfTempNameMin = 5;
        public const int PdfTempNameMax = 16;
    }
}
