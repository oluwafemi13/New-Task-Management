using Management.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        [Required]
        [Range(1,3)]
        public NotificationType Type { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Read { get; set; } = false;
    }
}
