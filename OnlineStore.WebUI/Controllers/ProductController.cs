using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Domain.Abstract;
using OnlineStore.WebUI.Models;

namespace OnlineStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public int PageSize = 3;

        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }

        // GET: Product
        public ActionResult List(string category, int page = 1)
        {
            var model = new ProductListViewModel
            {
                Products = _repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(x => x.ProductId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =  category == null?
                    _repository.Products.Count():
                    _repository.Products.Count(p => p.Category == category)
                },

                CurrentCategory = category

            };


            return View(model);
        }
    }
}