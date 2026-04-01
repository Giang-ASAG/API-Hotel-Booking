using DH52110843_DAL.Data;
using DH52110843_DAL.Interfaces;
using DH52110843_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Repository
{
    public class UserDocumentRepository : IUserDocumentRepository
    {
        private readonly HethonghotelContext db;
        public UserDocumentRepository(HethonghotelContext db)
        {
            this.db = db;
        }

        public async Task<UserDocument> AddAsync(UserDocument user)
        {
            if(user == null) throw new ArgumentNullException("user");
            await db.UserDocuments.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> getAllAsync()
        {
            var result = from u in db.Users join d in db.UserDocuments
                         on u.UserId equals d.UserId
                         where d.Active == 0
                         select u;
            if (result != null)
            {
                return await result.ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserDocument>> getAllDocumentAsync()
        {
            var result = await db.UserDocuments.ToListAsync();
            return result;
        }

        public async Task<UserDocument> getbyIdUserAsync(int id)
        {
            var result = await db.UserDocuments.FirstOrDefaultAsync(x=>x.UserId==id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> updateActive(int userId, int number)
        {
            var result = await db.UserDocuments.FirstOrDefaultAsync(x => x.UserId == userId);
            if(result!= null)
            {
                if (number == 2)
                {
                    db.UserDocuments.Remove(result);
                    await db.SaveChangesAsync();
                    return true;
                }
                result.Active = number;
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
