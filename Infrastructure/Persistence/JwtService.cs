using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class JwtService : IJWTService
    {
        public string GenerateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
