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
    public class ProducerService:IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public ProducerService(IProducerRepository producerRepository, IEventRepository eventRepository,IMapper mapper)
        {
            _producerRepository = producerRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public List<ProducerGetDTO> GetAllProducers() //קבלת רשימה של כל המפיקים
        {
            var list = _producerRepository.GetAllProducers();
            var listDto = new List<ProducerGetDTO>();
            foreach (var producer in list)
            {
                listDto.Add(_mapper.Map<ProducerGetDTO>(producer));
            }
            return listDto;
        }
        public ProducerGetDTO GetProducerById(int id)//קבלת מפיק
        {
            return _mapper.Map<ProducerGetDTO>(_producerRepository.GetProducerById(id));
        }
        public void AddNewProducer(int id, string name) // (הוספת מפיק חדש (במקרה שיצר ארוע
        {
            var producer=new Producer() {ProducerId=id,ProducerName=name,ProducerEvents=new List<SingleEvent>(),ProducerStatus=true };
            _producerRepository.AddNewProducer(producer);
        }
        public void AddEventToProducer(SingleEvent eventt)// הכנסת ארוע למפיק
        {
            _eventRepository.AddNewEvent(eventt);
        }

        //public void DeleteProducer(Ticket ticket); //מחיקת ארוע למפיק 
    }
}
