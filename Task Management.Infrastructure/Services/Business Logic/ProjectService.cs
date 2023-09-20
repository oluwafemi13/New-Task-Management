using Management.Application.Contracts;
using Management.Application.Models;
using Management.Core.Entities;
using Management.Infrastructure.Data;
using Management.Infrastructure.Repositories;
using Management.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task_Management.Application.DTO;

namespace Management.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;

        public ProjectService(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<Reponse> CreateProject(ProjectDTO project)
        {
            try
            {
                var newProject = new Project
                {
                    ProjectId = project.ProjectId,
                    Description = project.Description,
                    Name = project.Name
                };
                await _projectRepo.CreateAsync(newProject);
                return new Reponse
                {
                    Data = JsonSerializer.Serialize(project),
                    IsSuccess = true,
                    ReasonPhrase = "Created",
                    ResponseCode = 201
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Reponse> DeleteProject(int Id)
        {
           var find = await _projectRepo.GetAsync(Id);
            if(find != null)
            {
                await _projectRepo.DeleteAsync(find);
                return new Reponse
                {
                    Data = find,
                    IsSuccess = true,
                    ReasonPhrase = "Successful",
                    ResponseCode = 200
                };
            }
            return new Reponse
            {
                Data = null,
                IsSuccess = false,
                ReasonPhrase = "Not Found",
                ResponseCode = 404
            };
        }

        public Task<IEnumerable<Project>> GetAll(RequestParameters parameter)
        {
            var search = _projectRepo.GetAllPagedAsync(parameter);
            return search;
        }

        public async Task<Reponse> GetProjectById(int id)
        {
            var search = _projectRepo.GetAsync(id);
            if (search == null)
            {
                return new Reponse
                {
                    Data = null,
                    IsSuccess = true,
                    ReasonPhrase = "Not found",
                    ResponseCode = 404
                };
            }
            return new Reponse
            {
                Data = search,
                IsSuccess = true,
                ReasonPhrase = "Successful",
                ResponseCode = 200
            };

        }

        //no user Id in the project table
        public async Task<Reponse> GetProjectByUser(string UserId)
        {
            var search = _projectRepo.GetAsync($"{UserId}");
            if(search == null)
            {
                return new Reponse
                {
                    Data = null,
                    IsSuccess = false,
                    ReasonPhrase = "User Not Found",
                    ResponseCode = 404
                };
            }

            return new Reponse
            {
                Data = search,
                IsSuccess = true,
                ReasonPhrase = "Successful",
                ResponseCode = 200
            };

        }

        public async Task<Reponse> Update(Project project, int Id)
        {
            try
            {
                var search = await _projectRepo.GetAsync(Id);               
                if (search == null)
                {
                    return new Reponse
                    {
                        Data = null,
                        IsSuccess = false,
                        ResponseCode = 404,
                        ReasonPhrase = "Project Not Found"
                    };
                }
                search.ProjectId= Id;
                search.Description= project.Description;
                search.Name= project.Name;
               var result =  await _projectRepo.UpdateAsync(search, Id);
                
                return new Reponse
                {
                    Data = JsonSerializer.Serialize(result),
                    IsSuccess = true,
                    ReasonPhrase = "Successful",
                    ResponseCode = 200
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
