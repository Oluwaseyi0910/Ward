using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalKiddiesWard.Data.Models
{
    public  class User : IdentityUser<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
