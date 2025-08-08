using DH52110843_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IHotelServiceService
    {
        Task<IEnumerable<HotelServiceDTO>> getHotelServiceAsync();
        Task<IEnumerable<HotelServiceDTO>> getHotelServicebyIdHotelAsync(int id);
        Task<IEnumerable<HotelServiceDTO>> getHotelServicebyIdUserAsync(int id);
        Task deleteAsync(int id);
        Task addAsync(HotelServiceDTO hotelService);
        Task<HotelServiceDTO> findByIdAsync(int id);
        Task updateAsync(int id, HotelServiceDTO hotelService);
    }
}
