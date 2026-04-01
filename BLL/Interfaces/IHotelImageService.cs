using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IHotelImageService
    {
        Task<IEnumerable<HotelImageDTO>> GetAllHotelImagesAsync();

        Task<IEnumerable<HotelImageDTO>> GetImagesByIdHotel(int id);
        Task addAsync(HotelImageDTO image);
        Task UpdateAsync(int id, HotelImageDTO image);
        Task deleteAsync(int id);
    }
}
