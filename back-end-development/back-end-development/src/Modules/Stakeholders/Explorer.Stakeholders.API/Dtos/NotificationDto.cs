using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
