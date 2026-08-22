using Microsoft.AspNetCore.Mvc;
using _241230818_NTP.Models;

namespace _241230818_NTP.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    ID = 1,
                    Name = "Product 1",
                    Price = 500000,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/p1.png"
                },

                new Product
                {
                    ID = 2,
                    Name = "Product 2",
                    Price = 700000,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/p2.png "
                },

                new Product
                {
                    ID = 3,
                    Name = "Product 3",
                    Price = 550000,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/p3.png "
                },

                new Product
                {
                    ID = 4,
                    Name = "Product 4",
                    Price = 550000,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/p4.png"
                }
            };

            return View(products);
        }
    }
}