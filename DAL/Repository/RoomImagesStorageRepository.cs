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
    public class RoomImagesStorageRepository : IRoomImagesStorageRepository
    {
        private readonly HethonghotelContext db;
        public RoomImagesStorageRepository(HethonghotelContext db)
        {
            this.db = db;
        }
        public async Task addAsync(RoomImagesStorage storage)
        {
            await db.RoomImagesStorages.AddAsync(storage);
            await db.SaveChangesAsync();
        }

        public async Task deleteAsync(int id)
        {
            var s = await db.RoomImagesStorages.FindAsync(id);
            if (s == null) throw new KeyNotFoundException("RoomImagesStorage not found");
            db.RoomImagesStorages.Remove(s);
            await db.SaveChangesAsync();
        }

        public async Task<RoomImagesStorage> findAsync(int id)
        {
            return await db.RoomImagesStorages.FindAsync(id);
        }

        public async Task<IEnumerable<RoomImagesStorage>> getAllAsync()
        {
            return await db.RoomImagesStorages.ToListAsync();
        }

        public async Task updateAsync(int id, RoomImagesStorage storage)
        {
            var s = await db.RoomImagesStorages.FindAsync(id);
            if (s == null) throw new KeyNotFoundException("RoomImagesStorage not found");
            s.ImagePath = storage.ImagePath;
            await db.SaveChangesAsync();
        }
    }
}
