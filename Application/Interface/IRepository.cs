using System.Collections.Generic;
using System.Threading.Tasks;

using LiveChat.Domain.Models;
using LiveChat.Models;

namespace Application.Interface
{
    public interface IRepository
    {
        Task AddMessage(ChatMessage message);

        Task<IEnumerable<ChatMessage>> GetHistoryMessage(RequestForHistoryMessages request);

        Task<IEnumerable<UserContact>> GetContactList(RequestForHistoryMessages request);
    }
}