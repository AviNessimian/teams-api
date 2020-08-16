using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace InternetTeams.Infrastructure.Caching
{
    internal class DomainValueChachingService
    {

        private IMemoryCache _cache;

        public DomainValueChachingService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }


        public DateTime CacheTryGetValueSet()
        {
            DateTime cacheEntry;

            // Look for cache key.
            if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = DateTime.Now;

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                // Save data in cache.
                _cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }

        /// <summary>
        /// The following code uses GetOrCreate and GetOrCreateAsync to cache data.
        /// </summary>
        public DateTime CacheGetOrCreate()
        {
            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                return DateTime.Now;
            });

            return cacheEntry;
        }

        public async Task<DateTime> CacheGetOrCreateAsynchronous()
        {
            var cacheEntry = await
                _cache.GetOrCreateAsync(CacheKeys.Entry, entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                    return Task.FromResult(DateTime.Now);
                });

            return cacheEntry;
        }


        //The following code calls Get to fetch the cached time:
        public DateTime? CacheGet()
        {
            var cacheEntry = _cache.Get<DateTime?>(CacheKeys.Entry);
            return cacheEntry;
        }


        /// <summary>
        /// The following code gets or creates a cached item with absolute expiration
        /// </summary>
        public DateTime CacheGetOrCreateAbs()
        {
            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                return DateTime.Now;
            });

            return cacheEntry;
        }

        /// <summary>
        /// The following code gets or creates a cached item with both sliding and absolute expiration:
        /// </summary>
        public DateTime CacheGetOrCreateAbsSliding()
        {
            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.SetSlidingExpiration(TimeSpan.FromSeconds(3));
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20);
                return DateTime.Now;
            });

            return cacheEntry;
        }


    }
}
