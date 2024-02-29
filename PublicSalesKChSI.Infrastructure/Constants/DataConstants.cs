using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Infrastructure.Constants
{
    public static class DataConstants
    {
        //common for date in string format
        public const int DateLengthMin = 8;
        public const int DateLengthMax = 8;

        //for BrsFile
        public const int BrsFileKlasMin = 8;
        public const int BrsFileKlasMax = 8;

        public const int BrsFileCodeMin = 10000000; //8 digits min
        public const int BrsFileCodeMax = 1000000000; //10 digits max

        public const int BrsFileNameMax = 250;

        public const int BrsFileScreMax = 50;
        public const int BrsFileLicaMax = 200;
        public const int BrsFileTelfMax = 120;

        //for HtmlTemp
        public const int HtmlTempNumberInSiteMin = 1;

        //for PdfTemp
        public const int PdfTempSizeOfFileMin = 1;
        public const int PdfTempSizeOfFileMax = 80000000;

        public const int PdfTempOriginalNameMin = 1;
        public const int PdfTempOriginalNameMax = 2048;

        public const int PdfTempNameMin = 5;
        public const int PdfTempNameMax = 16;

        //for HtmlSeekAttrib
        public const int HtmlSeekAttribPriceMin = 1;
        public const int HtmlSeekAttribPriceMax = 18;

        public const int HtmlSeekAttribCityMin = 2;
        public const int HtmlSeekAttribCityMax = 150;

        public const int HtmlSeekAttribCourtMin = 3;
        public const int HtmlSeekAttribCourtMax = 150;

        public const int HtmlSeekAttribTypeSeekObjMin = 1;
        public const int HtmlSeekAttribTypeSeekObjMax = 3;

        public const int HtmlSeekAttribAddressMin = 5;
        public const int HtmlSeekAttribAddressMax = 250;

        public const int HtmlSeekAttribReceiverMin = 5;
        public const int HtmlSeekAttribReceiverMax = 200;

        public const int HtmlSeekAttribPropertyNumMin = 4;
        public const int HtmlSeekAttribPropertyNumMax = 70;


        //for DeptorOld
        public const int DeptorOldNameMax = 250;

        public const int DeptorOldCourtExtractFromKlasMin = 2;
        public const int DeptorOldCourtExtractFromKlasMax = 2;

        public const int DeptorOldDeptorsInfoMax = 10000; //about 128 row

        //for Court
        public const int CourtTownMin = 3;
        public const int CourtTownMax = 15;

        public const int CourtNumberMin = 2;
        public const int CourtNumberMax = 2;


        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
        public const string ValueRangeErrorMessage = "Value for {0} must be between {1} and {2}.";
    }
}
/*
 * ..FUNC:
1
..TYPE:
6
..MTOM:
48
..MRAZ:
36
..SCOD:
11
..CODV:
99
..CODA:
..SORC:
Кама░а на ╖а▒▓ни▓е ▒║дебни изп║лни▓ели
..IMEF:


 */