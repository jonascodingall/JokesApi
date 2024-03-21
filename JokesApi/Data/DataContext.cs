using JokesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JokesApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Joke> Jokes { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}
