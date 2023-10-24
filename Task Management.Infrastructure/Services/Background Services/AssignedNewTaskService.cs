using Management.Infrastructure.Services.Worker.Interface;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Services.Background_Services
{
    public class AssignedNewTaskService : BackgroundService
    {
        //private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AssignedNewTaskService> _logger;
        private readonly IWorker _worker;
        public AssignedNewTaskService(ILogger<AssignedNewTaskService> logger, IWorker worker)
        {

            _logger = logger;
            _worker = worker;

           
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(
                $"{nameof(AssignedNewTaskService)} is working.");
                await _worker.DoWorkAsync(stoppingToken);
                await Task.Delay(2000);
            }
            

        }
      
    }
}
