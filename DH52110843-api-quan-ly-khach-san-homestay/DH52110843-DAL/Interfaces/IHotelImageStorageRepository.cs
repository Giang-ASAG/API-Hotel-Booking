using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IHotelImageStorageRepository
    {
        Task<IEnumerable<HotelImagesStorage>> GetHotelImagesStorageAsync();
        Task<HotelImagesStorage> addAsync(HotelImagesStorage hotelImagesStorage);
        Task updateAsync(int id,HotelImagesStorage hotelImagesStorage);
        Task deleteAsync(int id);
        Task<HotelImagesStorage> findAsync(int id);
    }
}
