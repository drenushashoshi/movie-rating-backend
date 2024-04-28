using Microsoft.EntityFrameworkCore;
using movie_rating_backend.Entity;

public class AppDbContext : DbContext
{

   
    public AppDbContext() { }
    public AppDbContext(DbContextOptions<AppDbContext> options)
     : base(options)
    {
    }


    public virtual DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories {  get; set; }
    public virtual DbSet<User> Users {  get; set; }
    public DbSet<Rating>? Ratings { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rating>().HasKey(x => new { x.MovieId, x.UserId });
    }

}
