using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class MovieGenreEntityExtensions {

    public static void Configure(this EntityTypeBuilder<MovieGenre> builder) {

        builder.HasKey(nameof(MovieGenre.MovieId), nameof(MovieGenre.GenreId));
    }
}