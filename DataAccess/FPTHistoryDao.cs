using BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FPTHistoryDao : SingletonBase<FPTHistoryDao>
    {
        public async Task<IEnumerable<FPTHistory>> GetFPTHistoryAll()
        {
            return await _context.FPTHistories.ToListAsync();
        }
        public async Task<FPTHistory> GetFPTHistoryById(int id)
        {
            var fpthistory = await _context.FPTHistories.FirstOrDefaultAsync(c => c.FPTHistoryId == id);
            if (fpthistory == null) return null;
            return fpthistory;
        }
        public async Task Add(FPTHistory fpthistory)
        {
            await _context.FPTHistories.AddAsync(fpthistory);
            await _context.SaveChangesAsync();
        }
        public async Task Update(FPTHistory fpthistory)
        {
            var existingItem = await GetFPTHistoryById(fpthistory.FPTHistoryId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(fpthistory);

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var fpthistory = await GetFPTHistoryById(id);
            if (fpthistory != null)
            {
                _context.FPTHistories.Remove(fpthistory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FPTHistory>> GetFPTHistoryByTitle(string name)
        {
            var fpthistory = _context.FPTHistories;
            return await fpthistory.Where(u => u.Title.Contains(name)).ToListAsync();
        }
    }
}
