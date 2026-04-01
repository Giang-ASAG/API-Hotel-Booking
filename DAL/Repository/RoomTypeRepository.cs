using DH52110843_DAL.Data;
using DH52110843_DAL.Interfaces;
using DH52110843_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HethonghotelContext db;
        public RoomTypeRepository(HethonghotelContext db)
        {
            this.db = db;
        }
        public async Task<RoomType> addAsync(RoomType roomType)
        {
            if(roomType == null)
            {
                throw new KeyNotFoundException($"RoomType = null");
            }
            await db.RoomTypes.AddAsync(roomType);
            await db.SaveChangesAsync();
            return roomType;
        }

        public async Task deleteAsync(int id)
        {
            var rt = await db.RoomTypes.FindAsync(id);
            if(rt == null) throw new KeyNotFoundException($"RoomType = null");
            else
            {
                var rooms = await db.Rooms.CountAsync(x=>x.RoomTypeId==rt.RoomTypeId);
                if (rooms > 0)
                {
                    throw new KeyNotFoundException($"Cant delete RoomType");
                }
                db.RoomTypes.Remove(rt);
                await db.SaveChangesAsync();
            }
        }

        public async Task<RoomType> findAsync(int id)
        {
            var rt = await db.RoomTypes.FindAsync(id);
            if (rt == null) throw new KeyNotFoundException($"RoomType = null");
            return rt;
        }


        public async Task<IEnumerable<RoomType>> getAllRoomTypeAsync()
        {
            return await db.RoomTypes.ToListAsync();
        }

        public async Task<IEnumerable<RoomType>> getAllRoomTypebyHotelIdAsync(int id)
        {
            return await db.RoomTypes.Where(x => x.HotelId == id).ToListAsync();
        }
        public async Task<IEnumerable<RoomType>> getAllRoomTypebyUserIdAsync(int id)
        {
            var result = from rt in db.RoomTypes
                         join ht in db.Hotels
                         on rt.HotelId equals ht.HotelId
                         join u in db.Users
                         on ht.UserId equals u.UserId
                         where u.UserId == id
                         select rt;
            return await result.ToListAsync();
        }

        public async Task<int> getCount(int id, bool status = false)
        {
            var count =  await (from r in db.Rooms join rt in db.RoomTypes
                        on r.RoomTypeId equals rt.RoomTypeId
                        where rt.RoomTypeId ==id && r.Status == status
                                select r).CountAsync();
            return  count;
        }

        public async Task<int> getCountSearch(int roomtypeid, DateTime checkin, DateTime checkout)
        {
            var result = await db.Rooms
                .Where(r => r.RoomTypeId == roomtypeid)
                .Where(r => !r.Bookingrooms.Any(br =>
                    !(checkout < br.Booking.CheckInDate || checkin > br.Booking.CheckOutDate)
                ))
                .CountAsync();

            return result;
        }


        public async Task<IEnumerable<RoomType>> searchRoomType(RoomTypeSearchRequest request)
        {
            var result = await (from ry in db.RoomTypes
                                join r in db.Rooms on ry.RoomTypeId equals r.RoomTypeId
                                join bk in db.Bookingrooms on r.RoomId equals bk.RoomId
                                join book in db.Bookings on bk.BookingId equals book.BookingId
                                where ry.HotelId == request.hotelId &&
                                      (
                                          r.Status == false ||
                                          (r.Status == true && request.CheckIn > book.CheckOutDate) || //ngay chon > ngay check out da duoc dat
                                          (r.Status == true && request.CheckOut < book.CheckInDate) 
                                      )
                                select ry).ToListAsync();
            return result.Distinct();
        }


        public async Task updateAsync(int id, RoomType roomType)
        {
            var rt = await db.RoomTypes.FindAsync(id);
            if (rt == null) throw new KeyNotFoundException($"RoomType = null");
            rt.TypeName = roomType.TypeName;
            rt.RoomInfo = roomType.RoomInfo;
            rt.Price = roomType.Price;
            rt.Capacity = roomType.Capacity;
            rt.HotelId = roomType.HotelId;
            await db.SaveChangesAsync();
        }
    }
}
