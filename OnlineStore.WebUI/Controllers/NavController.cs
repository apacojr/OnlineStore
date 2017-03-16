using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Domain.Abstract;

namespace OnlineStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private new IProductRepository _repository;

        public NavController(IProductRepository repo)
        {
            _repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = _repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}