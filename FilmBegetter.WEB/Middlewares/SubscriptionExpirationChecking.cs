using System.Security.Claims;
using FilmBegetter.BLL.Interfaces;

namespace FilmBegetter.WEB.Middlewares; 

public class SubscriptionExpirationChecking {
    
    private readonly RequestDelegate _next;

    public SubscriptionExpirationChecking(RequestDelegate next) {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context, IUserService userService) {

        if (context.User.Identity.IsAuthenticated) {

            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            await userService.CheckSubscriptionExpiration(userId);
        }

        await _next(context);
    }
}