using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Core.Models.HtmlPdf
{
    public class LastNumbersHtmlViewModel
    {
        [Required]
        [Comment("Взима id=1 от таблица LastDownNumber")]
        public int BeforeLastNumberAsset { get; set; }

        [Required]
        [Comment("Взима id=2 от таблица LastDownNumber")]
        public int BeforeLastNumberVechicle { get; set; }

        [Required]
        [Comment("Взима id=3 от таблица LastDownNumber")]
        public int BeforeLastNumberProperties { get; set; }
    }
}

