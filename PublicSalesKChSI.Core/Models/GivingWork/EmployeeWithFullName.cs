using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Models.GivingWork
{
    public class EmployeeWithFullName
    {
        public string EmplFullName { get; set; } = null!;
        public string EmplUserName { get; set; } = null!;
        public string EmplUserId { get; set; } = null!;
    }
}
