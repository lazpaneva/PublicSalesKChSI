﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Contracts
{
    public interface IHtmlPdfService
    {
        Task<int[]> GetLastNumbers();
    }
}