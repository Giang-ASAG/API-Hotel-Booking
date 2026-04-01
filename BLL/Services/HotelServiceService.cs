using AutoMapper;
using DH52110843_BLL.DTO;
using DH52110843_BLL.Interfaces;
using DH52110843_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Services
{
    public class HotelServiceService : IHotelServiceService
    {
        private readonly IHotelServiceRepository _repository;
        private readonly IMapper _mapper;
        public HotelServiceService(IHotelServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task addAsync(HotelServiceDTO hotelService)
        {
            var hs = _mapper.Map<DH52110843_DAL.Models.HotelService>(hotelService);
            await _repository.addAsync(hs);
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<HotelServiceDTO> findByIdAsync(int id)
        {
            var hs =await _repository.findByIdAsync(id);
            return _mapper.Map<HotelServiceDTO>(hs);
        }

        public async Task<IEnumerable<HotelServiceDTO>> getHotelServiceAsync()
        {
            var list = await _repository.getHotelServiceAsync();
            return _mapper.Map<IEnumerable<HotelServiceDTO>>(list);
        }

        public async Task<IEnumerable<HotelServiceDTO>> getHotelServicebyIdHotelAsync(int id)
        {
            var list = await _repository.getHotelServicebyIdHotelAsync(id);
            return _mapper.Map<IEnumerable<HotelServiceDTO>>(list);
        }

        public async Task<IEnumerable<HotelServiceDTO>> getHotelServicebyIdUserAsync(int id)
        {

            var list = await _repository.getHotelServicebyIdUserAsync(id);
            return _mapper.Map<IEnumerable<HotelServiceDTO>>(list);
        }

        public async Task updateAsync(int id, HotelServiceDTO hotelService)
        {
            var hs = _mapper.Map<DH52110843_DAL.Models.HotelService>(hotelService);
            await _repository.updateAsync(id, hs);
        }
    }
}
