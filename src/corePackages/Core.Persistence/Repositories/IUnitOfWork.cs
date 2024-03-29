﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
