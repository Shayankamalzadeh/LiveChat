using System.Threading.Tasks;

using Application.Model;

using LiveChat.Domain.Models;

namespace Application.Interface
{
    public interface ISignalR
    {
        Task AddToGroupAsync(SignalRModel signalRModel);

        Task SendMessage(ChatMessage message);
    }
}