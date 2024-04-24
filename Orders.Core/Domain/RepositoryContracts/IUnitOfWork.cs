﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Domain.RepositoryContracts
{
    public interface IUnitOfWork
    {
        public Task BeginTransaction();
        public Task CommitTransaciton();

        public Task SaveChangeAsync();
        public Task Commit();
        public Task RollbackTransaction();
    }
}
