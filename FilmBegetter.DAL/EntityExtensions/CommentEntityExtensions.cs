using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class CommentEntityExtensions {

    public static void Configure(this EntityTypeBuilder<Comment> builder) {

        builder
            .HasMany(c => c.Answers)
            .WithOne(c => c.ParentComment)
            .HasForeignKey(c => c.ParentCommentId);
    }
}