using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class MovieCollectionEntityExtensions {

    public static void Configure(this EntityTypeBuilder<MovieCollection> builder) {

        builder.Property(b => b.CreationDate).HasDefaultValueSql("GETDATE()");

        builder.HasMany(m => m.MovieCollections)
            .WithOne(mg => mg.MovieCollection)
            .HasForeignKey(mg => mg.MovieCollectionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}