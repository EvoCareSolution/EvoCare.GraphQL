using EVOpsPro.Repositories.KhiemNVD;
using EVOpsPro.Repositories.KhiemNVD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOpsPro.Servcies.KhiemNVD
{
    public class SystemUserAccountService
    {

        private readonly IUnitOfWork _unitOfWork;
        public SystemUserAccountService() => _unitOfWork = new UnitOfWork();
        public async Task<SystemUserAccount> GetUserAccount(string username, string password)
        {
            try
            {
                return await _unitOfWork.UserAccountRepository.GetByUsernameAsync(username, password);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<SystemUserAccount>> GetActiveUsersAsync()
        {
            return _unitOfWork.UserAccountRepository.GetActiveAsync();
        }
    }
}
