using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> getAllHotel();
        Task<IEnumerable<Hotel>> getAllHotelByIdUser(int id);
        Task<IEnumerable<Hotel>> findHotelByIdAdress(string address);
        Task<IEnumerable<Hotel>> searchHotel(HotelSearchRequest hotelSearch);
        Task<Hotel> findHotelbyId(int id);
        Task<Hotel> AddAsync(Hotel hotel);
        Task UpdateAsync(int id, Hotel hotel);
        Task DeleteAsync(int id);
    }
}
public class HotelSearchRequest
{
    public string Address { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int PeopleCount { get; set; }
}

