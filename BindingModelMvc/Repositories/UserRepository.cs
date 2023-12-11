using BindingModelMvc.DataLayer.Entities;
using BindingModelMvc.DataLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace BindingModelMvc.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;

        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public void AddUser(User user)
        {
            userContext.Users.Add(user);
            userContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            userContext.Users.Where(u => u.UserId == id).ExecuteDelete();
        }

        public User GetUserById(int id)
        {
            return userContext.Users.Find(id);
        }

        public List<User> GetUsers()
        {
            return userContext.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            User updatesUser = userContext.Users.Find(user.UserId);

            updatesUser.UserName = user.UserName;
            updatesUser.Password = user.Password;
            updatesUser.Email = user.Email;

            userContext.Users.Update(updatesUser);

            userContext.SaveChanges();
        }
    }
}
