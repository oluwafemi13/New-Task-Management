using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Please input a name for the product")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please input a a description for the product")]
        public string Description { get; set; }
        //public IEnumerable<Task> Task { get; set; }
    }
}
