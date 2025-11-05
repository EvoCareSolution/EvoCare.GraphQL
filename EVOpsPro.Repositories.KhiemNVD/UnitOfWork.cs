using EVOpsPro.Repositories.KhiemNVD.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOpsPro.Repositories.KhiemNVD
{
    public interface IUnitOfWork
    {
        SystemUserAccountRepository UserAccountRepository { get; }
        ReminderKhiemNvdRepository ReminderRepository { get; }
        ReminderTypeKhiemNvdRepository ReminderTypeRepository { get; }
        int SaveChangeWithTransaction();
        Task<int> SaveChangeWithTransactionAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FA25_PRN232_SE1713_G2_EVOpsProContext _context;
        private SystemUserAccountRepository _userAccountRepository;
        private ReminderKhiemNvdRepository _reminderRepository;
        private ReminderTypeKhiemNvdRepository _reminderTypeRepository;

        public UnitOfWork() => _context ??= new FA25_PRN232_SE1713_G2_EVOpsProContext();

        public SystemUserAccountRepository UserAccountRepository
        {
            get { return _userAccountRepository ??= new SystemUserAccountRepository(_context); } 
        }

        public ReminderKhiemNvdRepository ReminderRepository
        {
            get { return _reminderRepository ??= new ReminderKhiemNvdRepository(_context); }
        }

        public ReminderTypeKhiemNvdRepository ReminderTypeRepository
        {
            get { return _reminderTypeRepository ??= new ReminderTypeKhiemNvdRepository(_context); }
        }

        public int SaveChangeWithTransaction()
        {
            int result = -1;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                } 
                catch (Exception)
                {
                    result = 1;
                    dbContextTransaction.Rollback();
                }
            }
            return result;
        }

        public async Task<int> SaveChangeWithTransactionAsync()
        {
            int result = -1;
            using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception)
                {
                    result = -1;
                    await dbContextTransaction.RollbackAsync();
                }
            }
            return result;
        }
    }
}
