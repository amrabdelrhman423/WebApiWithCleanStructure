using testapi.Models;

namespace testapi.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username,string passsword);

        Task<bool> UserExistes(string username);
    }
}
