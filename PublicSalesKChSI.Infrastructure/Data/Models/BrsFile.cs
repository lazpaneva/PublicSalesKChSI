using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Infrastructure.Data.Models
{
    public class BrsFile
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(BrsFileCodeMin, BrsFileCodeMax)]
        public int Code { get; set; }

        [Required]
        [StringLength(BrsFileKlasMax)]
        public string Klas { get; set; } = null!;

        [Required]
        public DateOnly Dcng { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        [Comment("to be fill when file is Ready again")]
        public DateOnly Time { get; set; }

        [Required]
        public DateOnly Dpos { get; set; } 

        [Required]
        [StringLength(BrsFileNameMax)]
        public string Name { get; set; } = null!;

        [Required]
        public string Text { get; set; } = null!;

        [Required]
        public bool IsFindDeptor { get; set; }

        [StringLength(BrsFileScreMax)]
        public string? Scre { get; set; }

        [StringLength(BrsFileLicaMax)]
        public string? Lica { get; set; }

        [StringLength(BrsFileTelfMax)]
        public string? Telf { get; set; }
                
        public string EmployeeId { get; set; } = null!;
        [ForeignKey(nameof(EmployeeId))]
        public IdentityUser Employee { get; set; } = null!;
    }
}

/* 
..CODE:
..KLAS:
KSI22_11
..DCNG:
20240202
..DPOS:
..TIME:
20240311
..NAME:
Па░╢ел, на╖. ╢ена 6 168.24 лв., 919.00 кв. м., ▒. Д░а╕кова пол┐на, 
об╣. Ап░ил╢и, ме▒▓н. Копак║▓
..TEXT:

SCRE - попълва се от оператор, ако мога да го извличам от текста
Lica
Telf - в бъдеще, или сега да го попълвам както е в Telf отпреди

 */