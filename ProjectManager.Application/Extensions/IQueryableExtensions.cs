using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjectManager.Domain.Entities;
using System.Linq.Expressions;

namespace ProjectManager.Application.Extensions;

public static class IQueryableExtensions
{
    //public static void
    //    IncludeAllParents(this IIncludableQueryable<DesignObjectEntity, DesignObjectEntity?> Query) 
    //{
    //    var smthing = Query.ThenInclude(a => a.ParentDesignObject);
    //    if (smthing.FirstOrDefault().ParentDesignObject is not null)
    //    {
    //        Query.ThenInclude(a => a.ParentDesignObject);
    //        Query.IncludeAllParents();
    //    }
    //}
    public static IQueryable<TEntity> IncludeAll<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
    {
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return query;
    }

    public static IQueryable<TEntity> IncludeRecursive<TEntity, TProperty>(this IQueryable<TEntity> query,
        Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TEntity : class
    {
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var body = navigationPropertyPath.Body;

        if (body is MemberExpression memberExpression)
        {
            var navigationProperty = memberExpression.Member.Name;

            query = query.Include(navigationProperty);

            // Здесь мы предполагаем, что навигационное свойство также является иерархической сущностью.
            // Если это не так, нужно добавить дополнительную проверку или параметр для указания этого.
            var navigationPropertyType = typeof(TProperty);
            var subParameter = Expression.Parameter(navigationPropertyType, "y");
            var subProperty = Expression.Lambda<Func<TProperty, object>>(
                Expression.Convert(Expression.Property(subParameter, navigationProperty), typeof(object)),
                subParameter);

            query = query.IncludeRecursive(navigationPropertyPath);
        }

        return query;
    }
}