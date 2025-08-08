using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IRoomImagesStorageRepository
    {
        Task<IEnumerable<RoomImagesStorage>>getAllAsync();
        Task addAsync(RoomImagesStorage storage);
        Task deleteAsync(int id);
        Task updateAsync(int id, RoomImagesStorage storage);
        Task<RoomImagesStorage> findAsync(int id);
    }
}
