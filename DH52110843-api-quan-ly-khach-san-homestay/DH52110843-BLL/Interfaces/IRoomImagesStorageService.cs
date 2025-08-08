using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IRoomImagesStorageService
    {
        Task<IEnumerable<RoomImageStorageDTO>> getAllAsync();
        Task addAsync(RoomImageStorageDTO storage);
        Task deleteAsync(int id);
        Task updateAsync(int id, RoomImageStorageDTO storage);
        Task<RoomImageStorageDTO> findAsync(int id);
        Task<RoomImageStorageDTO> findPathAsync(string url);
    }
}
