using PublicSalesKChSI.Core.Models.HtmlPdf;
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
        public ICollection<EmplNumbFilesModel> EmployesNumbFiles { get; set; } 
            = new List<EmplNumbFilesModel>();

    }
}
