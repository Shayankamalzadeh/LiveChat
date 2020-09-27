using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Interface;

using LiveChat.Domain.Models;
using LiveChat.Models;
using LiveChat.Persistance;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository:IRepository
    {

        protected readonly LiveChatDBContext _dbContext;
        public  Task AddMessage(ChatMessage message)
        {
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ChatMessage>> GetHistoryMessage(RequestForHistoryMessages request)
        {
            return await _dbContext.Messages.Where(x => x.SenderId == request.UserId
                                                        && x.SecurityCode == request.SecurityCode)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserContact>> GetContactList(RequestForHistoryMessages request)
        {
            return await _dbContext.UserContacts.Include(x => x.Contact)
                .Where(x => x.UserId == request.UserId).ToListAsync();
        }
    }
}