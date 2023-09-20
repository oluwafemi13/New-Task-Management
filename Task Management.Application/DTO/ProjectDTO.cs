using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management.Application.DTO
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Please input a name for the product")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please input a a description for the product")]
        public string Description { get; set; }
    }
}
