﻿using PublicSalesKChSI.Core.Models.BrsFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Contracts
{
    public interface IBrsFileService
    {
        public List<BrsOnlyContent> FillBrsFile();
    }
}
