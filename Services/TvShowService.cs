using AutoMapper;
using TvShowApi.Dtos;
using TvShowApi.Interfaces;
using TvShowApi.Models;
using System;

namespace TvShowApi.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly ITvShowRepository _repository;
        private readonly IMapper _mapper;

        public TvShowService(ITvShowRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TvShowApiDto>> GetAllAsync()
        {
            var shows = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TvShowApiDto>>(shows);
        }

        public async Task<TvShowApiDto> GetByIdAsync(int id)
        {
            var show = await _repository.GetByIdAsync(id);
            return _mapper.Map<TvShowApiDto>(show);
        }

        public async Task AddAsync(TvShowApiDto tvShowDto)
        {
            var tvShow = _mapper.Map<TvShow>(tvShowDto);
            try
            {
                await _repository.AddAsync(tvShow);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task UpdateAsync(int id, TvShowApiDto tvShowDto)
        {
            var tvShow = _mapper.Map<TvShow>(tvShowDto);
            tvShow.Id = id;
            try
            {
                await _repository.UpdateAsync(tvShow);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
