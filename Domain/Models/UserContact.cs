
namespace LiveChat.Domain.Models
{
    public class UserContact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserContactId { get; set; }
        public User Contact { get; set; }
    }
}