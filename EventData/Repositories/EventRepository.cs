using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Event.Data.Repositories
{
    public class EventRepository :IEventRepository
    {
        private readonly IDataContext _dataContext;

        public EventRepository(IDataContext context)
        {
            _dataContext = context;
        }

        public List<SingleEvent> GetAllEvents() //קבלת כל הארועים
        {
            return _dataContext.eventList;
        }

        public SingleEvent GetEventById(int id) //קבלת פרטי ארוע
        {
            return _dataContext.eventList.FirstOrDefault(e=>e.EventCode==id);
        }

        public void AddNewEvent(SingleEvent eventt) //הוספת ארוע למפיק
        {
            _dataContext.producersList.FirstOrDefault(p => p.ProducerId == eventt.EventProducerId).ProducerEventList.Add(eventt);
        }

        public void UpdateEventDetails(SingleEvent eventt) //שינוי פרטי ארוע
        {
            SingleEvent temp = _dataContext.eventList.FirstOrDefault(e => e.EventCode == eventt.EventCode);
            temp.EventPrice = eventt.EventPrice;
            temp.EventDate = eventt.EventDate;
        }

        public void DeleteInactiveEvent(int id) //ארוע לא זמין
        {
            _dataContext.eventList.FirstOrDefault(e => e.EventCode == id).EventStatus = false;
        }
    }
}
