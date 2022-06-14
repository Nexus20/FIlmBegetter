using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class UserEntityExtensions {

    public static void Configure(this EntityTypeBuilder<User> builder) {
        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasMany(x => x.Comments)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId)
            .IsRequired(false);

        builder
            .HasMany(x => x.UserRoles)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired();
    }
}