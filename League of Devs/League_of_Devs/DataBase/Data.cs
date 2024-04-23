using Microsoft.EntityFrameworkCore;
using League_of_Devs.Models;

namespace League_of_Devs.DateBase
{
    public class Data:DbContext
    {
       
        public DbSet<AccountsModel> accounts { get; set; }
        public DbSet<PostsModel> posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Builder)
        {
            Builder.UseSqlServer("Data Source=.;Initial Catalog=League_of_Devs;Integrated Security=True");
        }
    }
}
