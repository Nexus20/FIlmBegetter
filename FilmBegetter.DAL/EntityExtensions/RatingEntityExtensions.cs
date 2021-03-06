using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class RatingEntityExtensions {

    public static void Configure(this EntityTypeBuilder<Rating> builder) {
        builder.Property(b => b.CreationDate).HasDefaultValueSql("GETDATE()");
    }
}