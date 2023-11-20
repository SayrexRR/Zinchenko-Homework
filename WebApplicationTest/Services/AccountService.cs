using WebApplicationTest.BussinessLayer.Models;
using WebApplicationTest.DataLayer.Repository;

namespace WebApplicationTest.BussinessLayer.Services
{
    public class AccountService
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
    }
}
