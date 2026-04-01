using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> getAllRoomAsync();
        Task<IEnumerable<Room>> getAllRoombyRoomTypeIdAsync(int id);
        Task<IEnumerable<Room>> getAllRoombyHotelIdAsync(int id);
        Task addAsync(Room room);
        Task deleteAsync(int id);
        Task updateAsync(int id,Room room);
        Task<Room> findByIdAsync(int id);
        Task<Room> findByIdBookingAsync(int id);
        Task updateStatusRoom(int id);
        Task holdRoom(int id);
        Task cancelRoom(int id);
    }
}
