
using Microsoft.AspNetCore.Mvc;
using NetCoreMVC_LAB05.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreMVC_LAB05.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Category> categories = new List<Category>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.CategoryId = nextId++;
                categories.Add(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var existing = categories.FirstOrDefault(
                    c => c.CategoryId == category.CategoryId);

                if (existing == null)
                    return NotFound();

                existing.CategoryName = category.CategoryName;
                existing.Description = category.Description;

                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == id);

            if (category != null)
                categories.Remove(category);

            return RedirectToAction("Index");
        }

        public static List<Category> GetCategories()
        {
            return categories;
        }
    }
}