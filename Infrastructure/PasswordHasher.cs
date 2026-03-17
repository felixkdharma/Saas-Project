using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string CHASH(string pcPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(pcPassword);
        }

        public bool LVERIFY(string pcPassword, string pcHashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(pcPassword, pcHashPassword);
        }
    }
}
