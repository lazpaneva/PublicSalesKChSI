using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Infrastructure.Data;
using PublicSalesKChSI.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicSalesKChSI.Infrastructure.Data.Models;
using PublicSalesKChSI.Core.Models.GivingWork;
using Microsoft.EntityFrameworkCore;

namespace PublicSalesKChSI.Core.Services
{
    public class GivingWorkService : IGivingWorkService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository repo;
        public GivingWorkService(IRepository _repo, UserManager<ApplicationUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        public async Task<int> GetNotReadyCountFiles()
        {
            var notReadyFiles = await repo.All<BrsFile>()
                .Where(f => f.IsFileReady == false && f.IsGivenFitstTime == false)
                .ToListAsync();
            int notReadyFilesCount = notReadyFiles.Count();
            return notReadyFilesCount;
        }
        public async Task FillEmployeeIdInBrsFiles(DistributionWorkModel model)
        {
            var files = await repo.All<BrsFile>()
                .Where(f=> f.IsFileReady == false && f.IsGivenFitstTime == false)
                .Take(model.FilesToWorkForEmoloyee)
                .ToListAsync();

            foreach (var file in files)
                {
                    file.EmployeeId = model.appUser;
                    file.IsGivenFitstTime = true;
                    await repo.SaveChangesAsync();
                }
        }

        //public async Task<ICollection<ApplicationUser>> GetFullUsers()
        //{
        //    ICollection<ApplicationUser> users = await userManager.Users.ToListAsync();

        //    return users;
        //}

        public async Task<ICollection<EmployeeWithFullName>> GetFullUsers()
        {
            ICollection<EmployeeWithFullName> users = await userManager.Users
                .Select(u=> new EmployeeWithFullName { 
                    EmplUserId = u.Id,
                    EmplUserName = u.UserName,
                    EmplFullName = u.FirstName + " " + u.LastName
                }
                )
                .ToListAsync();

            return users;
        }
    }
}
