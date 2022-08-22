namespace Lesson4
{
    internal class SimpleGenericCache<T>
    {
        private readonly Dictionary<string, CachedValue<T>> _cache = new();

        internal void Store(string key, T value, int timeout = 30)
        {
            var newCache = new CachedValue<T>()
            {
                Value = value,  
                CreationTime = DateTime.Now,    
                Timeout = timeout,
            };
            _cache[key] = newCache;
        }

        internal T? Fetch(string key)
        {
            if (_cache.TryGetValue(key, out var newCache))
            {
                if (newCache.CreationTime.AddSeconds(newCache.Timeout) > DateTime.Now)
                {
                    return newCache.Value;
                }
                else
                {
                    _cache.Remove(key);
                    return default;
                }
            }

            return default;
        }
    }
}
