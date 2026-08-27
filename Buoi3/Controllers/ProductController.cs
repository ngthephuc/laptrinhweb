using Microsoft.AspNetCore.Mvc;
using Buoi3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Buoi3.Controllers
{
    public class ProductController : Controller
    {
        // Danh sách danh mục
        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Quần áo" },
                new Category { Id = 2, Name = "Túi xách" },
                new Category { Id = 3, Name = "Đồng hồ" },
                new Category { Id = 4, Name = "Ti vi" },
                new Category { Id = 5, Name = "Tủ lạnh" },
                new Category { Id = 6, Name = "Máy bơm" },
                new Category { Id = 7, Name = "Quạt điện" },
                new Category { Id = 8, Name = "Lò sưởi" }
            };
        }

        // Danh sách sản phẩm
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Bộ đồ bơi cho trẻ em nam",
                    Image = "sp1.png",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi cho trẻ em nam chất lượng cao, thiết kế đẹp và thoải mái.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                },

                new Product
                {
                    Id = 2,
                    Name = "Bộ đồ bơi cho trẻ em nữ",
                    Image = "sp2.png",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi cho trẻ em nữ nhiều màu sắc, chất liệu tốt.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                },

                new Product
                {
                    Id = 3,
                    Name = "Bộ đồ bơi cho trẻ từ 3-5 tuổi",
                    Image = "sp3.png",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Sản phẩm dành cho trẻ từ 3 đến 5 tuổi.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                },

                new Product
                {
                    Id = 4,
                    Name = "Bộ đồ bơi cho trẻ em trai",
                    Image = "sp4.png",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi trẻ em với thiết kế năng động.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                },

                new Product
                {
                    Id = 5,
                    Name = "Túi thời trang mẫu mới 2021",
                    Image = "sp5.png",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 2,
                    Description = "Túi thời trang nữ kiểu dáng hiện đại.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                },

                new Product
                {
                    Id = 6,
                    Name = "Túi thời trang da cá sấu",
                    Image = "sp6.png",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 2,
                    Description = "Túi thời trang da cá sấu cao cấp.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                }
            };
        }

        // Danh sách sản phẩm
        public IActionResult Index(int? categoryId)
        {
            List<Category> categories = GetCategories();
            List<Product> products = GetProducts();

            // Lọc sản phẩm theo danh mục
            if (categoryId.HasValue)
            {
                products = products
                    .Where(x => x.CategoryId == categoryId.Value)
                    .ToList();
            }

            ViewBag.Categories = categories;

            return View(products);
        }

        // Chi tiết sản phẩm
        public IActionResult Detail(int id)
        {
            List<Product> products = GetProducts();

            Product? product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}