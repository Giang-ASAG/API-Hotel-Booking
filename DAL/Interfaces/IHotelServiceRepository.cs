using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IHotelServiceRepository
    {
        Task<IEnumerable<HotelService>> getHotelServiceAsync();
        Task<IEnumerable<HotelService>> getHotelServicebyIdHotelAsync(int id);
        Task<IEnumerable<HotelService>> getHotelServicebyIdUserAsync(int id);
        Task deleteAsync(int id);
        Task addAsync(HotelService hotelService);
        Task<HotelService> findByIdAsync(int id);
        Task updateAsync(int id , HotelService hotelService);
    }
}
