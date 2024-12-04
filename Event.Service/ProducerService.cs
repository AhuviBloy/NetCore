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

        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
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
            _producerRepository.AddNewProducer(id, name);
        }
        public void AddEventToProducer(SingleEvent eventt)// הכנסת ארוע למפיק
        {
            Producer temp = _producerRepository.GetProducerById(eventt.EventProducerId);
            if (temp == null)
            {
                _producerRepository.AddNewProducer(eventt.EventProducerId,eventt.EventProducerNmae);
            }
            _producerRepository.AddEventToProducer(eventt);
        }

        //public void DeleteProducer(Ticket ticket); //מחיקת ארוע למפיק 
    }
}
