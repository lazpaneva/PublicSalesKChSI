﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Contracts
{
    public interface IApplicationUserService
    {
        Task<string> UserFullName(string userId);
    }
}