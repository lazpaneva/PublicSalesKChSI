﻿using PublicSalesKChSI.Core.Models.WorkingOnFiles;
using PublicSalesKChSI.Infrastructure.Constants;
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
            int filesPerPage = 1
            );

        Task<IEnumerable<string>> AllCourtsTownAsync();

        Task<bool> ExistsAsync(int id);
        Task<FileDetailsServiceModel> FileDetailsByIdAsync(int id);
        Task EditAsync(int fileId, FileFormModel model);

    }
}
