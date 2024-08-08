using TvShowApi.Interfaces;
using TvShowApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvShowApi.Repositories
{
    public class TvShowRepository : ITvShowRepository
    {
        private readonly List<TvShow> _tvShows;
        private int _nextId;

        public TvShowRepository()
        {
            // Datos iniciales
            _tvShows = new List<TvShow>
{
    new TvShow { Id = 0, Name = "Breaking Bad", Favorite = true },
    new TvShow { Id = 1, Name = "Stranger Things", Favorite = false },
    new TvShow { Id = 2, Name = "Game of Thrones", Favorite = false },
    new TvShow { Id = 3, Name = "The Mandalorian", Favorite = true },
    new TvShow { Id = 4, Name = "The Witcher", Favorite = false },
    new TvShow { Id = 5, Name = "Sherlock", Favorite = true },
    new TvShow { Id = 6, Name = "Friends", Favorite = false },
    new TvShow { Id = 7, Name = "The Office", Favorite = true },
    new TvShow { Id = 8, Name = "Westworld", Favorite = false },
    new TvShow { Id = 9, Name = "Better Call Saul", Favorite = false },
    new TvShow { Id = 10, Name = "Rick and Morty", Favorite = true },
    new TvShow { Id = 11, Name = "House of Cards", Favorite = false },
    new TvShow { Id = 12, Name = "The Crown", Favorite = true },
    new TvShow { Id = 13, Name = "Black Mirror", Favorite = false },
    new TvShow { Id = 14, Name = "Narcos", Favorite = true },
    new TvShow { Id = 15, Name = "The Expanse", Favorite = false },
    new TvShow { Id = 16, Name = "The Boys", Favorite = true },
    new TvShow { Id = 17, Name = "Money Heist", Favorite = false },
    new TvShow { Id = 18, Name = "Dark", Favorite = true },
    new TvShow { Id = 19, Name = "The Handmaid's Tale", Favorite = false }
};

            _nextId = _tvShows.Max(tvShow => tvShow.Id) + 1;
        }

        public Task<IEnumerable<TvShow>> GetAllAsync() => Task.FromResult(_tvShows.AsEnumerable());

        public Task<TvShow> GetByIdAsync(int id) =>
            Task.FromResult(_tvShows.FirstOrDefault(show => show.Id == id));

        public Task AddAsync(TvShow tvShow)
        {
            if (_tvShows.Any(show => show.Name.Equals(tvShow.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"A TV show with the name '{tvShow.Name}' already exists.");
            }

            tvShow.Id = _nextId++;
            _tvShows.Add(tvShow);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TvShow tvShow)
        {
            var existingShow = _tvShows.FirstOrDefault(show => show.Id == tvShow.Id);
            if (existingShow != null)
            {
                if (_tvShows.Any(show => show.Name.Equals(tvShow.Name, StringComparison.OrdinalIgnoreCase) && show.Id != tvShow.Id))
                {
                    throw new InvalidOperationException($"A TV show with the name '{tvShow.Name}' already exists.");
                }

                existingShow.Name = tvShow.Name;
                existingShow.Favorite = tvShow.Favorite;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var show = _tvShows.FirstOrDefault(tvShow => tvShow.Id == id);
            if (show != null)
            {
                _tvShows.Remove(show);
            }
            return Task.CompletedTask;
        }
    }
}
