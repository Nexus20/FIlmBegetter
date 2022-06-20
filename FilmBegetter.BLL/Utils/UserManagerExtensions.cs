using FilmBegetter.DAL;
using FilmBegetter.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilmBegetter.BLL.Utils; 

public static class UserManagerExtensions {

    public static async Task<List<User>> FindAllWithDetailsAsync(this UserManager<User> userManager, Expressions<User> expressions) {

        var query = userManager.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .Include(u => u.Subscription)
            .AsQueryable();

        if (expressions.FilterExpressions.Any()) {
            query = expressions.FilterExpressions.Aggregate(query, (current, expression) => current.Where(expression));
        }

        if (expressions.AscendingOrderExpressions.Any()) {
            query = query.OrderBy(expressions.AscendingOrderExpressions[0]);

            if (expressions.AscendingOrderExpressions.Count > 1) {

                for (var i = 1; i < expressions.AscendingOrderExpressions.Count; i++) {
                    query = (query as IOrderedQueryable<User>).ThenBy(expressions.AscendingOrderExpressions[i]);
                }
            }
        }

        if (expressions.DescendingOrderExpressions.Any()) {
            query = query.OrderByDescending(expressions.DescendingOrderExpressions[0]);

            if (expressions.DescendingOrderExpressions.Count > 1) {

                for (var i = 1; i < expressions.DescendingOrderExpressions.Count; i++) {
                    query = (query as IOrderedQueryable<User>).ThenByDescending(expressions.DescendingOrderExpressions[i]);
                }
            }
        }

        if (expressions.SkipCount > 0) {
            query = query.Skip(expressions.SkipCount);
        }

        if (expressions.TakeCount > 0) {
            query = query.Take(expressions.TakeCount);
        }

        return await query.AsNoTracking().ToListAsync();
    }
}