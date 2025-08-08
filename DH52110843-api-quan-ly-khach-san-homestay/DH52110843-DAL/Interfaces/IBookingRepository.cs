using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> getAllfromManager(int id);
        Task<IEnumerable<Booking>> getAllbyHotelID(int id);
        Task<IEnumerable<Booking>> getAllbyUser(int id);
        Task<Booking> GetBooking(int id);
        Task<IEnumerable<Bookingroom>> GetBookingrooms();
        Task<IEnumerable<Bookingroom>> GetBookingroomsbyIDBooking(int id);
        Task deleteBookingRoom(int bookingid);
        Task<Booking> addBookingAsync(Booking booking);
        Task<Bookingroom> addBookingRoomAsync(Bookingroom booking);
        Task<bool> updateStatusBooking(int id, int num);
        
    }
}
