using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions; 

public static class GenreEntityExtensions {

    public static void Configure(this EntityTypeBuilder<Genre> builder) {

        builder.Property(b => b.CreationDate).HasDefaultValueSql("GETDATE()");

        builder.HasIndex(g => g.Name).IsUnique();

        builder.HasMany(m => m.MovieGenres)
            .WithOne(mg => mg.Genre)
            .HasForeignKey(mg => mg.GenreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}