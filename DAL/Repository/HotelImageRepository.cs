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
    public class HotelImageRepository : IHotelImageRepository
    {
        private readonly HethonghotelContext db;
        public HotelImageRepository(HethonghotelContext db)
        {
            this.db = db;
        }
        public async Task addAsync(HotelImage image)
        {
            await db.HotelImages.AddAsync(image);
            await db.SaveChangesAsync();
        }

        public async Task deleteAsync(int id)
        {
            var hotelImage = await db.HotelImages.FindAsync(id);
            if (hotelImage == null)
            {
                throw new KeyNotFoundException($"Not found ImageHotel with ID {id}");
            }
            else
            {
                db.HotelImages.Remove(hotelImage);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<HotelImage>> GetAllHotelImagesAsync()
        {
            return await db.HotelImages.ToListAsync();
        }

        public async Task<IEnumerable<HotelImage>> GetImagesByIdHotel(int id)
        {
            return await db.HotelImages.Where(x=>x.HotelId==id).ToListAsync();
        }

        public async Task UpdateAsync(int id, HotelImage image)
        {
            var hotelImage = await db.HotelImages.FindAsync(id);
            if (hotelImage != null)
            {
                hotelImage.HotelId = image.HotelId;
                hotelImage.ImageId = image.ImageId;
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found ImageHotel with ID {id}");
            }
        }
    }
}
