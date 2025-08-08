using AutoMapper;
using DH52110843_BLL.DTO;
using DH52110843_BLL.Interfaces;
using DH52110843_DAL.Interfaces;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository repository;
        private readonly IMapper mapper;
        public BookingService(IBookingRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<BookingDTO> addAsync(BookingDTO booking)
        {
            var book = await repository.addBookingAsync(mapper.Map<Booking>(booking));
            return mapper.Map<BookingDTO>(book);
        }

        public async Task<BookingRoomDTO> addBookingRoomAsync(BookingRoomDTO booking)
        {
            var book = await repository.addBookingRoomAsync(mapper.Map<Bookingroom>(booking));
            return mapper.Map<BookingRoomDTO>(book);
        }

        public async Task deleteBookingRoom(int bookingid)
        {
            await repository.deleteBookingRoom(bookingid);
        }

        public async Task<IEnumerable<BookingMVVMDTO>> getAllbyHotelID(int id)
        {
            var list = await repository.getAllbyHotelID(id);
            return mapper.Map<IEnumerable<BookingMVVMDTO>>(list);
        }

        public async Task<IEnumerable<BookingMVVMDTO>> getAllbyUser(int id)
        {
            var list = await repository.getAllbyUser(id);
            return mapper.Map<IEnumerable<BookingMVVMDTO>>(list);
        }

        public async Task<IEnumerable<BookingDTO>> getAllfromManager(int id)
        {
            var list = await repository.getAllfromManager(id);
            return mapper.Map<IEnumerable<BookingDTO>>(list);
        }

        public async Task<BookingDTO> GetBooking(int id)
        {
            var rs = await repository.GetBooking(id);
            return mapper.Map<BookingDTO>(rs);
        }

        public async Task<IEnumerable<BookingRoomDTO>> GetBookingrooms()
        {
            var list = await repository.GetBookingrooms();
            return mapper.Map<IEnumerable<BookingRoomDTO>>(list);
        }

        public async Task<IEnumerable<BookingRoomDTO>> GetBookingroomsbyIDBooking(int id)
        {
            var list = await repository.GetBookingroomsbyIDBooking(id);
            return mapper.Map<IEnumerable<BookingRoomDTO>>(list);
        }

        public async Task<bool> updateStatusBooking(int id, int num)
        {
            var res = await repository.updateStatusBooking(id, num);
            return res;
        }
    }
}
