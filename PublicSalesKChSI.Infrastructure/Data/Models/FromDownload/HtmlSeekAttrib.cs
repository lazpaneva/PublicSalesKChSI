using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Infrastructure.Data.Models.FromDownload
{
    public class HtmlSeekAttrib
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(DateLengthMax)]
        public string Published { get; set; } = null!;

        [Required]
        [StringLength(HtmlSeekAttribPriceMax)]
        public string Price { get; set; } = null!;

        [Column(TypeName = "decimal(14,2)")]
        public double? Area { get; set; }

        [Required]
        [Range(HtmlSeekAttribTypeSeekObjMin, HtmlSeekAttribTypeSeekObjMax)]
        public int TypeSaleObj { get; set; }

        [Required]
        [StringLength(HtmlSeekAttribCityMax)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(HtmlSeekAttribCourtMax)]
        public string Court { get; set; } = null!;

        [Required]
        [StringLength(DateLengthMax)]
        public string EndDate { get; set; } = null!;

        [Required]
        [StringLength(DateLengthMax)]
        public string SaleDate { get; set; } = null!;

        [Required]
        [StringLength(HtmlSeekAttribAddressMax)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(HtmlSeekAttribReceiverMax)]
        public string Receiver { get; set; } = null!;

        [Required]
        [StringLength(HtmlSeekAttribPropertyNumMax)]
        public string PropertyNum { get; set; } = null!;

        [Required]
        public int HtmlTempId { get; set; }
        [ForeignKey(nameof(HtmlTempId))]
        public HtmlTemp HtmlTemp { get; set; } = null!;

    }
}
