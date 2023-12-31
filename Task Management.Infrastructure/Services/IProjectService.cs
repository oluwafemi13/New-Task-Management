﻿using Management.Application.Contracts;
using Management.Application.Models;
using Management.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Application.DTO;

namespace Management.Infrastructure.Services
{
    public interface IProjectService
    {
        Task<Reponse> GetProjectById(int id);
        Task<IEnumerable<Project>> GetAll(RequestParameters parameter);
        Task<Reponse> Update(Project project, int Id);
        Task<Reponse> DeleteProject(int Id);
        Task<Reponse> CreateProject(ProjectDTO project);
        Task<Reponse> GetProjectByUser(string UserId);

    }
}
