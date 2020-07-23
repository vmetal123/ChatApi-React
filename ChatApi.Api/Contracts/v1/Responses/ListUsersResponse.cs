using ChatApi.Api.Identity.ViewModels;
using System.Collections.Generic;

namespace ChatApi.Api.Contracts.v1.Responses
{
    public class ListUsersResponse
    {
        public bool Success { get; set; }
        public List<UserDto> Users { get; set; }
    }
}
