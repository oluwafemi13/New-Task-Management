﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management.Infrastructure.Services.Worker.Interface
{
    public interface IMarkedComplete
    {
        Task DoWorkAsync(CancellationToken cancellationToken);
    }
}
