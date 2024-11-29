using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class NotificationModel
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; } = DateTime.Now;

        // Navigation properties
        public UserModel Sender { get; set; } = null!;
        public UserModel Receiver { get; set; } = null!;
    }

}
