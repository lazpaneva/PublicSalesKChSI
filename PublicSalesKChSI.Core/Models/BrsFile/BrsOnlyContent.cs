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
        [Column(TypeName = "ntext")]
        public string? Text { get; set; }
    }
}
