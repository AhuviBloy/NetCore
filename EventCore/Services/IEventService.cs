using Event.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Core.Services
{
    public interface IEventService
    {
        public List<SingleEvent> GetAllEvents(); //קבלת כל הארועים
        public SingleEvent GetEventById(int id); //קבלת פרטי ארוע
        public void PostEvent(SingleEvent eventt); //הכנסת הארוע לרשימת הארועים ולמפיק
        public void PutEvent(SingleEvent eventt); //שינוי פרטי ארוע  
        public void DeleteEvent(int id); //שינוי סטטוס ללא פעיל
    }
}
