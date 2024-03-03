using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
        [Comment("Can be city or village")]
        [StringLength(DeptorOldPlaceMax)]
        public string Place { get; set; } = null!;

        [Required]
        [Comment("0 for city and 1 for village")]
        [Range(DeptorOldTypePlaceMin, DeptorOldTypePlaceMax)]
        public int TypePlace { get; set; }

        [StringLength(DeptorOldSreetAndComplexMax)]
        public string? Sreet { get; set; }

        [StringLength(DeptorOldSreetNumberMax)]
        public string? SreetNumber { get; set; }

        [StringLength(DeptorOldSreetAndComplexMax)]
        public string? Complex { get; set; }

        [StringLength(DeptorOldBuildingAndEntranceMax)]
        public string? Building { get; set; }

        [StringLength(DeptorOldBuildingAndEntranceMax)]
        public string? Enrtance { get; set; }

        [StringLength(DeptorOldFloorMax)]
        public string? Floor { get; set; }

        [Range(DeptorOldAppartmentMin, DeptorOldAppartmentMax)]
        public int? Appartment { get; set; }

        [StringLength(DeptorOldTerrainAndPINumberMax)]
        public string? Terrain { get; set; }

        [StringLength(DeptorOldTerrainAndPINumberMax)]
        public string? PINumber { get; set; }

        [Required]
        [StringLength(DeptorOldCourtExtractFromKlasMax)]
        public string CourtExtractFromKlas { get; set; } = null!;

        [Required]
        [StringLength(DeptorOldDeptorsInfoMax)]
        public string DeptorsInfo { get; set; } = null!;
        public ICollection<BrsFile> BrsesFiles { get; set; } = new List<BrsFile>();
    }
}
