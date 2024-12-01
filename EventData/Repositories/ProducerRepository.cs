using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Data.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly IDataContext _dataContext;

        public ProducerRepository(IDataContext context)
        {
            _dataContext = context;
        }

        public List<Producer> GetAllProducers() //קבלת רשימה של כל המפיקים
        {
            return _dataContext.producersList;
        }
        public Producer GetProducerById(int id)//קבלת מפיק
        {
            return _dataContext.producersList.FirstOrDefault(p => p.ProducerId == id );
        }
        public void PostProducer(int id, string name) // (הוספת מפיק חדש (במקרה שיצר ארוע
        {
            _dataContext.producersList.Add(new Producer(id,name));
        }
        //public void PutProducer(Ticket ticket)// הכנסת ארוע למפיק

        //public void DeleteProducer(Ticket ticket); //מחיקת ארוע למפיק 

    }
}
