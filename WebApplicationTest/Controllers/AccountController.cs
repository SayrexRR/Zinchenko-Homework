using Microsoft.AspNetCore.Mvc;
using WebApplicationTest.BussinessLayer.Models;
using WebApplicationTest.BussinessLayer.Services;

namespace WebApplicationTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService accountService;

        public AccountController()
        {
            accountService = new AccountService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<List<Account>> Accounts()
        {
            var accounts = accountService.GetAccounts();

            if (accounts == null)
            {
                return NotFound();
            }

            return View(accounts);
        }

        [HttpGet]
        public ActionResult<Account> FirstAccount()
        {
            var account = accountService.GetFirstAccount();

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }
    }
}
