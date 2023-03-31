using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    internal class CacheManager : ICacheService
    {
        IDistributedCache _cache;

        public CacheManager(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task AddAsync(string key, object value, int duration)
        {
            DistributedCacheEntryOptions options = new() { SlidingExpiration = TimeSpan.FromMinutes(duration) };
            await _cache.SetAsync(key, await EncodeAsync(value), options);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            byte[]? byteValue = await _cache.GetAsync(key);
            if (byteValue == null) { return default; }
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(byteValue)));
        }

        public async Task<object?> GetAsync(string key)
        {
            byte[]? byteValue = await _cache.GetAsync(key);
            if (byteValue == null) { return default; }
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<object>(Encoding.UTF8.GetString(byteValue)));
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }

        private async Task<byte[]> EncodeAsync(object value)
        {
            string stringValue = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(value));
            return Encoding.UTF8.GetBytes(stringValue);
        }
    }
}
