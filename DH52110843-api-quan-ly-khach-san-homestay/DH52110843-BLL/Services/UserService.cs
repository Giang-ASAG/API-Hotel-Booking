using AutoMapper;
using DH52110843_BLL.DTO;
using DH52110843_BLL.Interfaces;
using DH52110843_DAL.Interfaces;
using DH52110843_DAL.Models;
using DH52110843_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper,IUserRepository userRepository)
        {
            _mapper=mapper;
            _userRepository=userRepository;
        }

        public async Task ActiveAsync(int id, bool active)
        {
            await _userRepository.ActiveAsync(id,active);
        }

        public async Task AddAsync(UserDTO user)
        {
            var u = _mapper.Map<User>(user);
            await _userRepository.AddAsync(u);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<UserDTO> FindUserByEmailAsync(string email)
        {
            var u = await _userRepository.FindUserByEmailAsync(email);
            return _mapper.Map<UserDTO>(u);
        }

        public async Task<UserDTO> findUserbyId(int id)
        {
            var u =await _userRepository.findUserbyId(id);
            return _mapper.Map<UserDTO>(u);
        }

        public async Task<IEnumerable<UserDTO>> getAllAsync()
        {
            var list = await _userRepository.getAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(list); 
        }

        public async Task<int[]> GetUserCountsByMonth()
        {
            return await _userRepository.GetUserCountsByMonth();
        }

        public async Task UpdateAsync(int id, UserNoPasswordDTO user)
        {
            var u = _mapper.Map<User>(user);
            await _userRepository.UpdateAsync(id,u);
            
        }

        public async Task UpdatePermissionAsync(int id)
        {
            await _userRepository.UpdatePermissionAsync(id);
        }
    }
}
