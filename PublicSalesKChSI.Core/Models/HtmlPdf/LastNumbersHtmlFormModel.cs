﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

namespace PublicSalesKChSI.Core.Models.HtmlPdf
{
    public class LastNumbersHtmlFormModel
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

        //private int ReturnLastNumber() => BeforeLastNumberAsset;
        [Required]
        [Range(HtmlTempNumberInSiteMin, int.MaxValue, ErrorMessage = ValueRangeErrorMessage)]
        public int LastNumberAsset { get; set; }

        [Required]
        [Range(HtmlTempNumberInSiteMin, int.MaxValue, ErrorMessage = ValueRangeErrorMessage)]
        public int LastNumberVechicle { get; set; }

        [Required]
        [Range(HtmlTempNumberInSiteMin, int.MaxValue, ErrorMessage = ValueRangeErrorMessage)]
        public int LastNumberProperties { get; set; }
    }
}
