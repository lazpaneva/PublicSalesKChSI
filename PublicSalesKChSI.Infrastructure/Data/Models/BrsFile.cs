using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PublicSalesKChSI.Infrastructure.Data.Models.FromDownload;
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
        [StringLength(BrsFileCodeMax)]
        public string Code { get; set; } = null!;

        [Required]
        [StringLength(BrsFileKlasMax)]
        public string Klas { get; set; } = null!;

        [Required]
        [StringLength(DateLengthMax)]
        public string Dcng { get; set; } = null!;

        [Required]
        [StringLength(DateLengthMax)]
        public string Date { get; set; } = null!;

        [Comment("to be fill when file is Ready again")]
        public DateTime? Time { get; set; }

        [Comment("to be fill when file is Ready again")]
        public DateTime? Dpos { get; set; } 

        [Required]
        [StringLength(BrsFileNameMax)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "ntext")] //променено за да може да събере текста от няколко html-a
        public string Text { get; set; } = null!;

        [Required]
        public bool IsFileReady { get; set; }

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
        //foreign key - по конвенция https://learn.microsoft.com/en-us/ef/core/modeling/relationships/conventions
        public int? DeptorOldID { get; set; } 
        public DeptorOld? DeptorOld { get; set; }
        public ICollection<TempHtml> HtmlFiles { get; set; } =
            new List<TempHtml>();
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