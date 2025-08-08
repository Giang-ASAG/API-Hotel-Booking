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
    public class RoomServiceRepository : IRoomServiceRepository
    {
        private readonly HethonghotelContext db;
        public RoomServiceRepository(HethonghotelContext db)
        {
            this.db = db;
        }
        public async Task addAsync(RoomService roomService)
        {
            await db.RoomServices.AddAsync(roomService);
            await db.SaveChangesAsync();
        }

        public async Task deleteAsync(int id)
        {
            var rs = await db.RoomServices.FindAsync(id);
            if(rs==null) throw new KeyNotFoundException("Not found RoomServices");
            db.RoomServices.Remove(rs);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoomService>> getAllAsync()
        {
            return await db.RoomServices.ToListAsync();
        }

        public async Task<IEnumerable<RoomService>> getAllbyRoomTypeIdAsync(int id)
        {
            return await db.RoomServices.Where(x=>x.RoomTypeId==id).ToListAsync();
        }

        public async Task<IEnumerable<RoomService>> getAllbyRoomSeviceUserIdAsync(int id)
        {
            var result = from rs in db.RoomServices
                         join ry in db.RoomTypes on rs.RoomTypeId equals ry.RoomTypeId
                         join ht in db.Hotels on ry.HotelId equals ht.HotelId
                         where ht.UserId == id
                         select rs;
            return await result.ToListAsync();
        }

        public async Task updateAsync(int id,RoomService roomService)
        {
            var rs = await db.RoomServices.FindAsync(id);
            if (rs == null) throw new KeyNotFoundException("Not found RoomServices");
            rs.ServiceName = roomService.ServiceName;
            rs.RoomTypeId = roomService.RoomTypeId;
            await db.SaveChangesAsync();
        }

        public async Task<RoomService> findByIdAsync(int id)
        {
            var rs= await db.RoomServices.FindAsync(id);
            if(rs != null)
            {
                return rs;
            }
            else
            {
                throw new KeyNotFoundException("Not found RoomServices");
            }
        }
    }
}
