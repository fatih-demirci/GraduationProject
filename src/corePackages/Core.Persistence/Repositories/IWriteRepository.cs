using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IWriteRepository<T> : IQuery<T>, IRepository<T> where T : Entity, new()
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
