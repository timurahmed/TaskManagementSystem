using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    internal class EventBusiness : IDisposable
    {
        TaskManagerDbContext _context;
        public EventBusiness()
        {
            _context = new TaskManagerDbContext();
        }

        public async Task<List<Event>> GetAllAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetAsync(int id)
        {
            return await _context.Events
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async System.Threading.Tasks.Task AddAsync(Event e)
        {
            await _context.Events.AddAsync(e);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Event e)
        {
            var item = await _context.Users.FindAsync(e.Id);
            if (item != null)
            {
                _context.Entry(item).CurrentValues.SetValues(e);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task RemoveAsync(Event e)
        {
            var item = await _context.Users.FindAsync(e.Id);
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