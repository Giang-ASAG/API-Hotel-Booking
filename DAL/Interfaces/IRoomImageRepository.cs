using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IRoomImageRepository
    {
        Task<IEnumerable<RoomImage>> getAllImagesAsync();
        Task<IEnumerable<RoomImage>> getAllImagebyRoomIdAsync(int id);
        Task addAsync(RoomImage roomImage);
        Task deleteAsync(int id);
        Task updateAsync(int id, RoomImage roomImage);
        Task<RoomImage> findImageAsync(int id);

    }
}
