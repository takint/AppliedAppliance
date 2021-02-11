using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Common.Queries
{
    public abstract class BaseListQuery<T, TKey> where T : BaseEntity<TKey>
    {
        public virtual KeyValuePair<string, string> Sorting { get; set; } = new KeyValuePair<string, string>("id", "asc");
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int ParentId { get; set; } = 0;
        public string SearchTerm { get; set; }
        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderByMap { get; set; }

        public virtual Expression<Func<T, bool>> BasedFilter => (x => !x.Deleted && !x.Archived);
        public abstract Dictionary<KeyValuePair<string, string>, Func<IQueryable<T>, IOrderedQueryable<T>>> OrderByMaps { get; }

        public Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderByMap(string sortField, string sortDirection)
        {
            var sortingField = new KeyValuePair<string, string>(sortField, sortDirection);
            return OrderByMaps.ContainsKey(sortingField) ? OrderByMaps[sortingField] : OrderByMaps[Sorting];
        }

        public BaseListQuery() : this(1, 10)
        {
        }

        public BaseListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderByMap = GetOrderByMap(Sorting.Key, Sorting.Value);
        }

        public BaseListQuery(int pageNumber, int pageSize, string sortField, string sortDirection)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderByMap = GetOrderByMap(sortField, sortDirection);
        }

        public BaseListQuery(QueryStateModel queryState)
        {
            PageNumber = queryState.Page;
            PageSize = queryState.PageSize;
            ParentId = queryState.ParentId != 0 ? queryState.ParentId : 0;
            SearchTerm = queryState.SearchTerm ?? "";
            OrderByMap = GetOrderByMap(queryState.SortColumn, queryState.SortDirection);
        }
    }
}
