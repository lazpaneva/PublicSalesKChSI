using PublicSalesKChSI.Core.Models.HtmlPdf;
using PublicSalesKChSI.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Models.GivingWork
{
    public class DistributionWorkModel
    {
        public int NotReadyFilesCount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Трябва да бъде положително число")]
        [FilesToWorkForEmoloyeeLessThanNotReadyFilesCount(ErrorMessage = "Трябва да бъде по-малко от общия брой файлове за работа")]
        public int FilesToWorkForEmoloyee { get; set; }
        [Required]
        public string appUser { get; set; } = null!;

        public IEnumerable<EmployeeWithFullName> usersInfo { get; set; } = null!;

        public class FilesToWorkForEmoloyeeLessThanNotReadyFilesCountAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var model = (DistributionWorkModel)validationContext.ObjectInstance;
           
                if (model.FilesToWorkForEmoloyee > model.NotReadyFilesCount)
                {
                    return new ValidationResult("Трябва да бъде по-малко от общия брой файлове за работа");
                }

                return ValidationResult.Success;
            }
        }
    }
}
