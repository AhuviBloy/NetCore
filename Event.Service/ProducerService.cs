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
    public class ProducerService:IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IEventRepository _eventRepository;

        public ProducerService(IProducerRepository producerRepository, IEventRepository eventRepository)
        {
            _producerRepository = producerRepository;
            _eventRepository = eventRepository;
        }

        public List<Producer> GetAllProducers() //קבלת רשימה של כל המפיקים
        {
            return _producerRepository.GetAllProducers();
        }
        public Producer GetProducerById(int id)//קבלת מפיק
        {
            return _producerRepository.GetProducerById(id);
        }
        public void AddNewProducer(int id, string name) // (הוספת מפיק חדש (במקרה שיצר ארוע
        {
            var producer=new Producer() {ProducerId=id,ProducerName=name,ProducerEventList=new List<SingleEvent>(),ProducerStatus=true };
            _producerRepository.AddNewProducer(producer);
        }
        public void AddEventToProducer(SingleEvent eventt)// הכנסת ארוע למפיק
        {
            _eventRepository.AddNewEvent(eventt);
        }

        //public void DeleteProducer(Ticket ticket); //מחיקת ארוע למפיק 
    }
}
