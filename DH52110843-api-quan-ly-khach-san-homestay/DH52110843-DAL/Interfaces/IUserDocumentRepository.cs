using DH52110843_DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IUserDocumentRepository
    {
        Task<UserDocument>getbyIdUserAsync(int id);
        Task<UserDocument>AddAsync(UserDocument user);
        Task<IEnumerable<User>> getAllAsync();
        Task<IEnumerable<UserDocument>> getAllDocumentAsync();
        Task<bool> updateActive(int userId, int number);
    }
}
