using System;
using Microsoft.Extensions.Caching.Memory;

namespace Comm100.Framework.Caching.Memory
{
    public class InMemoryCache : BaseCache
    {
        private MemoryCache _memoryCache;

        public InMemoryCache(string name)
            : base(name)
        {
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override object GetOrDefault(string key)
        {
            throw new NotImplementedException();
        }

        public override void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public override void Set(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null)
        {
            throw new NotImplementedException();
        }
    }
}
