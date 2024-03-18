using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.WorkingOnFiles;
using PublicSalesKChSI.Infrastructure.Constants;
using PublicSalesKChSI.Infrastructure.Data.Common;
using PublicSalesKChSI.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PublicSalesKChSI.Core.Services
{
    public class WorkingOnFilesService : IWorkingOnFilesService
    {
        private readonly IRepository repo;
        public WorkingOnFilesService(IRepository _repository)
        {
            repo = _repository;
        }
        public async Task<FileQueryServiceModel> AllAsync(string? court = null, string? searchTermName = null,
            string? searchTermText = null, FileSorting sorting = FileSorting.Newest,
            int currentPage = 1, int filesPerPage = 1)
        {
            var filesToShow = repo.AllReadOnly<BrsFile>();

            if (!string.IsNullOrWhiteSpace(court))
            {
                filesToShow = filesToShow
                    .Where(f => f.Klas.Substring(6) == court); //да го дооправя
            }

            if (!string.IsNullOrWhiteSpace(searchTermName))
            {
                string normalizedSearchTerm = searchTermName.ToLower();
                filesToShow = filesToShow
                    .Where(f => (f.Name.ToLower().Contains(normalizedSearchTerm)));
            }

            if (!string.IsNullOrWhiteSpace(searchTermText))
            {
                string normalizedSearchTerm = searchTermText.ToLower();
                filesToShow = filesToShow
                    .Where(f => (f.Text.ToLower().Contains(normalizedSearchTerm)));
            }

            filesToShow = sorting switch
            {
                FileSorting.Dlajnici => filesToShow
                    .OrderBy(f => f.Lica),
                _ => filesToShow
                    .OrderByDescending(f => f.Dcng)
            };

            var files = await filesToShow
                .Skip((currentPage - 1) * filesPerPage)
                .Take(filesPerPage)
                .Select(f=> new FileServiceModel
                { 
                    Id = f.Id,
                    Name = f.Name,
                    Dcng = f.Dcng,
                    Klas = f.Klas,
                    Lica = f.Lica,
                    IsFileReady = f.IsFileReady,
                })
                .ToListAsync();

            int totalFiles = await filesToShow.CountAsync();

            return new FileQueryServiceModel()
            {
                Files = files,
                TotalFilesCount = totalFiles
            };
        }

        public async Task<IEnumerable<string>> AllCourtsTownAsync()
        {
            return await repo.AllReadOnly<Court>()
                .Select(c => c.Town)
                .Distinct()
                .ToListAsync();
        }

    }
}


