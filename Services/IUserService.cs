using AmazonSimulatorApp.Data;

namespace AmazonSimulatorApp.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(int uid);
        IEnumerable<User> GetAllUsers();
        User GetUSer(string email, string password);
        User GetUserById(int uid);
        void UpdateUser(User user);
    }
}