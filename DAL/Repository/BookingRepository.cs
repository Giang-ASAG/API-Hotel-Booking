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
    public class BookingRepository : IBookingRepository
    {
        private readonly HethonghotelContext db;
        public BookingRepository(HethonghotelContext db)
        {
            this.db = db;
        }

        public async Task<Booking> addBookingAsync(Booking booking)
        {
            if (booking == null) throw new KeyNotFoundException("Booking null");
            await db.Bookings.AddAsync(booking);
            await db.SaveChangesAsync();
            return booking;
        }

        public async Task<Bookingroom> addBookingRoomAsync(Bookingroom booking)
        {
            if (booking == null) throw new KeyNotFoundException("Booking null");
            await db.Bookingrooms.AddAsync(booking);
            await db.SaveChangesAsync();
            return booking;
        }

        public async Task deleteBookingRoom(int bookingid)
        {
            // 1. Lấy danh sách BookingRoom trước
            var list = await db.Bookingrooms.Where(x => x.BookingId == bookingid).ToListAsync();

            // 2. Cập nhật trạng thái phòng về false
            var roomIds = list.Select(item => item.RoomId).ToList();
            
            var rooms = await db.Rooms.Where(x=>roomIds.Contains(x.RoomId)).ToListAsync();

            foreach (var room in rooms)
            {
                room.Status = false;
            }
            await db.SaveChangesAsync();
            // 3. Xóa BookingRoom trước
            db.Bookingrooms.RemoveRange(list);
            await db.SaveChangesAsync(); // Bắt buộc save ở đây để đảm bảo không còn ràng buộc

            // 4. Sau đó mới xóa Booking
            var bk = await db.Bookings.FindAsync(bookingid);
            if (bk != null)
            {
                db.Bookings.Remove(bk);
                await db.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<Booking>> getAllbyHotelID(int id)
        {
            var result = await (
                from b in db.Bookings
                join br in db.Bookingrooms on b.BookingId equals br.BookingId
                join r in db.Rooms on br.RoomId equals r.RoomId
                join rt in db.RoomTypes on r.RoomTypeId equals rt.RoomTypeId
                where rt.HotelId == id
                select b
            ).Distinct().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Booking>> getAllbyUser(int id)
        {
            var result = await db.Bookings.Where(x => x.UserId == id).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Booking>> getAllfromManager(int id)
        {

            //var result = from bk in db.Bookings
            //             join r in db.Rooms on bk.RoomId equals r.RoomId
            //             join rt in db.RoomTypes on r.RoomTypeId equals rt.RoomTypeId
            //             join ht in db.Hotels on rt.HotelId equals ht.HotelId
            //             join u in db.Users on ht.UserId equals u.UserId
            //             where ht.UserId == id && u.UserRoleId == 3
            //             select bk;
            //return await result.ToListAsync();
            return null;
        }

        public async Task<Booking> GetBooking(int id)
        {
            var result = await db.Bookings.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Bookingroom>> GetBookingrooms()
        {
            var list = await db.Bookingrooms.ToListAsync();
            return list;
        }

        public async Task<IEnumerable<Bookingroom>> GetBookingroomsbyIDBooking(int id)
        {
            var list = await db.Bookingrooms.Where(x=> x.BookingId==id).ToListAsync();
            return list;
        }

        public async Task<bool> updateStatusBooking(int id, int num)
        {
            var result = await db.Bookings.FindAsync(id);
            if (result != null)
            {
                if (num == 2)
                {
                    // 1. Lấy danh sách BookingRoom trước
                    var list = await db.Bookingrooms.Where(x => x.BookingId == id).ToListAsync();

                    // 2. Cập nhật trạng thái phòng về false
                    var roomIds = list.Select(item => item.RoomId).ToList();

                    var rooms = await db.Rooms.Where(x => roomIds.Contains(x.RoomId)).ToListAsync();

                    foreach (var room in rooms)
                    {
                        room.Status = false;
                    }
                    await db.SaveChangesAsync();
                    // 3. Xóa BookingRoom trước
                    result.Status = num;
                    await db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    result.Status = num;
                    await db.SaveChangesAsync();
                    return true;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
