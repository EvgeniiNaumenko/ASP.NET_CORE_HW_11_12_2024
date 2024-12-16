using Microsoft.AspNetCore.Mvc;
using WebApplication1_HW_11_12_2024.Models;
using WebApplication1_HW_11_12_2024.Data;

namespace WebApplication1_HW_11_12_2024.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_context.Users.Any(u => u.Username == model.Username))
            {
                ModelState.AddModelError("Username", "Имя пользователя уже существует.");
                return View(model);
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Age = model.Age,
                CreditCardNumber = model.CreditCardNumber,
                Website = model.Website
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Регистрация прошла успешно!";
            return RedirectToAction("Index", "Home");
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckUsername(string username)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                return Json($"Имя пользователя \"{username}\" уже занято.");
            }

            return Json(true);
        }
    }
}
