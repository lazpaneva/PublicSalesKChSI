using System.ComponentModel.DataAnnotations;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Infrastructure.Data.Models
{
    public class Court
    {
        [Key]
        [Required]
        public int Id { get; init; }

        [Required]
        [StringLength(CourtTownMax)]
        public string Town { get; set; } = null!;

        [Required]
        [StringLength(CourtNumberMax)]
        public string Number { get; set; } = null!;
    }
}
