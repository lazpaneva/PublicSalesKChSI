using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Infrastructure.Data.Models.FromDownload
{
    public class TempHtml
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; } = null!;

        [Required]
        [Column(TypeName = "ntext")] //string не можеше да побере съдържанието на html-a
        public string Content { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Range(HtmlTempNumberInSiteMin, int.MaxValue)]
        public int NumberInSite { get; set; }

        public int? BrsFileId { get; set; }
        [ForeignKey(nameof(BrsFileId))]
        public BrsFile? BrsFile { get; set; } = null!;

    }
}
