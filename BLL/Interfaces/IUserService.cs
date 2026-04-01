using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> getAllAsync();
        Task<UserDTO> findUserbyId(int id);
        Task AddAsync(UserDTO user);
        Task UpdateAsync(int id, UserNoPasswordDTO user);
        Task DeleteAsync(int id);
        Task UpdatePermissionAsync(int id);
        Task<UserDTO> FindUserByEmailAsync(string email);
        Task ActiveAsync(int id, bool active);
        Task<int[]> GetUserCountsByMonth();
    }
}
