using BindingModelMvc.DataLayer.Entities;

namespace BindingModelMvc.DataLayer.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void AddUser(User user);
    }
}
