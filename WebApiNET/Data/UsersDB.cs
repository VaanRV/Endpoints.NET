using Microsoft.EntityFrameworkCore;
using WebApiNET.Models;

namespace WebApiNET.Data
{
    public class UsersDB :DbContext
    {
        public UsersDB(DbContextOptions<UsersDB> options)
            : base(options) { }

        public DbSet<Users> User => Set<Users>();
    }
}
