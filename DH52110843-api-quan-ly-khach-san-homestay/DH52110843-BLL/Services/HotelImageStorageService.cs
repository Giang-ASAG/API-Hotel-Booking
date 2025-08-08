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
    public class HotelImageStorageService : IHotelImageStorageService
    {
        private readonly IHotelImageStorageRepository _storageRepository;
        private readonly IMapper _mapper;
        public HotelImageStorageService(IHotelImageStorageRepository storageRepository, IMapper mapper)
        {
            _storageRepository = storageRepository;
            _mapper = mapper;
        }

        public async Task<HotelImageStorageDTO> addAsync(HotelImageStorageDTO hotelImagesStorage)
        {
            var h = _mapper.Map<HotelImagesStorage>(hotelImagesStorage);
            var r = await _storageRepository.addAsync(h);
            return _mapper.Map<HotelImageStorageDTO>(r);
        }

        public async Task deleteAsync(int id)
        {
            await _storageRepository.deleteAsync(id);
        }

        public async Task<HotelImageStorageDTO> findAsync(int id)
        {
            var h = await _storageRepository.findAsync(id);
            return _mapper.Map<HotelImageStorageDTO>(h);
        }

        public async Task<IEnumerable<HotelImageStorageDTO>> GetHotelImagesStorageAsync()
        {
            var list =await _storageRepository.GetHotelImagesStorageAsync();
            return _mapper.Map<IEnumerable<HotelImageStorageDTO>>(list);
        }

        public async Task updateAsync(int id, HotelImageStorageDTO hotelImagesStorage)
        {
            var h = _mapper.Map<HotelImagesStorage>(hotelImagesStorage);
            await _storageRepository.updateAsync(id, h);
        }
    }
}
