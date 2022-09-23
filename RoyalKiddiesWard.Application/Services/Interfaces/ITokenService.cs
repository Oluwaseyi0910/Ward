using RoyalKiddiesWard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalKiddiesWard.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user, List<string> roles);
    }
}
