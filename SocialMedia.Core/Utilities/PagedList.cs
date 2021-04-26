using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialMedia.Core.Utilities
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int ToTalPages { get; set; }
        public int PageSize {get;set;}
        public int TotalCount { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < ToTalPages;
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : (int?)null;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize) 
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            ToTalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
            AddRange(items);
        }

        public static PagedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize) 
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
