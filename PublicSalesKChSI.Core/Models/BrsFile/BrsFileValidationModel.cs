using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static PublicSalesKChSI.Infrastructure.Constants.DataConstants;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Models.BrsFile
{
    public class BrsFileValidationModel
    {

        [Required]
        [StringLength(BrsFileCodeMax, MinimumLength = BrsFileCodeMin, 
            ErrorMessage = StringLengthErrorMessage)]
        public string Code { get; set; } = null!;

        [Required]
        [StringLength(BrsFileKlasMax, MinimumLength = BrsFileKlasMin,
            ErrorMessage = StringLengthErrorMessage)]
        public string Klas { get; set; } = null!;

        [Required]
        [StringLength(DateLengthMax, MinimumLength = DateLengthMin, 
            ErrorMessage = StringLengthErrorMessage)]
        public string Dcng { get; set; } = null!;

        [Required]
        [StringLength(DateLengthMax, MinimumLength = DateLengthMin,
            ErrorMessage = StringLengthErrorMessage)]
        public string Date { get; set; } = null!;

        [Required]
        [StringLength(BrsFileNameMax, MinimumLength = BrsFileNameMin, 
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "ntext")] //променено за да може да събере текста от няколко html-a
        public string Text { get; set; } = null!;

        [Required]
        public bool IsFileReady { get; set; }

        [Required]
        public bool IsFindDeptor { get; set; }



    }
}
