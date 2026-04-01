using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IRoomServiceRepository
    {
        Task<IEnumerable<RoomService>>getAllAsync();
        Task<IEnumerable<RoomService>>getAllbyRoomTypeIdAsync(int id);
        Task<IEnumerable<RoomService>> getAllbyRoomSeviceUserIdAsync(int id);
        Task addAsync(RoomService roomService);
        Task deleteAsync(int id);
        Task updateAsync(int id, RoomService roomService);
        Task<RoomService> findByIdAsync(int id);
    }
}
