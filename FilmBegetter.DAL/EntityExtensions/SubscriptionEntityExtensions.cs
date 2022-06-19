using FilmBegetter.DAL.Entities;
using FilmBegetter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class SubscriptionEntityExtensions {

    public static void Configure(this EntityTypeBuilder<Subscription> builder) {

        builder.Property(b => b.CreationDate).HasDefaultValueSql("GETDATE()");

        builder.HasIndex(s => s.Type).IsUnique();
        
        builder.HasData(new List<Subscription>() {
            new Subscription() {
                Id = Guid.NewGuid().ToString(),
                Type = SubscriptionTypes.Basic
            },
            new Subscription() {
                Id = Guid.NewGuid().ToString(),
                Type = SubscriptionTypes.Premium
            }
        });
    }
}