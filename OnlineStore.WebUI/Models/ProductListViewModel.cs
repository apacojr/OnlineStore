﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineStore.Domain.Entities;

namespace OnlineStore.WebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}