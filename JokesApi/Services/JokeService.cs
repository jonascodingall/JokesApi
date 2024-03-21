using JokesApi.Data.Repos;
using JokesApi.Extensions;
using JokesApi.Models;

namespace JokesApi.Services
{
    public class JokeService : IJokeService
    {
        private readonly IRepository<Joke> _repository;
        public JokeService(IRepository<Joke> repository)
        {
            _repository = repository;
        }

        public async Task CreateJokeAsync(Joke newJoke)
        {
            await _repository.AddAsync(newJoke);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteJokeAsync(int jokeId)
        {
            var joke = await _repository.GetAsync(jokeId) ?? throw new Exception();
            _repository.Remove(joke);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<Joke>> GetAllJokesAsync()
        {
            var jokes = await _repository.GetAllAsync();
            return jokes.ToList();
        }

        public async Task<Joke> GetSingleJokeAsync(int jokeId)
        {
            var joke = await _repository.GetAsync(jokeId) ?? throw new Exception();
            return joke;
        }

        public async Task UpdateJokeAsync(int jokeId, Joke updatedJoke)
        {
            var joke = await _repository.GetAsync(jokeId) ?? throw new Exception();
            joke.UpdateFrom(updatedJoke);
            await _repository.SaveChangesAsync();
        }
    }
}
