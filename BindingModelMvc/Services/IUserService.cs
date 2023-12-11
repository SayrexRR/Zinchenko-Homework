using BindingModelMvc.BusinessLayer.Models;

namespace BindingModelMvc.BusinessLayer.Services
{
    public interface IUserService
    {
        List<UserModel> GetUsers();
        UserModel GetUserById(int id);
        void UpdateUser(UserModel user);
        void DeleteUser(int id);
        void AddUser(UserModel user);
    }
}
