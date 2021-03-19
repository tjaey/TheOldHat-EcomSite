using System;
using Microsoft.AspNetCore.Mvc;
using TheOldHat.Common.Interfaces;
using TheOldHat.Models;
using TheOldHat.Domain;

namespace TheOldHat.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            var model = new ProductViewModel(products);

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel model)
        {
            var product = new Product(model.Id, model.Name, model.Count, model.Description);

            if(product == null)
            {
                return View(model);
            }

            _productRepository.Add(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _productRepository.GetOne(id);

            var model = new ProductUpdateViewModel(product);

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel model)
        {
            var product = _productRepository.GetOne(model.Id);

            if(product == null)
            {
                return View(model);
            }

            product.ChangeName(model.Name);
            product.ChangeCount(model.Count);
            product.ChangeDescription(model.Description);

            _productRepository.Update(product);

            return RedirectToAction("Index");
        }

    }
}
