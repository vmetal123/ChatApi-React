using ChatApi.Api.Models.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Services.Interfaces
{
    public interface ITrackingUsersService
    {
        List<UserConnected> UsersConnected { get; set; }
    }
}
