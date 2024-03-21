using JokesApi.Models;

namespace JokesApi.Extensions
{
    public static class JokeExtensions
    {
        public static void UpdateFrom(this Joke joke, Joke updatedJoke)
        {
            joke.Id = updatedJoke.Id;
            joke.Content = updatedJoke.Content;
            joke.Category = updatedJoke.Category;
        }
    }
}
