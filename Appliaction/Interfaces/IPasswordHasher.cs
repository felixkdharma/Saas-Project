using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPasswordHasher
    {
        //hashing password
        string CHASH(string pcPassword);
        //input password == hashed password
        bool LVERIFY(string pcPassword, string pcHashPassword);
    }
}
