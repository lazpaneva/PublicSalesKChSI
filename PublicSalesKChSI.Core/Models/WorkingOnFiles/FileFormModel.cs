using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PublicSalesKChSI.Core.Models.WorkingOnFiles
{
    public class FileFormModel
    {

        [Required]
        [StringLength(BrsFileKlasMax, MinimumLength = BrsFileKlasMin,
            ErrorMessage = StringLengthErrorMessage)]
        public string Klas { get; set; } = null!;

        [Required]
        [StringLength(DateLengthMax, MinimumLength = DateLengthMin,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Дата на публикуване")]
        public string Dcng { get; set; } = null!;

        [Required]
        [StringLength(DateLengthMax, MinimumLength = DateLengthMin,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Отново дата на публикуване /така е в BRS-структурата/")]
        public string Date { get; set; } = null!;

        [Required]
        [StringLength(BrsFileNameMax, MinimumLength = BrsFileNameMin,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required]
        public string Text { get; set; } = null!;

        [StringLength(BrsFileScreMax, MinimumLength = BrsFileScreMin,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "№ на изп. дело")]
        public string? Scre { get; set; }

        [StringLength(BrsFileLicaMax, MinimumLength = BrsFileLicaMin,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Име и ЕГН на длъжници")]
        public string? Lica { get; set; }
    }
}
