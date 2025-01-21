using AutoMapper;
using Event.Core.Models;
using Event.Core.Repositories;
using Event.Core.Services;
using GlaTicket.Core.DTO;
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
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IProducerService producerService,IMapper mapper)
        {
            _eventRepository = eventRepository;
            _producerService = producerService;
            _mapper = mapper;
        }

        public List<EventGetDTO> GetAllEvents() //קבלת כל הארועים
        {
            var list = _eventRepository.GetAllEvents();
            var listDto = new List<EventGetDTO>();
            foreach (var event1 in list)
            {
                listDto.Add(_mapper.Map<EventGetDTO>(event1));
            }
            return listDto;
        }

        public EventGetDTO GetEventById(int id) //קבלת פרטי ארוע
        {
            return _mapper.Map<EventGetDTO>(_eventRepository.GetEventById(id));
        }

        public void AddNewEvent(EventPostDTO eventt) //הוספת ארוע למפיק
        {
            ProducerGetDTO temp=_producerService.GetProducerById(eventt.ProducerId);
            if (temp == null)
            {
                throw new Exception("this producer isn't exsist");
            }
            else
            {
                _eventRepository.AddNewEvent(_mapper.Map<SingleEvent>(eventt));
            }
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
