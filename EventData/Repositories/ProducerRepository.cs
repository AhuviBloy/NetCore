using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Repositories;
using EventCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Data.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly DataContext _dataContext;

        public ProducerRepository(DataContext context)
        {
            _dataContext = context;
        }

        public List<Producer> GetAllProducers() //קבלת רשימה של כל המפיקים
        {
            return _dataContext.producersDbSet.ToList();
        }

        public Producer GetProducerById(int id)//קבלת מפיק
        {
            return _dataContext.producersDbSet.FirstOrDefault(p => p.ProducerId == id );
        }

        public void AddNewProducer(Producer producer) // (הוספת מפיק חדש (במקרה שיצר ארוע
        {
            _dataContext.producersDbSet.Add(producer);
            _dataContext.SaveChanges();
        }

        public void AddEventToProducer(SingleEvent eventt)// הכנסת ארוע למפיק
        {
           GetProducerById(eventt.EventProducerId).ProducerEventList.Add(eventt);
           _dataContext.SaveChanges();
        }

        //public void DeleteProducer(Ticket ticket); //מחיקת ארוע למפיק 

    }
}
