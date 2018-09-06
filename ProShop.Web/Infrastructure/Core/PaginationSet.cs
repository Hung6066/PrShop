﻿using System.Collections.Generic;
using System.Linq;

namespace ProShop.Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        public int Page { get; set; }

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int MaxPage { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}