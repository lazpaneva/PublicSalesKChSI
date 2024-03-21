﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Models.WorkingOnFiles
{
    public class FileServiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Код докум.")]
        public string Code { get; set; } = null!;

        [Display(Name = "Дата на публ.")]
        public string Dcng { get; set; } = null!;

        [Display(Name = "Класификатор за съда")]
        public string Klas { get; set; } = null!;


        [Display(Name = "Заглавие")]
        public string Name { get; set; } = null!;

        public string? UrlPdf { get; set; }

        [Display(Name = "Собственик/Длъжник")]
        public string? Lica { get; set; }

        [Display(Name = "Готов ли е")]
        public bool IsFileReady { get; set; }

    }
}
