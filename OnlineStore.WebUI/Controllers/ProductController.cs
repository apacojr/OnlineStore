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
        public ActionResult List( int page = 1)
        {
            var model = new ProductListViewModel();
            {
                 model.Products = _repository.Products
                                    .OrderBy(x => x.ProductId)
                                    .Skip((page - 1) * PageSize)
                                    .Take(PageSize);
                 model.PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Products.Count()
                };
            }


            return View(model);
        }
    }
}