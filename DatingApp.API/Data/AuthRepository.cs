using System;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        public readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            this._context=context;
        }
        public async Task<User> Login(string UserName, string Password)
        {
            var user=await  _context.Users.FirstOrDefaultAsync(x=>x.UserName==UserName);

            return user;
        }

        public async Task<User> Register(User user, string Password)
        {
            byte[] PasswordHash,PasswordSalt;
            CreatePasswordHash(Password,out PasswordHash,out PasswordSalt);
            user.PasswordHash=PasswordHash;
            user.PasswordSalt=PasswordSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
         using(var hmac=new System.Security.Cryptography.HMACSHA512())
         {
             passwordSalt=hmac.Key;
             passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
         }
        }

        public Task<bool> UserExsits(string Username)
        {
            throw new System.NotImplementedException();
        }
    }
}