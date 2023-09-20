using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage ="Please Enter a Name")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage ="Enter a valid Email")]
        public string Email { get; set; }
    }
}
