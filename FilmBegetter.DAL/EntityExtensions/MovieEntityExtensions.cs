using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class MovieEntityExtensions {

    public static void Configure(this EntityTypeBuilder<Movie> builder) {

        builder.Property(b => b.CreationDate).HasDefaultValueSql("GETDATE()");

        builder.HasMany(m => m.MovieGenres)
            .WithOne(mg => mg.Movie)
            .HasForeignKey(mg => mg.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(m => m.MovieCollections)
            .WithOne(mg => mg.Movie)
            .HasForeignKey(mg => mg.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(m => m.Comments)
            .WithOne(c => c.Movie)
            .HasForeignKey(c => c.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(m => m.Ratings)
            .WithOne(r => r.Movie)
            .HasForeignKey(r => r.MovieId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}