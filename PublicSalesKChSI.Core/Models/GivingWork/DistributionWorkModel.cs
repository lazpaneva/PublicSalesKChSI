using PublicSalesKChSI.Core.Models.HtmlPdf;
using PublicSalesKChSI.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Models.GivingWork
{
    public class DistributionWorkModel
    {
        public int NotReadyFilesCount { get; set; }
        public int FilesToWorkForEmoloyee { get; set; }

        public string appUser { get; set; } = null!;

        public IEnumerable<EmployeeWithFullName> usersInfo { get; set; } = null!;
    }
}
