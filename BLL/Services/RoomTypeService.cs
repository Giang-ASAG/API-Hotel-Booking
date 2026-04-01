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
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _repository;
        private readonly IMapper _mapper;
        public RoomTypeService(IRoomTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<RoomTypeDTO> addAsync(RoomTypeDTO roomType)
        {
            var rt= _mapper.Map<RoomType>(roomType);
            await _repository.addAsync(rt);
            return _mapper.Map<RoomTypeDTO>(rt);
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<RoomTypeDTO> findAsync(int id)
        {
            var rt= await _repository.findAsync(id);
            return _mapper.Map<RoomTypeDTO>(rt);
        }

        public async Task<IEnumerable<RoomTypeCountDTO>> getAllRoomTypebySearch(RoomTypeSearchRequest request)
        {
            var list = await _repository.getAllRoomTypebyHotelIdAsync(request.hotelId);
            var result = new List<RoomTypeCountDTO>();
            foreach (var item in list)
            {
                var count = await _repository.getCountSearch(item.RoomTypeId, request.CheckIn, request.CheckOut);
                result.Add(new RoomTypeCountDTO
                {
                    RoomTypeId = item.RoomTypeId,
                    Capacity = item.Capacity,
                    Count = count,
                    HotelId = item.HotelId,
                    Price = item.Price,
                    RoomInfo = item.RoomInfo,
                    TypeName = item.TypeName,
                    imgPath = new List<string>()

                });
            }
            return result;

        }

        public async Task<IEnumerable<RoomTypeCountDTO>> getAllRoomTypeAndCount(int id)
        {
            var list = await _repository.getAllRoomTypebyHotelIdAsync(id);
            var result = new List<RoomTypeCountDTO>();
            foreach (var item in list)
            {
                var count = await _repository.getCount(item.RoomTypeId, false);
                result.Add(new RoomTypeCountDTO
                {
                    RoomTypeId = item.RoomTypeId,
                    Capacity = item.Capacity,
                    Count = count,
                    HotelId = item.HotelId,
                    Price = item.Price,
                    RoomInfo = item.RoomInfo,
                    TypeName = item.TypeName,
                    imgPath = new List<string>()
                    
                });
            }
            return result;

        }

        public async Task<IEnumerable<RoomTypeDTO>> getAllRoomTypeAsync()
        {
            var list = await _repository.getAllRoomTypeAsync();
            return _mapper.Map<IEnumerable<RoomTypeDTO>>(list); 
        }

        public async Task<IEnumerable<RoomTypeDTO>> getAllRoomTypebyHotelIdAsync(int id)
        {
            var list = await _repository.getAllRoomTypebyHotelIdAsync(id);
            return _mapper.Map<IEnumerable<RoomTypeDTO>>(list);
        }

        public async Task<IEnumerable<RoomTypeDTO>> getAllRoomTypebyUserIdAsync(int id)
        {
            var list = await _repository.getAllRoomTypebyUserIdAsync(id);
            return _mapper.Map<IEnumerable<RoomTypeDTO>>(list);
        }

        public Task<IEnumerable<RoomType>> searchRoomType(RoomTypeSearchRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task updateAsync(int id, RoomTypeDTO roomType)
        {
            var rt = _mapper.Map<RoomType>(roomType);
            await _repository.updateAsync(id, rt);
        }
    }
}
