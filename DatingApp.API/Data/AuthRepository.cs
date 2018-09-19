using System;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Datacontext _context;
        public AuthRepository(Datacontext context)
        {
            _context = context;

        }

        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            byte[] PasswordHash, PasswordSalt;
            createPasswordHash(password, out PasswordHash, out PasswordSalt);

            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        public Task<bool> UserExist(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}