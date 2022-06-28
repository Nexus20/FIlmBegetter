using FilmBegetter.DAL.Entities;
using FilmBegetter.DAL.EntityExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmBegetter.DAL; 

public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole,
    IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>> {
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        if (!Database.IsInMemory()) {
            Database.Migrate();
        }
    }

    public DbSet<Comment> Comments { get; set; }
    
    public DbSet<Genre> Genres { get; set; }
    
    public DbSet<Movie> Movies { get; set; }
    
    public DbSet<MovieCollection> MovieCollections { get; set; }

    public DbSet<MovieMovieCollection> MovieMovieCollections { get; set; }
    
    public DbSet<Rating> Ratings { get; set; }
    
    public DbSet<Subscription> Subscriptions { get; set; }
    
    public DbSet<MovieGenre> MovieGenres { get; set; }
    
    public DbSet<CommentRatingUser> CommentRatingUsers { get; set; }
    
    public DbSet<FriendRequest> FriendRequests { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder) {

        base.OnModelCreating(builder);

        builder.Entity<Comment>().Configure();
        builder.Entity<Genre>().Configure();
        builder.Entity<MovieGenre>().Configure();
        builder.Entity<MovieMovieCollection>().Configure();
        builder.Entity<Movie>().Configure();
        builder.Entity<MovieCollection>().Configure();
        builder.Entity<Rating>().Configure();
        builder.Entity<Subscription>().Configure();
        builder.Entity<User>().Configure();
        builder.Entity<Role>().Configure();
        builder.Entity<CommentRatingUser>().Configure();
        builder.Entity<FriendRequest>().Configure();
        builder.Entity<UserRole>().HasKey(p => new { p.UserId, p.RoleId });
    }
}