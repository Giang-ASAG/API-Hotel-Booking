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
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }
        public async Task<HotelDTO> AddAsync(HotelDTO hotel)
        {
            var h = _mapper.Map<Hotel>(hotel);
            var t =await _hotelRepository.AddAsync(h);
            return _mapper.Map<HotelDTO>(t);
        }

        public async Task DeleteAsync(int id)
        {
            await _hotelRepository.DeleteAsync(id);
        }

        public async Task<HotelDTO> findHotelbyId(int id)
        {
            var h =await _hotelRepository.findHotelbyId(id);
            return _mapper.Map<HotelDTO>(h);
        }

        public async Task<IEnumerable<HotelDTO>> findHotelByIdAdress(string address)
        {
            var list = await _hotelRepository.findHotelByIdAdress(address);
            return _mapper.Map<IEnumerable<HotelDTO>>(list);
        }

        public async Task<IEnumerable<HotelDTO>> getAllHotel()
        {
            var list =await _hotelRepository.getAllHotel();
            return _mapper.Map<IEnumerable<HotelDTO>>(list);
        }

        public async Task<IEnumerable<HotelDTO>> getAllHotelByIdUser(int id)
        {
            var list = await _hotelRepository.getAllHotelByIdUser(id);
            return _mapper.Map<IEnumerable<HotelDTO>>(list);
        }

        public async Task<IEnumerable<HotelDTO>> searchHotel(HotelSearchRequest hotelSearch)
        {
            var list = await _hotelRepository.searchHotel(hotelSearch);
            return _mapper.Map<IEnumerable<HotelDTO>>(list);
        }

        public async Task UpdateAsync(int id, HotelDTO hotel)
        {
            var h = _mapper.Map<Hotel>(hotel);
            await _hotelRepository.UpdateAsync(id, h);
        }
    }
}
