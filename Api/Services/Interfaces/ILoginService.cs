using Api.Models.Responses;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface ILoginService
    {
       Task< LoginResponse> ValidateUser(string email, string password);
    }
}
