using TvShowApi.Dtos;
using TvShowApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TvShowApi.Interfaces
{
    public interface ITvShowService
    {
        Task<IEnumerable<TvShowApiDto>> GetAllAsync();
        Task<TvShowApiDto> GetByIdAsync(int id);
        Task AddAsync(TvShowApiDto tvShowDto);
        Task UpdateAsync(int id, TvShowApiDto tvShowDto);
        Task DeleteAsync(int id);
    }
}
