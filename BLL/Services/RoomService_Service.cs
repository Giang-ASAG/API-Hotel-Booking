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
    public class RoomService_Service : IRoomService_Service
    {
        private readonly IRoomServiceRepository _repository;
        private readonly IMapper _mapper;
        public RoomService_Service(IRoomServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task addAsync(RoomServiceDTO roomService)
        {
            var r = _mapper.Map<DH52110843_DAL.Models.RoomService>(roomService);
            await _repository.addAsync(r);
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<IEnumerable<RoomServiceDTO>> getAllAsync()
        {
            var list = await _repository.getAllAsync();
            return  _mapper.Map<IEnumerable<RoomServiceDTO>>(list);
        }

        public async Task<IEnumerable<RoomServiceDTO>> getAllbyRoomTypeIdAsync(int id)
        {
            var list = await _repository.getAllbyRoomTypeIdAsync(id);
            return _mapper.Map<IEnumerable<RoomServiceDTO>>(list);
        }

        public async Task<IEnumerable<RoomServiceDTO>> getAllbyRoomSeviceUserIdAsync(int id)
        {
            var list = await _repository.getAllbyRoomSeviceUserIdAsync(id);
            return _mapper.Map<IEnumerable<RoomServiceDTO>>(list);
        }

        public async Task updateAsync(int id, RoomServiceDTO roomService)
        {
            await _repository.updateAsync(id, _mapper.Map<DH52110843_DAL.Models.RoomService>(roomService));
        }

        public async Task<RoomServiceDTO> findByIdAsync(int id)
        {
            var r = await _repository.findByIdAsync(id);
            return _mapper.Map<RoomServiceDTO>(r);
        }
    }
}
