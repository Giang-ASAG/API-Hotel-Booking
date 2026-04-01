using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> getAllAsync();
        Task<User> findUserbyId(int id);
        Task AddAsync(User user);
        Task UpdateAsync(int id, User user);
        Task DeleteAsync(int id);
        Task UpdatePermissionAsync(int id);
        Task<User> FindUserByEmailAsync(string email);

        Task ActiveAsync(int id, bool active);

        Task<int[]> GetUserCountsByMonth();
    }
}
