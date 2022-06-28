using FilmBegetter.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmBegetter.DAL.EntityExtensions;

public static class FriendRequestEntityExtensions {

    public static void Configure(this EntityTypeBuilder<FriendRequest> builder) {

        builder.HasOne(x => x.Recipient)
            .WithMany(x => x.RecievedFriendRequests)
            .HasForeignKey(x => x.RecipientId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Sender)
            .WithMany(x => x.SentFriendRequests)
            .HasForeignKey(x => x.SenderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}