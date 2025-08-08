using DH52110843_DAL.Data;
using DH52110843_DAL.Interfaces;
using DH52110843_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HethonghotelContext db;
        public UserRepository(HethonghotelContext db)
        {
            this.db = db;
        }
        public async Task AddAsync(User user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await db.Users.FindAsync(id);
            if(user != null)
            {
                if(user.UserRoleId == 2)
                {
                    var b = await db.Bookings.FirstOrDefaultAsync(h => h.UserId == user.UserId);
                    if (b != null)
                    {
                        throw new KeyNotFoundException($"Cannt delete User with ID {id}");
                    }
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                }
                else if(user.UserRoleId == 3)
                {
                    var h = await db.Hotels.FirstOrDefaultAsync(h => h.UserId == user.UserId);
                    if (h != null)
                    {
                        throw new KeyNotFoundException($"Cannt delete User with ID {id}");
                    }
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                }

            }
            else
            {
                throw new KeyNotFoundException($"Not found User with ID {id}");
            }

        }

        public async Task<User> findUserbyId(int id)
        {
            var user = await db.Users.FindAsync(id);
            if(user == null)
            {
                throw new KeyNotFoundException($"Not found User with ID {id}");
            }
            else
            {
                return user;
            }

        }
        public async Task<User> FindUserByEmailAsync(string email)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<IEnumerable<User>> getAllAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<int[]> GetUserCountsByMonth()
        {
            int[] counts = new int[12];
            var users = await db.Users.Select(x=>x.CreationDate).ToListAsync();

            foreach (var item in users)
            {
                int month = item.Value.Month;
                counts[month - 1]++;
            }
            return counts;
        }

        public async Task UpdateAsync(int id,User user)
        {
            var u = await db.Users.FindAsync(id);
            if(u != null)
            {
                
                u.FullName = user.FullName;
                u.Address = user.Address;
                u.PhoneNumber = user.PhoneNumber;
                if (user.UserRoleId > 0)
                {
                    u.UserRoleId = user.UserRoleId;
                }
                u.Active = user.Active;
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found User with ID {id}");
            }
        }
        public async Task UpdatePermissionAsync(int id)
        {
            var u = await db.Users.FirstOrDefaultAsync(x=>x.UserId== id);
            if (u != null)
            {
                u.UserRoleId = 3;
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found User with ID {id}");
            }
        }

        public async Task ActiveAsync(int id, bool active)
        {
            var u = await db.Users.FindAsync(id);
            if (u == null)
            {
                throw new KeyNotFoundException($"Not found User with ID {id}");
            }
            u.Active = active; await db.SaveChangesAsync();
        }
    }
}
