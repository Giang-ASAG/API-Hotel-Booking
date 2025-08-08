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
    public class UserDocumentService : IUserDocumentService
    {
        private readonly IUserDocumentRepository _repository;
        private readonly IMapper _mappers;
        public UserDocumentService(IUserDocumentRepository repository, IMapper mappers)
        {
            _repository = repository;
            _mappers = mappers;
        }
        public async Task<UserDocumentDTO> addAsync(UserDocumentDTO userDocumentDTO)
        {
            var user = _mappers.Map<UserDocument>(userDocumentDTO);
            var u = await _repository.AddAsync(user);
            return _mappers.Map<UserDocumentDTO>(u);
        }

        public async Task<IEnumerable<UserDTO>> getAllAsync()
        {
            var u = await _repository.getAllAsync();
            return _mappers.Map<IEnumerable<UserDTO>>(u);
        }

        public async Task<IEnumerable<UserDocumentDTO>> getAllDocumentAsync()
        {
            var u = await _repository.getAllDocumentAsync();
            return _mappers.Map<IEnumerable<UserDocumentDTO>>(u);
        }

        public async Task<UserDocumentDTO> getbyUserId(int id)
        {
            var u = await _repository.getbyIdUserAsync(id);
            return _mappers.Map<UserDocumentDTO>(u);
        }

        public async Task<bool> updateActive(int userId, int number)
        {
            var result =await _repository.updateActive(userId,number);
            return result;
        }
    }
}
