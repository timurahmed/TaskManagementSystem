using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class UserBusiness : IDisposable
    {
        TaskManagerDbContext _context;
        public UserBusiness()
        {
            _context = new TaskManagerDbContext();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Tasks)
                .Include(u => u.Events)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async System.Threading.Tasks.Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(User user)
        {
            var item = await _context.Users.FindAsync(user.Id);
            if(item != null)
            {
                _context.Entry(item).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task RemoveAsync(User user)
        {
            var item = await _context.Users.FindAsync(user.Id);
            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
