using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTOs
{
    public class ChatWebhookPayload
    {
        public string Event { get; set; } 
        public string Message { get; set; } 
        public string UserId { get; set; } 
    }
}