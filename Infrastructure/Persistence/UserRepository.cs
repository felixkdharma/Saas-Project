using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User poUser)
        {
            await _context.Users.AddAsync(poUser);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string pcEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.CEMAIL == pcEmail);
        }
    }
}
