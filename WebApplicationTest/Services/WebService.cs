using WebApplicationTest.BussinessLayer.Models;
using WebApplicationTest.DataLayer.Repository;

namespace WebApplicationTest.BussinessLayer.Services
{
    public class WebService
    {
        public List<Account> GetAccounts()
        {
            var accounts = AccountRepository.GetAccounts();

            return accounts.Select(a => new Account
            {
                Id = a.Id,
                Name = a.Name,
                Password = a.Password,
            }).ToList();
        }

        public Account GetFirstAccount()
        {
            var account = AccountRepository.GetFirstAccount();

            return new Account
            {
                Id = account.Id,
                Name = account.Name,
                Password = account.Password,
            };
        }

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
