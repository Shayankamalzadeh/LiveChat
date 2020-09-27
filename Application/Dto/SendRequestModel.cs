using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveChat.Models
{
    public class SendRequestModel
    {
        public int UserId { get; set; }
        public int RecipientId { get; set; }
        public string SecurityCode { get; set; }
        public string Text { get; set; }
    }
}
