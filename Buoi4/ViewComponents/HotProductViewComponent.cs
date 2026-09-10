using Buoi4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi4.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 4,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2490000
                },

                new Product
                {
                    Id = 5,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2490000
                },

                new Product
                {
                    Id = 6,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2490000
                }
            };

            return View(products);
        }
    }
}