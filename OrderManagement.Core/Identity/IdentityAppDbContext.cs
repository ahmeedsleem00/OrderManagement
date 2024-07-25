using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Identity
{
    public class IdentityAppDbContext : IdentityUser
    {
        public string Role { get; set; }

    }
}
