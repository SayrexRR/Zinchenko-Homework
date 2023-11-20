using WebApplicationTest.DataLayer;
using WebApplicationTest.DataLayer.Entities;

namespace WebApplicationTest.DataLayer.Repository
{
    public static class AccountRepository
    {
        public static List<Account> GetAccounts()
        {
            using var context = new WebContext();

            return context.Accounts.ToList();
        }

        public static Account GetFirstAccount()
        {
            using var context = new WebContext();

            return context.Accounts.First();
        }
    }
}
