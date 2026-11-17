
using Microsoft.AspNetCore.Mvc;
using NguyenThePhuc_241230818_DeThiMau.Data;
using NguyenThePhuc_241230818_DeThiMau.Models;
using System.Diagnostics;
using System.Linq;

namespace NguyenThePhuc_241230818_DeThiMau.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLHangHoaContext _context;

        public HomeController(QLHangHoaContext context)
        {
            _context = context;
        }

        // Trang chủ - Câu 2 và Câu 3
        public IActionResult Index()
        {
            ViewBag.LoaiHangs = _context.LoaiHangs.ToList();

            var danhSachHangHoa = _context.HangHoas
                .Where(h => h.Gia >= 100)
                .ToList();

            return View(danhSachHangHoa);
        }

        // Câu 4 - Lọc hàng hóa bằng AJAX
        public IActionResult LocHangHoa(int maLoai)
        {
            var query = _context.HangHoas
                .Where(h => h.Gia >= 100);

            if (maLoai != 0)
            {
                query = query.Where(h => h.MaLoai == maLoai);
            }

            var danhSach = query.ToList();

            return PartialView("_DanhSachHangHoa", danhSach);
        }
        // Hiển thị trang thêm hàng hóa
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.LoaiHangs = _context.LoaiHangs.ToList();
            return View();
        }
        // Xử lý thêm hàng hóa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                _context.HangHoas.Add(hangHoa);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.LoaiHangs = _context.LoaiHangs.ToList();
            return View(hangHoa);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
