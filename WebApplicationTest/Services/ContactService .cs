using WebApplicationTest.BussinessLayer.Models;
using WebApplicationTest.DataLayer.Repository;

namespace WebApplicationTest.BussinessLayer.Services
{
    public class ContactService
    {
        public List<Contact> GetContacts()
        {
            var contacts = ContactRepository.GetContacts();

            return contacts.Select(a => new Contact
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                Phone = a.Phone,
            }).ToList();
        }

        public Contact GetFirstContact()
        {
            var contact = ContactRepository.GetFirstContact();

            return new Contact
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
            };
        }
    }
}
