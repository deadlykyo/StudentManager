using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudentProcessor.Extensions
{
    public static class EnumerableExtensions
    {
        private const int ASCENDING = 0;

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, IEnumerable<KeyValuePair<string, object>> filters)
        {
            if (filters == null || !filters.Any()) return source;
            var parameter = Expression.Parameter(typeof(T));
            var body = filters.Select(filter => Expression.Equal(Expression.PropertyOrField(parameter, filter.Key),
                    Expression.Constant(filter.Value))).Aggregate(Expression.AndAlso);

            var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
            return source.Where(predicate.Compile());
        }

        public static IEnumerable<T> SortBy<T>(this IEnumerable<T> source, List<string> sortColumns)
        {
            if (sortColumns == null || !sortColumns.Any()) return source;

            bool isFirstParameter = true;
            foreach (string columnProps in sortColumns)
            {
                //Sort:Name|0,Gender|1
                var subContent = columnProps.Split('|');
                int direction = subContent.Length == 1 ? ASCENDING : Convert.ToInt32(subContent[1].Trim());
                if (Convert.ToInt32(subContent[1].Trim()) == ASCENDING)
                {
                    if (isFirstParameter)
                        source = source.OrderBy(x => GetPropertyValue(x, subContent[0].Trim()));
                    else
                        source = ((IOrderedEnumerable<T>)source).ThenBy(x => GetPropertyValue(x, subContent[0].Trim()));
                }
                else
                {
                    if (isFirstParameter)
                        source = source.OrderByDescending(x => GetPropertyValue(x, subContent[0].Trim()));
                    else
                        source = ((IOrderedEnumerable<T>)source).ThenByDescending(x => GetPropertyValue(x, subContent[0].Trim()));
                }
                isFirstParameter = false;
            }

            return source;
        }

        private static object GetPropertyValue(object obj, string property)
        {
            System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo.GetValue(obj, null);
        }
    }
}
