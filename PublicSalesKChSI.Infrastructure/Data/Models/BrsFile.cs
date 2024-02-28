using System.ComponentModel.DataAnnotations;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Infrastructure.Data.Models
{
    public class BrsFile
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public string Klas { get; set; } = null!;

        [Required]
        public string Dcng { get; set; } = null!;

        [Required]
        public string Date { get; set; } = null!;

        [Required] 
        public string Time { get; set; } = null!;

        [Required]
        public string Dpos { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Published { get; set; } = null!;

        [Required]
        public string Price { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string Court { get; set; } = null!;

        [Required]
        public string EndDate { get; set; } = null!;

        [Required]
        public string SaleDate { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        public double Area { get; set; }

        [Required]
        public string Text { get; set; } = null!;

        public string? Scre { get; set; }

        public string? Lica { get; set; }

        public string? Telf { get; set; }

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