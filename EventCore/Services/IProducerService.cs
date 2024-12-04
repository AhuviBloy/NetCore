using Event.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Core.Services
{
    public interface IProducerService
    {
        public List<Producer> GetAllProducers(); //קבלת רשימה של כל המפיקים
        public Producer GetProducerById(int id); //קבלת מפיק
        public void AddNewProducer(int id, string name); // (הוספת מפיק חדש (במקרה שיצר ארוע

        public void AddEventToProducer(SingleEvent eventt); // הכנסת ארוע למפיק

        //public void DeleteProducer(Ticket ticket); //מחיקת ארוע למפיק  
    }
}
