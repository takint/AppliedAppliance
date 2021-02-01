using System;
using System.Linq;

namespace Application.Common.Models
{
    public class OrderedList<T>
    {
        public static  IOrderedQueryable<T> CreateAsync(IQueryable<T> source, Func<IQueryable<T>, IOrderedQueryable<T>> orderQuery)
        {
            return orderQuery(source);
        }
    }
}
