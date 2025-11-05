using EVOpsPro.Repositories.KhiemNVD.Basic;
using EVOpsPro.Repositories.KhiemNVD.DBContext;
using EVOpsPro.Repositories.KhiemNVD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOpsPro.Repositories.KhiemNVD
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository()
        {
        }

        public SystemUserAccountRepository(FA25_PRN232_SE1713_G2_EVOpsProContext context) => _context = context;

        public async Task<SystemUserAccount> GetByUsernameAsync(string username, string password)
        {
            return await _context.SystemUserAccounts
                .FirstOrDefaultAsync(u => u.Email == username && u.Password == password && u.IsActive);

            return await _context.SystemUserAccounts
                .FirstOrDefaultAsync(u => u.Email == username && u.Password == password && u.IsActive);

            return await _context.SystemUserAccounts
                .FirstOrDefaultAsync(u => u.Phone == username && u.Password == password && u.IsActive);

            return await _context.SystemUserAccounts
                .FirstOrDefaultAsync(u => u.EmployeeCode == username && u.Password == password && u.IsActive);
        }

        public Task<List<SystemUserAccount>> GetActiveAsync()
        {
            return _context.SystemUserAccounts
                .Where(u => u.IsActive)
                .OrderBy(u => u.FullName)
                .ToListAsync();
        }
    }

}
