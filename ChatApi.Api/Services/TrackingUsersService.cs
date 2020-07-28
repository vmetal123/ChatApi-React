using ChatApi.Api.Models.Hub;
using ChatApi.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Services
{
    public class TrackingUsersService: ITrackingUsersService
    {
        public List<UserConnected> UsersConnected { get; set; }

    }
}
