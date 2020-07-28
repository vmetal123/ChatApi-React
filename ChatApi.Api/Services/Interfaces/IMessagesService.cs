using ChatApi.Api.Contracts.v1.Requests;
using ChatApi.Api.Contracts.v1.Responses;
using ChatApi.Api.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Services.Interfaces
{
    public interface IMessagesService
    {
        Task<SendMessageResponse> SaveMessage(SendMessageRequest messageDto);
    }
}
