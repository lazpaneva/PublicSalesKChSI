using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Core.Models.WorkingOnFiles;
using PublicSalesKChSI.Infrastructure.Constants;
using PublicSalesKChSI.Infrastructure.Data.Common;
using PublicSalesKChSI.Infrastructure.Data.Models;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
        public async Task<FileQueryServiceModel> AllAsync(string? court = null, string? searchFirstTermName = null,
            string? searchSecondTermText = null, string? searchThirdTermText = null, FileSorting sorting = FileSorting.Newest,
            int currentPage = 1, int filesPerPage = 1)
        {
            var filesToShow = repo.AllReadOnly<BrsFile>();

            if (!string.IsNullOrWhiteSpace(court))
            {
                var seekCourt = await repo.AllReadOnly<Court>()
                    .Where(c => c.Town == court)
                    .FirstOrDefaultAsync();
                if (seekCourt != null)
                {
                    filesToShow = filesToShow
                    .Where(f => f.Klas.Substring(6) == seekCourt.Number);
                }
                
            }

            if (!string.IsNullOrWhiteSpace(searchFirstTermName))
            {
                string normalizedSearchTerm = searchFirstTermName.ToLower();
                filesToShow = filesToShow
                    .Where(f => (f.Name.ToLower().Contains(normalizedSearchTerm)));
            }

            if (!string.IsNullOrWhiteSpace(searchSecondTermText))
            {
                string normalizedSearchTerm = searchSecondTermText.ToLower();
                filesToShow = filesToShow
                    .Where(f => (f.Name.ToLower().Contains(normalizedSearchTerm)));
            }

            if (!string.IsNullOrWhiteSpace(searchThirdTermText))
            {
                string normalizedSearchTerm = searchThirdTermText.ToLower();
                filesToShow = filesToShow
                    .Where(f => (f.Name.ToLower().Contains(normalizedSearchTerm)));
            }
            filesToShow = sorting switch
            {
                FileSorting.Dlajnici => filesToShow
                    .OrderBy(f => f.Lica),
                FileSorting.Name => filesToShow
                .OrderBy(f => f.Name),
                _ => filesToShow    
                    .OrderByDescending(f => f.Code)
            };

            var files = await filesToShow
                .Skip((currentPage - 1) * filesPerPage)
                .Take(filesPerPage)
                .Select(f=> new FileServiceModel
                { 
                    Id = f.Id,
                    Code = f.Code,
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
        public async Task<bool> ExistsAsyncBrsFile(int id)
        {
            return await repo.AllReadOnly<BrsFile>()
                .AnyAsync(f=> f.Id== id);
        }

        public async Task<FileDetailsServiceModel> FileDetailsByIdAsync(int id)
        {
            return await repo.AllReadOnly<BrsFile>()
                .Where(f => f.Id == id)
                .Select(h => new FileDetailsServiceModel()
                {
                    Id = h.Id,
                    Code = h.Code,
                    Klas =  h.Klas,
                    Name = h.Name,
                    Dcng= h.Dcng,
                    Date= h.Date,
                    Lica = h.Lica,
                    Scre = h.Scre,
                    EmployeeId = h.Employee.UserName,
                    IsFileReady = h.IsFileReady,
                    Text = h.Text
        })
                .FirstAsync();
        }
        public async Task EditAsync(int fileId, FileFormModel model)
        {
            var seekFile = await repo.GetByIdAsync<BrsFile>(fileId);

            if (seekFile != null)
            {
                seekFile.Klas = model.Klas;
                seekFile.Name = model.Name;
                seekFile.Text = model.Text;
                seekFile.Scre = model.Scre;
                seekFile.Dcng = model.Dcng;
                seekFile.Date = model.Date;
                seekFile.Lica = model.Lica;
                seekFile.Time = DateTime.Now;
                seekFile.Dpos = DateTime.Now.AddDays(7);
                seekFile.IsFileReady = true;
                //DeptorOld след MINE да видя как ще се попълва TO DO
                seekFile.IsFindDeptor = true;

                await repo.SaveChangesAsync();
            }
        }

        public async Task<string> ExistsEmployeeIdWitrhIdAsync(int id)
        {
            var brsFile = await repo.GetByIdAsync<BrsFile>(id);

            return brsFile.EmployeeId;
        }

        public async Task DeleteBrsFileAsync(int fileId)
        {
            var brsFile = await repo.GetByIdAsync<BrsFile>(fileId);

            await repo.DeleteAsync<BrsFile>(brsFile.Id);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteTempHtmlByBrsFileIdAsync(int brsFileId)
        {
            var tempHtml = await repo.All<TempHtml>().FirstOrDefaultAsync(th=> th.BrsFileId == brsFileId);
            if (tempHtml != null)
            {
                repo.Delete<TempHtml>(tempHtml);
                await repo.SaveChangesAsync();
            }
        }
    }
}


