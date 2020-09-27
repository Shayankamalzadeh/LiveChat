using System.Threading.Tasks;

using Application.Interface;
using Application.Model;

using LiveChat.Domain.Models;

using Microsoft.AspNetCore.SignalR;

namespace Infrastructure
{
    public class SignalR : Hub, ISignalR
    {
        public async Task AddToGroupAsync(SignalRModel signalRModel)
        {
            await Groups.AddToGroupAsync(signalRModel.UserId, signalRModel.SecurityCode);
        }

        public async Task SendMessage(ChatMessage message)
        {
            await Clients.Group(message.SecurityCode).SendAsync("ReceiveMessage", message.SenderId, message.SendAt, message.Text);

        }
    }
}