using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelDTO>> getAllHotel();
        Task<IEnumerable<HotelDTO>> getAllHotelByIdUser(int id);
        Task<HotelDTO> findHotelbyId(int id);
        Task<HotelDTO> AddAsync(HotelDTO hotel);
        Task UpdateAsync(int id, HotelDTO hotel);
        Task DeleteAsync(int id);
        Task<IEnumerable<HotelDTO>> findHotelByIdAdress(string address);
        Task<IEnumerable<HotelDTO>> searchHotel(HotelSearchRequest hotelSearch);
    }
}
