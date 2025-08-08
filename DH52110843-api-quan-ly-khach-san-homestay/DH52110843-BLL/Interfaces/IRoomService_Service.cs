using DH52110843_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IRoomService_Service
    {
        Task<IEnumerable<RoomServiceDTO>> getAllAsync();
        Task<IEnumerable<RoomServiceDTO>> getAllbyRoomTypeIdAsync(int id);
        Task<IEnumerable<RoomServiceDTO>> getAllbyRoomSeviceUserIdAsync(int id);
        Task addAsync(RoomServiceDTO roomService);
        Task deleteAsync(int id);
        Task updateAsync(int id, RoomServiceDTO roomService);
        Task<RoomServiceDTO> findByIdAsync(int id);
    }
}
