using Microsoft.Extensions.Caching.Distributed;
using System;

namespace WebServer_Server.Services
{
    public class CatchService
    {
        private readonly IDistributedCache _cache;

        public CatchService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public string GetCachedData(string key)
        {
            var data = _cache.GetString(key);

            if (data == null)
            {
                data = "Get from database";

                var cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };
                _cache.SetString(key, data, cacheOptions);
            }

            return data;
        }
    }
}
