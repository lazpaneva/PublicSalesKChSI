using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Models.WorkingOnFiles
{
    public class FileQueryServiceModel
    {
        public int TotalFilesCount { get; set; }
        public IEnumerable<FileServiceModel> Files { get; set; } = new List<FileServiceModel>();
    }
}
