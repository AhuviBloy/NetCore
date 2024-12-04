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
        private readonly IProducerService _producerService;

        public EventService(IEventRepository eventRepository, IProducerService producerService)
        {
            _eventRepository = eventRepository;
            _producerService = producerService;
        }

        public List<SingleEvent> GetAllEvents() //קבלת כל הארועים
        {
            return _eventRepository.GetAllEvents();
        }

        public SingleEvent GetEventById(int id) //קבלת פרטי ארוע
        {
            return _eventRepository.GetEventById(id);
        }

        public void AddNewEvent(SingleEvent eventt) //הוספת ארוע למפיק
        {
            Producer temp=_producerService.GetProducerById(eventt.EventProducerId);
            if (temp == null)
            {
                _producerService.AddNewProducer(eventt.EventProducerId,eventt.EventProducerNmae);
            }
            _eventRepository.AddNewEvent(eventt);
        }

        public void UpdateEventDetails(SingleEvent eventt) //שינוי פרטי ארוע
        {
            SingleEvent temp=_eventRepository.GetEventById(eventt.EventCode);
            if (temp == null)
                _eventRepository.UpdateEventDetails(eventt);
        }

        public void DeleteInactiveEvent(int id) //ארוע לא זמין
        {
            SingleEvent temp = _eventRepository.GetEventById(id);
            if (temp == null)
                _eventRepository.DeleteInactiveEvent(id);
        }

    }
}
