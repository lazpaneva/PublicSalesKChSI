using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Models.WorkingOnFiles
{
    public class FileServiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Дата на публ.")]
        public string Dcng { get; set; } = null!;

        [Display(Name = "Класификатор за съда")]
        public string Klas { get; set; } = null!;


        [Display(Name = "Заглавие")]
        public string Name { get; set; } = null!;

        [Display(Name = "Собственик/Длъжник")]
        public string Lica { get; set; } = null!;

        [Display(Name = "Готов ли е")]
        public bool IsFileReady { get; set; }

    }
}
