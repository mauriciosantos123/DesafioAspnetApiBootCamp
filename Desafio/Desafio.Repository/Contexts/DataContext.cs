using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}