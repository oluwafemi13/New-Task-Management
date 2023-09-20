using Management.Core.Entities;
using Management.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTO
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        [StringLength(50)]
        [Required]
        public string? Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        [Required]
        public Status Status { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public User User { get; set; }



        
    }
}
