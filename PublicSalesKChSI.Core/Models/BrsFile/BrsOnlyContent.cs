using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Models.BrsFile
{
    public class BrsOnlyContent
    {
        public string Title { get; set; } = null!;
        public string Date { get; set; } = null!; 
        public string Price { get; set; } = null!;
        public List<string> Other { get; set; } = null!;
        public string NameSI { get; set; } = null!; //name на съдебен изпълнител
        public string NumberSI { get; set; } = null!; //рег. № на съдебен изпълнител



        
    }
}
