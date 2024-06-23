using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Proxy
{
    public interface IThingServer
    {
        bool TryRead(string thingId, out Thing value);
    }
    public class ThingServer : IThingServer
    {
        private List<Thing> _things;

        public ThingServer() 
        {
            _things = new List<Thing>
            {
                new Thing { Id = "1", Name = "Рубашка", Description = "" },
                new Thing { Id = "2", Name = "Кроссовки", Description = ""},
                new Thing { Id = "3", Name = "Ролики", Description = ""},
                new Thing { Id = "4", Name = "Кружки", Description = ""}
            };
        }

        public bool TryRead(string thingId, out Thing value)
        {
            for (int i = 0; i < _things.Count; i++)
            {
                if (_things[i].Id == thingId)
                {
                    value = _things[i];
                    return true;
                }
            }

            value = null;
            return false;
        }
    }
}
