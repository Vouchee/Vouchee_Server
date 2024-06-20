using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace Vouchee.Business.Helpers
{
    public static class LinQUtils
    {
        public static IQueryable<TEntity> DynamicFilter<TEntity>(this IQueryable<TEntity> source, TEntity entity)
        {
            if (entity == null)
            {
                return source;
            }

            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity, null);

                if (propertyValue == null)
                {
                    continue;
                }

                if (property.CustomAttributes.Any(a => a.AttributeType == typeof(SkipAttribute)))
                {
                    continue;
                }

                bool isDateTime = typeof(DateTime).IsAssignableFrom(property.PropertyType) || typeof(DateTime?).IsAssignableFrom(property.PropertyType);
                bool isGuid = typeof(Guid).IsAssignableFrom(property.PropertyType) || typeof(Guid?).IsAssignableFrom(property.PropertyType);

                try
                {
                    if (isDateTime)
                    {
                        DateTime dt = (DateTime)propertyValue;
                        source = source.Where($"{property.Name} >= @0 && {property.Name} < @1", dt.Date, dt.Date.AddDays(1));
                    }
                    else if (isGuid)
                    {
                        if ((Guid)propertyValue == Guid.Empty) continue; // Skip empty GUIDs
                        source = source.Where($"{property.Name} == @0", propertyValue);
                    }
                    else if (property.PropertyType.IsGenericType && typeof(ICollection<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition()))
                    {
                        continue; // Skip ICollection properties
                    }
                    else if (property.CustomAttributes.Any(a => a.AttributeType == typeof(ContainAttribute)))
                    {
                        var array = (IList)propertyValue;
                        source = source.Where($"{property.Name}.Any(a => @0.Contains(a))", array);
                    }
                    else if (property.CustomAttributes.Any(a => a.AttributeType == typeof(SortAttribute)))
                    {
                        string[] sort = propertyValue.ToString().Split(", ");
                        if (sort.Length == 2)
                        {
                            if (sort[1].Equals("asc", StringComparison.OrdinalIgnoreCase))
                            {
                                source = source.OrderBy(sort[0]);
                            }
                            else if (sort[1].Equals("desc", StringComparison.OrdinalIgnoreCase))
                            {
                                source = source.OrderBy(sort[0] + " descending");
                            }
                        }
                        else
                        {
                            source = source.OrderBy(sort[0]);
                        }
                    }
                    else if (property.PropertyType == typeof(string))
                    {
                        source = source.Where($"{property.Name}.ToLower().Contains(@0)", ((string)propertyValue).Trim().ToLower());
                    }
                    else
                    {
                        source = source.Where($"{property.Name} == @0", propertyValue);
                    }
                }
                catch (Exception ex)
                {
                    // Log exception or handle it as necessary
                    continue;
                }
            }

            return source;
        }

        public static (int, IQueryable<TResult>) PagingIQueryable<TResult>(this IQueryable<TResult> source, int page, int size, int limitPaging, int defaultPaging)
        {
            if (size > limitPaging)
            {
                size = limitPaging;
            }
            if (size < 1)
            {
                size = defaultPaging;
            }
            if (page < 1)
            {
                page = 1;
            }
            int total = source?.Count() ?? 0;
            IQueryable<TResult> results = source
                .Skip((page - 1) * size)
                .Take(size);
            return (total, results);
        }
    }
}
