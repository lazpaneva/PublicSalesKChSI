using PublicSalesKChSI.Core.Models.WorkingOnFiles;
using PublicSalesKChSI.Infrastructure.Constants;
using PublicSalesKChSI.Infrastructure.Data.Models;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Contracts
{
    public interface IWorkingOnFilesService
    {
        Task<FileQueryServiceModel> AllAsync(string? court = null,
            string? searchFirstTermName = null,
            string? searchSeconTermName = null,
            string? searchThirdTermName = null,
            FileSorting sorting = FileSorting.Newest,
            int currentPage = 1,
            int filesPerPage = 1,
            bool notReady = false
            );

        Task<IEnumerable<string>> AllCourtsTownAsync();

        Task<bool> ExistsAsyncBrsFile(int id);
        Task<string> ExistsEmployeeIdWitrhIdAsync(int brsId);
        Task<FileDetailsServiceModel> FileDetailsByIdAsync(int id);
        Task EditAsync(int fileId, FileFormModel model);
        Task DeleteBrsFileAsync(int fileId);
        Task DeleteTempHtmlByBrsFileIdAsync(int brsFileId);
        //Task<FileQueryServiceModel> GetAllNotReadyFilesAsync(string? court = null,
        //    string? searchFirstTermName = null,
        //    string? searchSeconTermName = null,
        //    string? searchThirdTermName = null,
        //    FileSorting sorting = FileSorting.Newest,
        //    int currentPage = 1,
        //    int filesPerPage = 1);

    }
}
