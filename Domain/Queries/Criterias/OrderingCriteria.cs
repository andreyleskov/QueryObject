using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Domain.Queries
{
    class OrderingCriteria<T> : ICriteria<T, Tuple<string, OrderDirection>[]>
    {
        private readonly IQueryable<T> _unorderedSet;

        public OrderingCriteria(IQueryable<T> unorderedSet)
        {
            _unorderedSet = unorderedSet;
        }

        public static IQueryable<TEntity> OrderBy<TEntity>(IQueryable<TEntity> source, string orderByProperty,
                          OrderDirection desc)
        {
            string command = desc == OrderDirection.Descending ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }

        public IQueryable<T> Apply(Tuple<string,OrderDirection>[] fields)
        {
            IQueryable<T> query = _unorderedSet;
            foreach (var field in fields)
            {
                if (typeof (T).GetProperty(field.Item1) == null)
                    throw new ArgumentOutOfRangeException("Cannot find public property " + field.Item1);
                query = OrderBy(query, field.Item1, field.Item2);
            }
            return query;
        }
    }
}
