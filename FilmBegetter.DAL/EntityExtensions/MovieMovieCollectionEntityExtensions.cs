using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class MovieMovieCollectionEntityExtensions {

    public static void Configure(this EntityTypeBuilder<MovieMovieCollection> builder) {

        builder.HasKey(nameof(MovieMovieCollection.MovieId), nameof(MovieMovieCollection.MovieCollectionId));
    }
}