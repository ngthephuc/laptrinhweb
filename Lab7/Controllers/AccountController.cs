
using Microsoft.AspNetCore.Mvc;
using NetCoreMVC_LAB05.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreMVC_LAB05.Controllers
{
    public class AccountController : Controller
    {

        private static List<Account> accounts = new List<Account>();

        public IActionResult Index()
        {
            return View(accounts);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                account.Id = accounts.Count + 1;
                accounts.Add(account);

                return RedirectToAction("Index");
            }

            return View(account);
        }

        public IActionResult Edit(int id)
        {
            var account = accounts.FirstOrDefault(a => a.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        [HttpPost]
        public IActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                var existing = accounts.FirstOrDefault(a => a.Id == account.Id);

                if (existing == null)
                {
                    return NotFound();
                }

                existing.FullName = account.FullName;
                existing.Email = account.Email;
                existing.Phone = account.Phone;
                existing.Address = account.Address;
                existing.Avatar = account.Avatar;
                existing.Birthday = account.Birthday;
                existing.Gender = account.Gender;
                existing.Password = account.Password;
                existing.Facebook = account.Facebook;

                return RedirectToAction("Index");
            }

            return View(account);
        }

        public IActionResult Delete(int id)
        {
            var account = accounts.FirstOrDefault(a => a.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var account = accounts.FirstOrDefault(a => a.Id == id);

            if (account != null)
            {
                accounts.Remove(account);
            }

            return RedirectToAction("Index");
        }
    }
}