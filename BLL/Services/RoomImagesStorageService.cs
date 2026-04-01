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
    public class RoomImagesStorageService : IRoomImagesStorageService
    {
        private readonly IMapper _mapper;
        private readonly IRoomImagesStorageRepository _repository;
        public RoomImagesStorageService(IMapper mapper, IRoomImagesStorageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task addAsync(RoomImageStorageDTO storage)
        {
            var s = _mapper.Map<RoomImagesStorage>(storage);
            await _repository.addAsync(s);
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<RoomImageStorageDTO> findAsync(int id)
        {
            var r = await _repository.findAsync(id);
            return _mapper.Map<RoomImageStorageDTO>(r);
        }

        public async Task<RoomImageStorageDTO> findPathAsync(string url)
        {
            var r = await getAllAsync();
            var t = r.FirstOrDefault(x=>x.ImagePath==url);
            return t;
        }

        public async Task<IEnumerable<RoomImageStorageDTO>> getAllAsync()
        {
            var list = await _repository.getAllAsync();
            return _mapper.Map<IEnumerable<RoomImageStorageDTO>>(list);
        }

        public async Task updateAsync(int id, RoomImageStorageDTO storage)
        {
            await _repository.updateAsync(id,_mapper.Map<RoomImagesStorage>(storage));
        }
    }
}
