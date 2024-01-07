using ConfitecWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication_Confitec.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
    }
}