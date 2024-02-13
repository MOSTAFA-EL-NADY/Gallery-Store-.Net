
namespace Gallery.GallleryStoreContext
{
    public class StoreContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Image> Images { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
