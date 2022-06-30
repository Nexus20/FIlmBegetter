using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class CommentRatingEntityExtensions {

    public static void Configure(this EntityTypeBuilder<CommentRatingUser> builder) {

        builder.HasKey(nameof(CommentRatingUser.UserId), nameof(CommentRatingUser.CommentId));
    }
}