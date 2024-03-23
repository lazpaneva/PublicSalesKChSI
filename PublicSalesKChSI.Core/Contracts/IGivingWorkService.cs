using Microsoft.AspNetCore.Identity;
using PublicSalesKChSI.Core.Models.GivingWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Contracts
{
    public interface IGivingWorkService
    {
        public DistributionWorkModel GetUsersAndNotReadyCountFiles(DistributionWorkModel model);
        Task FillEmployeeIdInBrsFiles(DistributionWorkModel model);
    }
}
