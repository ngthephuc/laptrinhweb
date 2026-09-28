using DemoSlide.Models.DataModels;
using DemoSlide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoSlide.Controllers
{
    public class MemberController : Controller
    {
        public static readonly List<Member> members = new List<Member>();

        // Hiển thị danh sách thành viên
        public IActionResult Index()
        {
            return View(members);
        }

        // Hiển thị form đăng ký
        public IActionResult Create()
        {
            return View();
        }

        // Nhận dữ liệu từ form
        [HttpPost]
        public IActionResult Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Member member = new Member();

                member.MemberId = Guid.NewGuid().ToString();
                member.UserName = model.UserName;
                member.FullName = model.FullName;
                member.Password = model.Password;
                member.Email = model.Email;
                member.Phone = model.Phone;
                member.Birthday = model.Birthday;

                members.Add(member);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}