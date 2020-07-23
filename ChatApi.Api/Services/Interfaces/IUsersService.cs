using ChatApi.Api.Contracts.v1.Requests;
using ChatApi.Api.Contracts.v1.Responses;
using System.Threading.Tasks;

namespace ChatApi.Api.Services.Interfaces
{
    public interface IUsersService
    {
        Task<LoginUserResponse> Login(LoginUserRequest request);
        Task<RegisterUserResponse> Register(RegisterUserRequest request);
        Task<ListUsersResponse> Users();
    }
}
