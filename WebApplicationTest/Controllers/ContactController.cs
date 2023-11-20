using Microsoft.AspNetCore.Mvc;
using WebApplicationTest.BussinessLayer;
using WebApplicationTest.BussinessLayer.Models;

namespace WebApplicationTest.Controllers
{
    public class ContactController : Controller
    {
        private readonly WebService webService;

        public ContactController()
        {
            webService = new WebService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Contacts()
        {
            var contacts = webService.GetContacts();

            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }

        [HttpGet]
        public ActionResult<Contact> FirstContact()
        {
            var contact = webService.GetFirstContact();

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }
    }
}
