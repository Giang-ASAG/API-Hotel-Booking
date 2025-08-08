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
    public class HotelImageService : IHotelImageService
    {
        private readonly IHotelImageRepository _repository;
        private readonly IMapper _mapper;
        public HotelImageService(IHotelImageRepository repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }
        public async Task addAsync(HotelImageDTO image)
        {
            var hotel= _mapper.Map<HotelImage>(image);
            await _repository.addAsync(hotel);
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<IEnumerable<HotelImageDTO>> GetAllHotelImagesAsync()
        {
            var list = await _repository.GetAllHotelImagesAsync();
            return _mapper.Map<IEnumerable<HotelImageDTO>>(list);
        }

        public async Task<IEnumerable<HotelImageDTO>> GetImagesByIdHotel(int id)
        {
            var list = await _repository.GetImagesByIdHotel(id);
            return _mapper.Map<IEnumerable<HotelImageDTO>>(list);
        }

        public async Task UpdateAsync(int id, HotelImageDTO image)
        {
            var ht = _mapper.Map<HotelImage>(image);
            await _repository.UpdateAsync(id, ht);
        }
    }
}
