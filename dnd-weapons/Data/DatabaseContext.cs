using dnd_weapons.Models;
using Microsoft.EntityFrameworkCore;

namespace dnd_weapons.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {   
        }

        public DbSet<WeaponModel> Weapons { get; set; }
    }
}
