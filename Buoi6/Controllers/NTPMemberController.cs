using Buoi6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi6.Controllers
{
    public class NTPMemberController : Controller
    {
        //mock data
        private static readonly List<NTPMember> _ntpMember = new List<NTPMember>()
        {
             new NTPMember()
        {
            NTPMemberID = Guid.NewGuid().ToString(),
            NTPMemberUserName = "thephuc",
            NTPMemberPassword = "phuc2311@",
            NTPMemberFullName = "Nguyen The Phuc",
            NTPMemberEmail = "thephuc@example.com"
        },

        new NTPMember()
        {
            NTPMemberID = Guid.NewGuid().ToString(),
            NTPMemberUserName = "tuan",
            NTPMemberPassword = "tuan123@",
            NTPMemberFullName = "Tran Quang Tuan",
            NTPMemberEmail = "tuan@example.com"
        },

        new NTPMember()
        {
            NTPMemberID = Guid.NewGuid().ToString(),
            NTPMemberUserName = "khai",
            NTPMemberPassword = "khai123@",
            NTPMemberFullName = "Pham Ngoc Khai",
            NTPMemberEmail = "khai@example.com"
        },

        new NTPMember()
        {
            NTPMemberID = Guid.NewGuid().ToString(),
            NTPMemberUserName = "chien",
            NTPMemberPassword = "chien123@",
            NTPMemberFullName = "Nguyen Van Chien",
            NTPMemberEmail = "chien@example.com"
        },

        new NTPMember()
        {
            NTPMemberID = Guid.NewGuid().ToString(),
            NTPMemberUserName = "huong",
            NTPMemberPassword = "huong123@",
            NTPMemberFullName = "Tran Duy Huong",
            NTPMemberEmail = "huong@example.com"
        }
        };
            

        public IActionResult NTPIndex()
        {
            return View("Index", _ntpMember);
        }

        public IActionResult NTPCreate()
        {

            return View("Create");
        }

        [HttpPost]
        public IActionResult NTPCreate(NTPMember ntpMember)
        {
            ntpMember.NTPMemberID=Guid.NewGuid().ToString();
            _ntpMember.Add(ntpMember);
            return RedirectToAction();
        }

        public IActionResult NTPEdit(string id)
        {
            var ntpMember = _ntpMember.FirstOrDefault(x => x.NTPMemberID.Equals( id));
            return View("Edit",ntpMember);
        }

        [HttpPost]
        public IActionResult NTPEdit(string id, NTPMember ntpMember)
        {
            for (int i = 0; i < _ntpMember.Count; i++)
            {
                if (_ntpMember[i].NTPMemberID == id)
                {
                    _ntpMember[i].NTPMemberID = ntpMember.NTPMemberID;
                    _ntpMember[i].NTPMemberUserName = ntpMember.NTPMemberUserName;
                    _ntpMember[i].NTPMemberPassword = ntpMember.NTPMemberPassword;
                    _ntpMember[i].NTPMemberFullName = ntpMember.NTPMemberFullName;
                    _ntpMember[i].NTPMemberEmail = ntpMember.NTPMemberEmail;
                    break;
                }
            }
            return RedirectToAction("NTPIndex");
        }

        public IActionResult NTPGetDetails()
        {
            var ntpMember = new NTPMember()
            {
                NTPMemberID = Guid.NewGuid().ToString(),
                NTPMemberUserName = "thephuc",
                NTPMemberPassword = "phuc2311@",
                NTPMemberFullName = "Nguyen The Phuc",
                NTPMemberEmail = "thephuc@example.com"
            };
            return View(ntpMember);
        }
    }
}
