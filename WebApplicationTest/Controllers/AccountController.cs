using Microsoft.AspNetCore.Mvc;
using WebApplicationTest.BussinessLayer;
using WebApplicationTest.BussinessLayer.Models;

namespace WebApplicationTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly WebService webService;

        public AccountController()
        {
            webService = new WebService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<List<Account>> Accounts()
        {
            var accounts = webService.GetAccounts();

            if (accounts == null)
            {
                return NotFound();
            }

            return View(accounts);
        }

        [HttpGet]
        public ActionResult<Account> FirstAccount()
        {
            var account = webService.GetFirstAccount();

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }
    }
}
