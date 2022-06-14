using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class MovieEntityExtensions {

    public static void Configure(this EntityTypeBuilder<Movie> builder) {

        builder.HasMany(m => m.MovieGenres)
            .WithOne(mg => mg.Movie)
            .HasForeignKey(mg => mg.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.Comments)
            .WithOne(c => c.Movie)
            .HasForeignKey(c => c.MovieId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}