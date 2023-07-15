﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MySchoolApp.Utilitiea
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;


        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PagedList<T> Create(IQueryable<T> collection, int pageNumber)
        {
            int count = collection.Count();
            var items = collection.Skip(10 * (pageNumber - 1)).Take(10).ToList();
            return new PagedList<T>(items, count, pageNumber, 10);
        }
    }
}
