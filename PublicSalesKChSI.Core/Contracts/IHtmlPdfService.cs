using PublicSalesKChSI.Core.Models.HtmlPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Contracts
{
    public interface IHtmlPdfService
    {
        Task<int[]> GetLastNumbersAsync();
        Task<bool> DownloadHtmlFilesAsync(int numberBegin, int numberEnd, string type);

        Task<bool> DownloadPdfFilesAsync(string folderPath);
        public TempPdfViewModel ViewingPdfFilesIsDownloadingAsync();
        Task FillTempPDfAsync();

        //Task updateLastDownNumbers(string type, int lastNumberInType);
        //public List<PdfOrigNameAndHtmlId> DownLoadPdfFiles();
    }
}
