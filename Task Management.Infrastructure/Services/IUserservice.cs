using Management.Application.DTO;
using Management.Application.Models;
using Management.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Services
{
    public interface IUserservice
    {
        Task<Reponse> Update(UserDTO user, int Id);
        Task<Reponse> DeleteUser(int Id);
        Task<Reponse> CreateUser(UserDTO user);
        Task<IEnumerable<User>> GetAll(RequestParameters parameter);
    }
}
