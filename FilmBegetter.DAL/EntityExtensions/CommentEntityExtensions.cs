using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class CommentEntityExtensions {

    public static void Configure(this EntityTypeBuilder<Comment> builder) {

        builder.Property(b => b.CreationDate).HasDefaultValueSql("GETDATE()");

        builder.HasMany(c => c.CommentRatings)
            .WithOne(cru => cru.Comment)
            .HasForeignKey(cru => cru.CommentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}