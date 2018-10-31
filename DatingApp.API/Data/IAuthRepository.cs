using System.Threading.Tasks;
using DatingApp.API.Models;
namespace DatingApp.API.Data

{
    public interface IAuthRepository
    {
         Task<User> Register (User user,string Password);
         Task<User> Login(string UserName, string Password);
         Task<bool> UserExsits(string Username);


    }
}