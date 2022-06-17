namespace FilmBegetter.BLL.Dto;

public class UserDto {
    
    public string Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public bool IsBanned { get; set; }

    public DateTime? UnbanDate { get; set; }
    
    public ICollection<MovieCollectionDto> MovieCollections { get; set; }

    public ICollection<RatingDto> Ratings { get; set; }

    public ICollection<UserDto> Friends { get; set; }

    public ICollection<CommentDto> Comments { get; set; }
    
    public List<RoleDto> Roles { get; set; }

    public SubscriptionDto Subscription { get; set; }
    
    public string SubscriptionId { get; set; }
}