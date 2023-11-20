using Microsoft.AspNetCore.Mvc;
using WebApplicationTest.BussinessLayer.Models;
using WebApplicationTest.BussinessLayer.Services;

namespace WebApplicationTest.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactService contactService;

        public ContactController()
        {
            contactService = new ContactService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Contacts()
        {
            var contacts = contactService.GetContacts();

            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }

        [HttpGet]
        public ActionResult<Contact> FirstContact()
        {
            var contact = contactService.GetFirstContact();

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }
    }
}
