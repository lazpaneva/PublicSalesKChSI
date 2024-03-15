using PublicSalesKChSI.Core.Models.BrsFile;
using PublicSalesKChSI.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Contracts
{
    public interface IBrsFileService
    {
        //public Task<List<BrsOnlyContent>> FillBrsFile(string userId);
        public Task<IEnumerable<BrsFileValidationModel>> FillBrsFile(string userId);
    }
}
