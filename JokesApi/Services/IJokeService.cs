using JokesApi.Models;

namespace JokesApi.Services
{
    public interface IJokeService
    {
        Task CreateJokeAsync(Joke newJoke);
        Task<Joke> GetSingleJokeAsync(int jokeId);
        Task<List<Joke>> GetAllJokesAsync();
        Task UpdateJokeAsync(int jokeId, Joke updatedJoke);
        Task DeleteJokeAsync(int jokeId);
    }
}
