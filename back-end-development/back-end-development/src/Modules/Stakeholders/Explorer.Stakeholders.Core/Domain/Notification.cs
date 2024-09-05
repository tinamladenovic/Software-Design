using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class Notification : Entity
    {
        public long SenderId { get; private set; }
        public long ReceiverId { get; private set; }
        public string Message { get; private set; }
        public bool IsRead { get; private set; }

        public Notification()
        {

        }
        public Notification(long senderId, long receiverId, string message, bool isRead)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Message = message;
            IsRead = isRead;
            if (string.IsNullOrWhiteSpace(Message)) throw new ArgumentException("Invalid message");
        }
    }
}
