
namespace AmazonSimulatorApp.Data.Repositories
{
    public interface IUserRepo
    {
         Task AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        void DeleteUser(int uid);
        IEnumerable<User> GetAllUsers();
        User GetUSer(string email, string password);
        User GetUserById(int uid);
        void UpdateUser(User user);
    }
}