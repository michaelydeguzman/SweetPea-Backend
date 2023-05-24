﻿namespace Common.Models
{
    public class PaginatedList<T>
    {
        public IReadOnlyCollection<T> Items { get; set; }

        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public PaginatedList(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize) 
        {
            PageNumber = pageNumber; 
            TotalPages = (int)Math.Ceiling(count/(double)pageSize);
            TotalCount = count;
            Items = items;
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public static PaginatedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}