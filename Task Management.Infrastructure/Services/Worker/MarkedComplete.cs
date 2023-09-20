using Management.Application.Contracts;
using Management.Infrastructure.Services.Worker.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Infrastructure.Services.Worker.Interface;

namespace Management.Infrastructure.Services.Worker
{
    public class MarkedComplete : IMarkedComplete
    {
        private readonly ILogger<MarkedComplete> _logger;
        private readonly ITaskRepository _taskRepo;
       

        public MarkedComplete(ILogger<MarkedComplete> logger, ITaskRepository taskRepo)
        {
            _logger = logger;
            _taskRepo= taskRepo;
            
        }
        public async Task DoWorkAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var tasks = await _taskRepo.GetTaskForWeek();
                foreach (var task in tasks)
                {
                    DateTime now = DateTime.Now;
                    DateTime next48Hours = now.AddHours(23 *2);
                    if (task.DueDate.Year == next48Hours.Year && task.DueDate.Month == next48Hours.Month && task.DueDate.Hour <= next48Hours.Hour)
                    {
                        //Console.WriteLine($"Task{task.Title} is Due within the Next 48 Hours ");
                        _logger.LogInformation($"Task {task.Title} is Due within the Next 48 Hours");
                        await Task.Delay(5000);
                    }
                    else
                    {
                        continue;
                    }

                }
            }
                
            await Task.CompletedTask;
        }


        
    }
}
