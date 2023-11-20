using WebApplicationTest.DataLayer;
using WebApplicationTest.DataLayer.Entities;

namespace WebApplicationTest.DataLayer.Repository
{
    public static class ContactRepository
    {
        public static List<Contact> GetContacts()
        {
            using var context = new WebContext();

            return context.Contacts.ToList();
        }

        public static Contact GetFirstContact()
        {
            using var context = new WebContext();

            return context.Contacts.First();
        }
    }
}
