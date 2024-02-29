using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Infrastructure.Data.Models.FromDownload
{
    public class PdfTemp
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(PdfTempOriginalNameMax)]
        public string OriginalName { get; set; } = null!;

        [Required]
        [StringLength(PdfTempNameMax)]
        public string Name { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        [Range(PdfTempSizeOfFileMin, PdfTempSizeOfFileMax)]
        public int SizeOfFile { get; set; }

        [Required]
        public int HtmlTempId { get; set; }
        [ForeignKey(nameof(HtmlTempId))]
        public HtmlTemp HtmlTemp { get; set; } = null!;
    }
}
