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
    public class HotelImageStorageRepository : IHotelImageStorageRepository
    {
        private readonly HethonghotelContext db;
        public HotelImageStorageRepository(HethonghotelContext db)
        {
            this.db= db;
        }
        public async Task<HotelImagesStorage> addAsync(HotelImagesStorage hotelImagesStorage)
        {
            if (hotelImagesStorage == null)
            {
                throw new KeyNotFoundException($"hotelImagesStorage = null");
            }
            await db.HotelImagesStorages.AddAsync(hotelImagesStorage);
            var result = await db.SaveChangesAsync();
            return hotelImagesStorage;
        }

        public async Task deleteAsync(int id)
        {
            var his =await db.HotelImagesStorages.FindAsync(id);
            if(his == null)
            {
                throw new KeyNotFoundException($"Not found Image with ID {id}");
            }
            db.HotelImagesStorages.Remove(his);
            await db.SaveChangesAsync();
        }

        public async Task<HotelImagesStorage> findAsync(int id)
        {
            var h = await db.HotelImagesStorages.FindAsync(id);
            if(h == null)
            {
                throw new KeyNotFoundException($"Not found Image with ID {id}");
            }
            return h;
        }

        public async Task<IEnumerable<HotelImagesStorage>> GetHotelImagesStorageAsync()
        {
            return await db.HotelImagesStorages.ToListAsync();
        }

        public async Task updateAsync(int id, HotelImagesStorage hotelImagesStorage)
        {
            var h = await db.HotelImagesStorages.FindAsync(id);
            if (h == null)
            {
                throw new KeyNotFoundException($"Not found Image with ID {id}");
            }
            h.ImagePath = hotelImagesStorage.ImagePath;
            await db.SaveChangesAsync();
        }
    }
}
