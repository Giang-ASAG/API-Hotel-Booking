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
    public class HotelServiceRepository : IHotelServiceRepository
    {
        private readonly HethonghotelContext db;
        public HotelServiceRepository(HethonghotelContext db)
        {
            this.db=db;
        }
        public async Task addAsync(HotelService hotelService)
        {
            await db.HotelServices.AddAsync(hotelService);
            await db.SaveChangesAsync();
        }

        public async Task deleteAsync(int id)
        {
            var hs = await db.HotelServices.FindAsync(id);
            if (hs != null)
            {
                db.HotelServices.Remove(hs);
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found HotelService");
            }

        }

        public async Task<HotelService> findByIdAsync(int id)
        {
            var hs = await db.HotelServices.FindAsync(id);
            if (hs != null)
            {
                return hs;
            }
            else
            {
                throw new KeyNotFoundException($"Not found HotelService");
            }

        }

        public async Task<IEnumerable<HotelService>> getHotelServiceAsync()
        {
            return await db.HotelServices.ToListAsync();
        }

        public async Task<IEnumerable<HotelService>> getHotelServicebyIdHotelAsync(int id)
        {
            return await db.HotelServices.Where(x=>x.HotelId==id).ToListAsync();
        }

        public async Task<IEnumerable<HotelService>> getHotelServicebyIdUserAsync(int id)
        {
            var result =  from s in db.HotelServices
                         join ht in db.Hotels on s.HotelId equals ht.HotelId
                         //join u in db.Users on ht.UserId equals u.UserId
                         where ht.UserId == id
                         select s;
            return await result.ToListAsync();
        }

        public async Task updateAsync(int id, HotelService hotelService)
        {
            var hs = await db.HotelServices.FindAsync(id);
            if (hs != null)
            {
                hs.ServiceName = hotelService.ServiceName;
                hs.ServiceInfo = hotelService.ServiceInfo;
                hs.HotelId = hotelService.HotelId;
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found HotelService");
            }

        }
    }
}
