using Microsoft.AspNetCore.Identity;
using PublicSalesKChSI.Core.Models.GivingWork;
using PublicSalesKChSI.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Contracts
{
    public interface IGivingWorkService
    {
        Task<int> GetNotReadyCountFiles();
        Task FillEmployeeIdInBrsFiles(DistributionWorkModel model);

        Task<ICollection<EmployeeWithFullName>> GetFullUsers();
    }
}
