using Catedra1IDWM.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace Catedra1IDWM.Src.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Usuarios {get; set;}
    }
}