using DH52110843_DAL.Data;
using DH52110843_DAL.Interfaces;
using DH52110843_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HethonghotelContext db;
        public RoomRepository(HethonghotelContext db)
        {
            this.db = db;
        }
        public async Task addAsync(Room room)
        {
            await db.Rooms.AddAsync(room);
            await db.SaveChangesAsync();
        }

        public async Task cancelRoom(int id)
        {
            var r = await db.Rooms.FindAsync(id);
            if (r != null)
            {
                r.Status = false;
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found Room");
            }
        }

        public async Task deleteAsync(int id)
        {
            var r = await db.Rooms.FindAsync(id);
            if (r != null)
            {
                var count = await db.Bookingrooms.CountAsync(x=>x.RoomId==r.RoomId);
                if (count > 0 && r.Status==true)
                {
                    throw new KeyNotFoundException($"Cann't delete Room");
                }
                db.Rooms.Remove(r);
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found Room");
            }

        }

        public async Task<Room> findByIdAsync(int id)
        {
            var r = await db.Rooms.FindAsync(id);
            if (r != null)
            {
                return r;
            }
            else
            {
                throw new KeyNotFoundException($"Not found Room");
            }

        }

        public async Task<Room> findByIdBookingAsync(int id)
        {
            var result = await (from bk in db.Bookings
                                join br in db.Bookingrooms on bk.BookingId equals br.BookingId
                                join r in db.Rooms on br.RoomId equals r.RoomId 
                                where bk.BookingId == id
                                select r)
                                    .FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Room>> getAllRoomAsync()
        {
            return await db.Rooms.ToListAsync();
        }

        public async Task<IEnumerable<Room>> getAllRoombyHotelIdAsync(int id)
        {
            var rooms = from r in db.Rooms
                        join rt in db.RoomTypes on r.RoomTypeId equals rt.RoomTypeId
                        join h in db.Hotels on rt.HotelId equals h.HotelId
                        where h.HotelId == id
                        select r;
            return await rooms.ToListAsync();
        }

        public async Task<IEnumerable<Room>> getAllRoombyRoomTypeIdAsync(int id)
        {
            return await db.Rooms.Where(x=>x.RoomTypeId==id).ToListAsync();
        }

        public async Task holdRoom(int id)
        {

            var r = await db.Rooms.FindAsync(id);
            if (r != null)
            {
                r.Status = true;
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found Room");
            }
        }

        public async Task updateAsync(int id, Room room)
        {
            var r = await db.Rooms.FindAsync(id);
            if (r == null)
            {
                throw new KeyNotFoundException($"Not found Room");
            }
            r.RoomNumber = room.RoomNumber;
            r.RoomTypeId = room.RoomTypeId;
            r.Active = room.Active;
            r.Status = room.Status;
            await db.SaveChangesAsync();

        }

        public async Task updateStatusRoom(int id)
        {
            var r = await db.Rooms.FindAsync(id);
            if (r != null)
            {
                r.Status = false;
                await db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Not found Room");
            }

        }
    }
}
