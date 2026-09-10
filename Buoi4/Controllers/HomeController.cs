using Buoi4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2490000
                },

                new Product
                {
                    Id = 2,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2490000
                },

                new Product
                {
                    Id = 3,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2490000
                }
            };

            return View(products);
        }
    }
}