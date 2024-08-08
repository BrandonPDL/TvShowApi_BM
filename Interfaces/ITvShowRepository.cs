using TvShowApi.Models;

namespace TvShowApi.Interfaces
{
    public interface ITvShowRepository
    {
        Task<IEnumerable<TvShow>> GetAllAsync();
        Task<TvShow> GetByIdAsync(int id);
        Task AddAsync(TvShow tvShow);
        Task UpdateAsync(TvShow tvShow);
        Task DeleteAsync(int id);
    }
}
