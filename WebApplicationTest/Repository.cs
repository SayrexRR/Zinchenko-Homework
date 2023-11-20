using WebApplicationTest.DataLayer.Entities;

namespace WebApplicationTest.DataLayer
{
    public static class Repository
    {
        public static List<Account> GetAccounts()
        {
            using var context = new WebContext();

            return context.Accounts.ToList();
        }

        public static List<Contact> GetContacts()
        {
            using var context = new WebContext();

            return context.Contacts.ToList();
        }
    }
}
