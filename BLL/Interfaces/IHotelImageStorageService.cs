using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IHotelImageStorageService
    {
        Task<IEnumerable<HotelImageStorageDTO>> GetHotelImagesStorageAsync();
        Task<HotelImageStorageDTO> addAsync(HotelImageStorageDTO hotelImagesStorage);
        Task updateAsync(int id, HotelImageStorageDTO hotelImagesStorage);
        Task deleteAsync(int id);
        Task<HotelImageStorageDTO> findAsync(int id);
    }
}
