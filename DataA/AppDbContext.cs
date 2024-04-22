using Microsoft.EntityFrameworkCore;
using movie_rating_backend.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories {  get; set; }
    public DbSet<User> Users {  get; set; }
    public DbSet<Rating>? Ratings { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rating>().HasKey(x => new { x.MovieId, x.UserId });
    }


}
