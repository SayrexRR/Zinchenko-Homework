using BindingModelMvc.BusinessLayer.Models;
using BindingModelMvc.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BindingModelMvc.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = userService.GetUsers();

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(user);

                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserModel user = userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(int id ,UserModel user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userService.UpdateUser(user);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserModel user = userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            UserModel user = userService.GetUserById(id);

            if (user != null)
            {
                userService.DeleteUser(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
