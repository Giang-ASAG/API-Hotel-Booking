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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository repository, IMapper mapper)
        {
            _mapper= mapper;
            _repository = repository;
        }
        public async Task addAsync(ReviewDTO review)
        {
           var rv = _mapper.Map<Review>(review);
            await _repository.addAsync(rv);
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<IEnumerable<ReviewDTO>> getAllAsync()
        {
            var list =await _repository.getAllAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(list);
        }

        public async Task<IEnumerable<ReviewDTO>> getAllbyHotelIdAsync(int id)
        {
            var list = await _repository.getAllbyHotelIdAsync(id);
            return _mapper.Map<IEnumerable<ReviewDTO>>(list);
        }
    }
}
