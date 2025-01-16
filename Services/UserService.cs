using AmazonSimulatorApp.Data.Repositories;
using AmazonSimulatorApp.Data;

namespace AmazonSimulatorApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task AddUser(User user)
        {
            // Check if email already exists
            var existingUser = await _userRepo.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
                throw new InvalidOperationException("A user with this email already exists.");

            // Hash the password
            user.Password = HashingPassword.Hshing(user.Password);

            // Set default values
            user.IsVerified = false;
            user.IsActive = true;

            // Save user
            await _userRepo.AddUserAsync(user);
        }
        public void DeleteUser(int uid)
        {
            var user = _userRepo.GetUserById(uid);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {uid} not found.");

            _userRepo.DeleteUser(uid);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }
        public User GetUSer(string email, string password)
        {
            var user = _userRepo.GetUSer(email, password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            return user;
        }
        public User GetUserById(int uid)
        {
            var user = _userRepo.GetUserById(uid);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {uid} not found.");
            return user;
        }
        public void UpdateUser(User user)
        {
            var existingUser = _userRepo.GetUserById(user.ID);
            if (existingUser == null)
                throw new KeyNotFoundException($"User with ID {user.ID} not found.");

            _userRepo.UpdateUser(user);
        }
    }
}
