using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IUserDocumentService
    {
        Task<UserDocumentDTO> addAsync(UserDocumentDTO userDocumentDTO);
        Task<UserDocumentDTO> getbyUserId(int id);
        Task<IEnumerable<UserDTO>> getAllAsync();
        Task<IEnumerable<UserDocumentDTO>> getAllDocumentAsync();
        Task<bool> updateActive(int userId, int number);
    }
}
