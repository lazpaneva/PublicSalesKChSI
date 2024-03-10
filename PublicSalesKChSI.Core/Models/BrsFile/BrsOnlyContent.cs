using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string[] Other { get; set; } = null!;

        [Column(TypeName = "ntext")] //променено за да може да събере текста от няколко html-a
        public string Text { get; set; } = null!;

        public string NameSI { get; set; } = null!; //name на съдебен изпълнител
        public string NumberSI { get; set; } = null!; //рег. № на съдебен изпълнител



        
    }
}
