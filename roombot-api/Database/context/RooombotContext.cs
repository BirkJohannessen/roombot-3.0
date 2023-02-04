using Microsoft.EntityFrameworkCore;
using models;

namespace context {
    public class RoombotContext : DbContext {
        protected readonly IConfiguration Configuration;

        public RoombotContext(IConfiguration configuration) {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }


        DbSet<User> tbl_users { get; set; }
        DbSet<Reservation> tbl_reservations { get; set; }

    }
}