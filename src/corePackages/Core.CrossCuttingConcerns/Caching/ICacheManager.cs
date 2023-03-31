using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheService
    {
        Task AddAsync(string key, object value, int duration);
        Task<T?> GetAsync<T>(string key);
        Task<object?> GetAsync(string key);
        Task RemoveAsync(string key);
    }
}
