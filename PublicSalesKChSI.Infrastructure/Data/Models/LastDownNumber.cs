using System.ComponentModel.DataAnnotations;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Infrastructure.Data.Models
{
    public class LastDownNumber
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [Required]
        [StringLength(LastDownNumberSaleTypeMax)]
        public string SaleType { get; set; } = null!;

        [Required]
        [Range(HtmlTempNumberInSiteMin, int.MaxValue)]
        public int LastNumber { get; set; }
    }
}
