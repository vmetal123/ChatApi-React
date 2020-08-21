using ChatApi.Api.Common;
using ChatApi.Api.Models.Hub;
using ChatApi.Api.Services.Interfaces;
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
        private readonly IMessagesService _messagesService;
        private readonly ITrackingUsersService _trackingUsersService;

        public ChatHub(IMessagesService messagesService, ITrackingUsersService trackingUsersService)
        {
            _messagesService = messagesService;
            _trackingUsersService = trackingUsersService;
        }

        public override async Task OnConnectedAsync()
         {
            _trackingUsersService.AddOrUpdate(Context.User.Identity.Name, Context.ConnectionId);
            await Clients.All.SendAsync("ConnectedUsers", _trackingUsersService.GetAllUsersExceptThis(Context.User.Identity.Name));
            await base.OnConnectedAsync();
        }

        public Task SendMessage(MessageInput messageInput)
        {
            var userConnectionId = _trackingUsersService.GetUserInfo(messageInput.User).ConnectionId;
            return Clients.Client(userConnectionId).SendAsync("message", new { Message = messageInput.Message, Date = DateTime.Now, User = messageInput.User });
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _trackingUsersService.Remove(Context.User.Identity.Name);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
