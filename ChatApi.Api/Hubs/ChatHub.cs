using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Hubs
{
    public class ChatHub: Hub
    {
        public override async Task OnConnectedAsync()
         {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Chat");
            await base.OnConnectedAsync();
        }

        public Task SendMessage(string message)
        {
            return Clients.Groups("Chat").SendAsync("message", message);
        }
    }
}
