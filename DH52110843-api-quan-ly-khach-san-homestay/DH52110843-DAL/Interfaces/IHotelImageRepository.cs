using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IHotelImageRepository
    {
        Task<IEnumerable<HotelImage>> GetAllHotelImagesAsync();

        Task<IEnumerable<HotelImage>> GetImagesByIdHotel(int id);
        Task addAsync(HotelImage image);
        Task UpdateAsync(int id, HotelImage image);
        Task deleteAsync(int id);
    }
}
