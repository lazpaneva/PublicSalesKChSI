using System.ComponentModel.DataAnnotations;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Infrastructure.Data.Models
{
    public class DeptorOld
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(DeptorOldNameMax)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DeptorOldCourtExtractFromKlasMax)]
        public string CourtExtractFromKlas { get; set; } = null!;

        [Required]
        [StringLength(DeptorOldDeptorsInfoMax)]
        public string DeptorsInfo { get; set; } = null!;
    }
}
