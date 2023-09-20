using Management.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management.Application.DTO
{
    public class NotificationDTO
    {
        public int NotificationId { get; set; }
        [Required(ErrorMessage = "Please input a value for the notification Type")]
        [Range(1, 3, ErrorMessage = "Input a Number between the ranges of 1 - 3")]
        public NotificationType Type { get; set; }
        [Required(ErrorMessage = "Please input a value for the notification Type"), StringLength(100)]
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Read { get; set; } = false;
    }
}
