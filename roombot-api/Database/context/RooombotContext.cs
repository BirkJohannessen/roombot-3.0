using Microsoft.EntityFrameworkCore;
using models;

namespace context {
    public class RoombotContext : DbContext {

        public RoombotContext(DbContextOptions<RoombotContext> options) : base(options) { }

        public DbSet<User> tbl_users { get; set; }
        public DbSet<Reservation> tbl_reservations { get; set; }

    }
}