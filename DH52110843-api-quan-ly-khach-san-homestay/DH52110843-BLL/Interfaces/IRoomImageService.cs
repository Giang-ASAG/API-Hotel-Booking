using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IRoomImageService
    {
        Task<IEnumerable<RoomImageDTO>> getAllImagesAsync();
        Task<IEnumerable<RoomImageDTO>> getAllImagebyRoomIdAsync(int id);
        Task addAsync(RoomImageDTO roomImage);
        Task deleteAsync(int id);
        Task updateAsync(int id, RoomImageDTO roomImage);
        Task<RoomImageDTO> findImageAsync(int id);
    }
}
