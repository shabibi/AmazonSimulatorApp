﻿using Microsoft.EntityFrameworkCore;

namespace AmazonSimulatorApp.Data.Repositories
{
    public class UserRepo : IUserRepo
    {
        public ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get All users
        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        //Get user by id
        public User GetUserById(int uid)
        {
            try
            {
                return _context.Users.FirstOrDefault(u => u.ID == uid);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }
        //Add new user
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        //Update User 
        public void UpdateUser(User user)
        {
            try
            {
                // Only hash the password if it is updated
                if (!string.IsNullOrEmpty(user.Password))
                {
                    user.Password = HashingPassword.Hshing(user.Password);
                }
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        //Delete User
        public void DeleteUser(int uid)
        {
            try
            {
                var user = GetUserById(uid);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        //Get user by email and passward
        public User GetUSer(string email, string password)
        {
            try
            {

                var user = _context.Users.Where(u => u.Email == email).FirstOrDefault();

                // Compare provided password with the hashed password
                if (user != null && (HashingPassword.Hshing(password) == user.Password))
                {
                    return user;
                }

                return null;  //// Invalid credentials
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }
    }
}
