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
    public class RoomImageService : IRoomImageService
    {
        private readonly IRoomImageRepository _repository;
        private readonly IMapper _mapper;
        public RoomImageService(IRoomImageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task addAsync(RoomImageDTO roomImage)
        {
            var r = _mapper.Map<RoomImage>(roomImage);
            await _repository.addAsync(r);

        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<RoomImageDTO> findImageAsync(int id)
        {
            var r = await _repository.findImageAsync(id);
            return _mapper.Map<RoomImageDTO>(r);
        }

        public async Task<IEnumerable<RoomImageDTO>> getAllImagebyRoomIdAsync(int id)
        {
            var list = await _repository.getAllImagebyRoomIdAsync(id);
            return _mapper.Map<IEnumerable<RoomImageDTO>>(list);
        }

        public async Task<IEnumerable<RoomImageDTO>> getAllImagesAsync()
        {
            var list = await _repository.getAllImagesAsync();
            return _mapper.Map<IEnumerable<RoomImageDTO>>(list);
        }

        public async Task updateAsync(int id, RoomImageDTO roomImage)
        {
            await _repository.updateAsync(id, _mapper.Map<RoomImage>(roomImage));
        }
    }
}
