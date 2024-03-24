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

        public async Task<DistributionWorkModel> GetUsersAndNotReadyCountFiles()
        //public DistributionWorkModel GetUsersAndNotReadyCountFiles(DistributionWorkModel distributionWorkModel)
        {
            ICollection<ApplicationUser> users = userManager.Users.ToList();

            DistributionWorkModel distributionWorkModel = new DistributionWorkModel()
            {
                EmployesNumbFiles = new List<EmplNumbFilesModel>(),
            };

            var notReadyFiles = await repo.All<BrsFile>()
                .Where(f => f.IsFileReady == false)
                .ToListAsync();
            distributionWorkModel.NotReadyFilesCount = notReadyFiles.Count();

            foreach (var user in users)
            {
                distributionWorkModel.EmployesNumbFiles.Add(new EmplNumbFilesModel
                {
                    EmplUserName = user.UserName,
                    EmplUserId = user.Id,
                    EmplFullName = user.FirstName + " " + user.LastName,
                });
            }
           
            return distributionWorkModel;
        }
        public async Task FillEmployeeIdInBrsFiles(DistributionWorkModel model)
        {
            foreach (var item in model.EmployesNumbFiles)
            {
                    var files = await repo.All<BrsFile>()
                      .Where(f => f.IsFileReady == false)
                      .Take(item.NumbFiles)
                      .ToListAsync();

                foreach (var file in files)
                {
                    file.EmployeeId = item.EmplUserId;
                    await repo.SaveChangesAsync();
                }
            }
        }
    }
}
