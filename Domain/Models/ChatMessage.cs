using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace LiveChat.Domain.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public string SecurityCode { get; set; }

        public string Text { get; set; }
        public DateTimeOffset SendAt { get; set; }
    }
}
