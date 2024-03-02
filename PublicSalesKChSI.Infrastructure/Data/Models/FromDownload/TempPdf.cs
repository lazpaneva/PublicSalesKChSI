using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Infrastructure.Data.Models.FromDownload
{
    public class TempPdf
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
        public int TempHtmlId { get; set; }
        [ForeignKey(nameof(TempHtmlId))]
        public TempHtml TempHtml { get; set; } = null!;
    }
}
