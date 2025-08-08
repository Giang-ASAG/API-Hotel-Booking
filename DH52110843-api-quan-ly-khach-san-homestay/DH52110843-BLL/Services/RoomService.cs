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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task addAsync(RoomDTO room)
        {
            var r = _mapper.Map<Room>(room);
            await _repository.addAsync(r);
        }

        public async Task cancelRoom(int id)
        {
            await _repository.cancelRoom(id);
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<RoomDTO> findByIdAsync(int id)
        {
            var r =await _repository.findByIdAsync(id);
            return _mapper.Map<RoomDTO>(r);
        }

        public async Task<RoomDTO> findByIdBookingAsync(int id)
        {
            {
                var r = await _repository.findByIdBookingAsync(id);
                return _mapper.Map<RoomDTO>(r);
            }
        }

        public async Task<IEnumerable<RoomDTO>> getAllRoomAsync()
        {
            var list = await _repository.getAllRoomAsync();
            return _mapper.Map<IEnumerable<RoomDTO>>(list);
        }

        public async Task<IEnumerable<RoomDTO>> getAllRoombyHotelIdAsync(int id)
        {
            var list = await _repository.getAllRoombyHotelIdAsync(id);
            return _mapper.Map<IEnumerable<RoomDTO>>(list);
        }

        public async Task<IEnumerable<RoomDTO>> getAllRoombyRoomTypeIdAsync(int id)
        {
            var list = await _repository.getAllRoombyRoomTypeIdAsync(id);
            return _mapper.Map<IEnumerable<RoomDTO>>(list);
        }

        public async Task holdRoom(int id)
        {
            await _repository.holdRoom(id);
        }

        public async Task updateAsync(int id, RoomDTO room)
        {
            var r = _mapper.Map<Room>(room);
            await _repository.updateAsync(id,r);
        }

        public async Task updateStatusRoom(int id)
        {
            await _repository.updateStatusRoom(id);
        }
    }
}
