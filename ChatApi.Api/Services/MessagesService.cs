using ChatApi.Api.Contracts.v1.Requests;
using ChatApi.Api.Contracts.v1.Responses;
using ChatApi.Api.Models;
using ChatApi.Api.Models.ViewModels;
using ChatApi.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Services
{
    public class MessagesService: IMessagesService
    {
        private readonly ChatDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public MessagesService(ChatDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        
        public async Task<SendMessageResponse> SaveMessage(SendMessageRequest messageDto)
        {
            try
            {
                var message = new Message { Text = messageDto.Text, Date = DateTime.Now, UserId = new Guid(_currentUserService.GetUserId()), UserName = _currentUserService.GetUserName(), To = messageDto.To };

                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();

                return new SendMessageResponse { Success = true };
            }
            catch (Exception)
            {
                return new SendMessageResponse { Success = false, Error = "An error ocurred" };
            }
        }
    }
}
