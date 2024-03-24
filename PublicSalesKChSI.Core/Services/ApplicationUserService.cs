using PublicSalesKChSI.Core.Contracts;
using PublicSalesKChSI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Core.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly PublicSalesDbContext _data;
        public ApplicationUserService(PublicSalesDbContext data)
        {
            _data = data;
        }
        public async Task<string?> UserFullName(string userId)
        {
            var user = await _data.Users.FindAsync(userId);
            if (string.IsNullOrEmpty(user.FirstName)
                || string.IsNullOrEmpty(user.LastName)) 
            { 
                return null; 
            }

            return user.FirstName + " " + user.LastName;
        }
    }
}
