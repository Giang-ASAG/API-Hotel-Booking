using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeDTO>> getAllRoomTypeAsync();
        Task<IEnumerable<RoomTypeDTO>> getAllRoomTypebyHotelIdAsync(int id);
        Task<IEnumerable<RoomTypeDTO>> getAllRoomTypebyUserIdAsync(int id);
        Task<RoomTypeDTO> addAsync(RoomTypeDTO roomType);
        Task<IEnumerable<RoomTypeCountDTO>> getAllRoomTypeAndCount(int id);
        Task<IEnumerable<RoomTypeCountDTO>> getAllRoomTypebySearch(RoomTypeSearchRequest request);
        Task<IEnumerable<RoomType>> searchRoomType(RoomTypeSearchRequest request);
        Task deleteAsync(int id);
        Task updateAsync(int id, RoomTypeDTO roomType);
        Task<RoomTypeDTO> findAsync(int id);
    }
}
