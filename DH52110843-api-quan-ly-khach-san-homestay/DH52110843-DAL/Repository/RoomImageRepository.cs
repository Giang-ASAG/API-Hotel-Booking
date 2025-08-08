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
    public class RoomImageRepository : IRoomImageRepository
    {
        private readonly HethonghotelContext db;
        public RoomImageRepository(HethonghotelContext db)
        {
            this.db = db;
        }
        public async Task addAsync(RoomImage roomImage)
        {
            await db.RoomImages.AddAsync(roomImage);
            await db.SaveChangesAsync();
        }

        public async Task deleteAsync(int id)
        {
            var i = await db.RoomImages.FindAsync(id);
            if (i == null)
            {
                throw new KeyNotFoundException($"Not found ImageRoom with ID {id}");
            }
            db.RoomImages.Remove(i);
            await db.SaveChangesAsync();
        }

        public async Task<RoomImage> findImageAsync(int id)
        {
            var i = await db.RoomImages.FindAsync(id);
            if (i == null)
            {
                throw new KeyNotFoundException($"Not found ImageRoom with ID {id}");
            }
            return i;
        }

        public async Task<IEnumerable<RoomImage>> getAllImagebyRoomIdAsync(int id)
        {
            return await db.RoomImages.Where(x=>x.RoomTypeId == id).ToListAsync();
        }

        public async Task<IEnumerable<RoomImage>> getAllImagesAsync()
        {
            return await db.RoomImages.ToListAsync();
        }

        public async Task updateAsync(int id, RoomImage roomImage)
        {
            var i = await db.RoomImages.FindAsync(id);
            if (i == null)
            {
                throw new KeyNotFoundException($"Not found ImageRoom with ID {id}");
            }
            else
            {
                i.RoomTypeId = roomImage.RoomTypeId;
                i.ImageId = roomImage.ImageId;
                await db.SaveChangesAsync();
            }
        }
    }
}
