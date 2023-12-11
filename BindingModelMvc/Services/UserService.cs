using BindingModelMvc.BusinessLayer.Models;
using BindingModelMvc.DataLayer.Repositories;

namespace BindingModelMvc.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void AddUser(UserModel user)
        {
            userRepository.AddUser(new DataLayer.Entities.User
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
            });
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }

        public UserModel GetUserById(int id)
        {
            var user = userRepository.GetUserById(id);

            return new UserModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
            };
        }

        public List<UserModel> GetUsers()
        {
            var users = userRepository.GetUsers();

            return users.Select(u => new UserModel
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Email = u.Email,
                Password = u.Password,
            }).ToList();
        }

        public void UpdateUser(UserModel user)
        {
            userRepository.UpdateUser(new DataLayer.Entities.User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
            });
        }
    }
}
