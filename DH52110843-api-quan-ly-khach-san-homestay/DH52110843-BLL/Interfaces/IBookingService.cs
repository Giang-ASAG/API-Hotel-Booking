using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDTO>> getAllfromManager(int id);
        Task<IEnumerable<BookingMVVMDTO>> getAllbyHotelID(int id);
        Task<BookingDTO> addAsync(BookingDTO booking);
        Task<BookingDTO> GetBooking(int id);
        Task deleteBookingRoom(int bookingid);
        Task<IEnumerable<BookingRoomDTO>> GetBookingroomsbyIDBooking(int id);
        Task<IEnumerable<BookingMVVMDTO>> getAllbyUser(int id);
        Task<IEnumerable<BookingRoomDTO>> GetBookingrooms();
        Task<BookingRoomDTO> addBookingRoomAsync(BookingRoomDTO booking);
        Task<bool> updateStatusBooking(int id, int num);
    }
}
