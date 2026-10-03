
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreMVC_LAB05.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreMVC_LAB05.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();
        private static int nextId = 1;

        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(
                CategoryController.GetCategories(),
                "CategoryId",
                "CategoryName"
            );
        }

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = nextId++;
                products.Add(product);
                return RedirectToAction("Index");
            }

            LoadCategories();
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            LoadCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var existing = products.FirstOrDefault(
                    p => p.ProductId == product.ProductId);

                if (existing == null)
                    return NotFound();

                existing.ProductName = product.ProductName;
                existing.Price = product.Price;
                existing.Description = product.Description;
                existing.CategoryId = product.CategoryId;

                return RedirectToAction("Index");
            }

            LoadCategories();
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product != null)
                products.Remove(product);

            return RedirectToAction("Index");
        }
    }
}