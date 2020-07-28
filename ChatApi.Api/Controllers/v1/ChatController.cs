using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApi.Api.Contracts.v1.Requests;
using ChatApi.Api.Hubs;
using ChatApi.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatApi.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IMessagesService _messagesService;

        public ChatController(IHubContext<ChatHub> hubContext, IMessagesService messagesService)
        {
            _hubContext = hubContext;
            _messagesService = messagesService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SendMessageRequest request)
        {
            var sendMessageResult = await _messagesService.SaveMessage(request);

            if (!sendMessageResult.Success) return BadRequest(sendMessageResult);

            await _hubContext.Clients.User(request.To).SendAsync("Message", new { Message = request.Text, Date = DateTime.Now, User = sendMessageResult.User, DateTime = DateTime.Now });

            return Ok(sendMessageResult);
        }
    }
}
