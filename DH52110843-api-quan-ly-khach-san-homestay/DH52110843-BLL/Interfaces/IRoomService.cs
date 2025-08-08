using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> getAllRoomAsync();
        Task<IEnumerable<RoomDTO>> getAllRoombyRoomTypeIdAsync(int id);
        Task<IEnumerable<RoomDTO>> getAllRoombyHotelIdAsync(int id);
        Task addAsync(RoomDTO room);
        Task deleteAsync(int id);
        Task updateAsync(int id, RoomDTO room);
        Task<RoomDTO> findByIdAsync(int id);
        Task updateStatusRoom(int id);
        Task holdRoom(int id);
        Task<RoomDTO> findByIdBookingAsync(int id);
        Task cancelRoom(int id);

    }
}
