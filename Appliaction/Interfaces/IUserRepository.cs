using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync (User poUser);
        Task<User?> GetUserByEmailAsync(string pcEmail);
    }
}
