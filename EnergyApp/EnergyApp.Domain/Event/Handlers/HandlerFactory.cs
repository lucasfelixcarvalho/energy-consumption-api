using System;
using System.Collections.Generic;
using System.Linq;
using EnergyApp.Domain.Meter;

namespace EnergyApp.Domain.Event.Handlers
{
    public class HandlerFactory
    {
        private readonly Dictionary<string, IEventHandler> _Handlers;

        public HandlerFactory(IMeterRepository meterRepository)
        {
            var handlerType = typeof(IEventHandler); // reference: https://www.youtube.com/watch?v=Yd4GnWeEkIY&ab_channel=NickChapsas
            _Handlers = handlerType.Assembly.ExportedTypes // get all classes that references IEventHandler
                .Where(x => handlerType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract) // get only implementations
                .Select(x => { return Activator.CreateInstance(x, meterRepository); }) // create new instance for each implementation
                .Cast<IEventHandler>() // cast the object to known type IEventHandler                
                .ToDictionary(x => x.EventType.ToLower(), x => x); // finally creates the dictionary
        }

        public IEventHandler GetHandler(string type)
        {
            _Handlers.TryGetValue(type.ToLower(), out var handler);
            return handler;
        }
    }
}
