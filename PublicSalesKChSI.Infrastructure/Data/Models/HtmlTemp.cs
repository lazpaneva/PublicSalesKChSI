using System.ComponentModel.DataAnnotations;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Infrastructure.Data.Models
{
    public class HtmlTemp
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Range(HtmlTempNumberInSiteMin, int.MaxValue)]
        public int NumberInSite { get; set; }

        //Да го видя как да бъде
        public int BrsFileId { get; set; }

    }
}
