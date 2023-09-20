using Management.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        [Required(ErrorMessage = "Please Enter Task Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please input a value for the task Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please input a valid ddue date")]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Please input a value for the Priority Type")]
        [Range(1,3)]
        public Priority Priority { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Please input a value for the Status Type")]
        [Range(1, 3)]
        public Status Status { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
