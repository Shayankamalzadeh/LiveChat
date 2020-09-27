using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Application.Interface;
using Application.Model;

using LiveChat.Domain.Models;
using LiveChat.Models;

namespace LiveChat.Application
{
    public class ChatHub
    {
        private readonly ISignalR _signalR;
        private readonly IRepository _repository;

        public ChatHub(ISignalR signalR, IRepository repository)
        {
            _signalR = signalR;
            _repository = repository;
        }

        public async Task SendMessage(SendRequestModel request)
        {
            var signalR = new SignalRModel
            {
                UserId = request.UserId.ToString(),
                SecurityCode = request.SecurityCode
            };
            await _signalR.AddToGroupAsync(signalR);

            var message = new ChatMessage
            {
                SenderId = request.UserId,
                RecipientId = request.RecipientId,
                SecurityCode = request.SecurityCode,
                Text = request.Text,
                SendAt = DateTimeOffset.Now
            };

            await _repository.AddMessage(message);
            await _signalR.SendMessage(message);
        }
        public async Task<IEnumerable<ChatMessage>> GetHistoryMessage(RequestForHistoryMessages request)
        {
            return await _repository.GetHistoryMessage(request);
        }

        public async Task<IEnumerable<UserContact>> GetContactList(RequestForHistoryMessages request)
        {
            return await _repository.GetContactList(request);
        }
    }
}
