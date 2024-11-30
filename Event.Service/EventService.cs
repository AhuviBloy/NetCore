using Event.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Service
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
                _eventRepository = eventRepository;
        }

        public IEventRepository GetAll()
        {  
            return _eventRepository; 
        }
    }
}
