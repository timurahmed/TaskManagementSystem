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
    internal class TaskBusiness : IDisposable
    {
        TaskManagerDbContext _context;
        public TaskBusiness()
        {
            _context = new TaskManagerDbContext();
        }

        public async Task<List<Data.Models.Task>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Data.Models.Task> GetAsync(int id)
        {
            return await _context.Tasks
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async System.Threading.Tasks.Task AddAsync(Data.Models.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Data.Models.Task task)
        {
            var item = await _context.Tasks.FindAsync(task);
            if (item != null)
            {
                _context.Entry(item).CurrentValues.SetValues(task);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task RemoveAsync(Data.Models.Task task)
        {
            var item = await _context.Tasks.FindAsync(task);
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
