using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Proxy
{
    public class ThingCache : IThingServer
    {
        private readonly IThingServer _thingServer;
        private Dictionary<string, Thing> _cache = new Dictionary<string, Thing>();

        public ThingCache(IThingServer thingServer)
        {
            _thingServer = thingServer;
        }
        public bool TryRead(string thingId, out Thing value)
        {
            // Кэш ищет сначала у себя предмет
            if (_cache.TryGetValue(thingId, out value))
                return true; // Если находит, то возвращает информацию.
            // Если нет - спрашивает у ThingServer
            else if(_thingServer.TryRead(thingId, out value))
            {
                _cache[thingId] = value;
                return true;
            }

            value = null;
            return false;
        }
    }
}
