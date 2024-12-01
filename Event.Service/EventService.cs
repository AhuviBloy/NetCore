using Event.Core.Models;
using Event.Core.Repositories;
using Event.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Service
{
    public class EventService:IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
                _eventRepository = eventRepository;
        }

        public List<SingleEvent> GetAllEvents() //קבלת כל הארועים
        {
            return _eventRepository.GetAllEvents();
        }
        public SingleEvent GetEventById(int id) //קבלת פרטי ארוע
        {
            return _eventRepository.GetEventById(id);
        }
        public void PostEvent(SingleEvent eventt) //הוספת ארוע למפיק
        {
            _eventRepository.PostEvent(eventt);
        }
        public void PutEvent(SingleEvent eventt) //שינוי פרטי ארוע
        {
            _eventRepository.PutEvent(eventt);
        }
        public void DeleteEvent(int id) //ארוע לא זמין
        {
            _eventRepository.DeleteEvent(id);
        }

    }
}
