using FilmBegetter.DAL.Entities;
using FilmBegetter.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class RoleEntityExtensions {

    public static void Configure(this EntityTypeBuilder<Role> builder) {
        
        builder
            .HasMany(x => x.UserRoles)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId)
            .IsRequired();

        builder.HasData(
            new Role { Name = UserRoles.User, NormalizedName = UserRoles.User.ToUpper() },
            new Role { Name = UserRoles.Moderator, NormalizedName = UserRoles.Moderator.ToUpper() },
            new Role { Name = UserRoles.Admin , NormalizedName = UserRoles.Admin.ToUpper() }
        );
    }
}