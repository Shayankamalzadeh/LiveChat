using LiveChat.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace LiveChat.Persistance
{
    public class LiveChatDBContext : DbContext
    {
        public LiveChatDBContext(DbContextOptions<LiveChatDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



        }



        public DbSet<User> User { get; set; }
        public DbSet<ChatMessage> Messages { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
    }
}

