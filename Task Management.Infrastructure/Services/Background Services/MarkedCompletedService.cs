using Management.Application.Contracts;
using Management.Infrastructure.Services.Worker;
using Management.Infrastructure.Services.Worker.Interface;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task_Management.Infrastructure.Services.Worker.Interface;

namespace Management.Infrastructure.Services.Background_Services
{
    public class MarkedCompletedService : BackgroundService
    {
    
        private readonly ILogger<MarkedCompletedService> _logger;
        private readonly IMarkedComplete _markedComplete;
        public MarkedCompletedService(ILogger<MarkedCompletedService> logger, IMarkedComplete markedComplete)
        {
            
            _logger= logger;
            _markedComplete= markedComplete;
           
           
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(
              $"{nameof(MarkedCompletedService)} is working.");
                await _markedComplete.DoWorkAsync(stoppingToken);
                await Task.Delay(1000);
            }
           

        }
    }
}
