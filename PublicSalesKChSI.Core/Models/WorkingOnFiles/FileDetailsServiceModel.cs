using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PublicSalesKChSI.Core.Models.WorkingOnFiles
{
    public class FileDetailsServiceModel : FileServiceModel
    {
        [Display(Name = "Код")]
        public string Code { get; set; } = null!;

        [Display(Name = "Отново дата на публ. (така е BRS-структурата)")]
        public string Date { get; set; } = null!;

        [Display(Name = "изп. дело")]
        public string? Scre { get; set; }

        [Display(Name = "Оператор")]
        public string? EmployeeId { get; set; }

        [Display(Name = "Текст")]
        public string Text { get; set; } = null!;
    }
}
