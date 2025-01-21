using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Repositories;
using EventCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Event.Data.Repositories
{
    public class EventRepository :IEventRepository
    {
        private readonly DataContext _dataContext;

        public EventRepository(DataContext context)
        {
            _dataContext = context;
        }

        public List<SingleEvent> GetAllEvents() //קבלת כל הארועים
        {
            return _dataContext.eventDbSet.ToList();//.Include(e => e.Producer);
        }

        public SingleEvent GetEventById(int id) //קבלת פרטי ארוע
        {
            return _dataContext.eventDbSet.FirstOrDefault(e=>e.EventCode==id);
        }

        public void AddNewEvent(SingleEvent eventt) //הוספת ארוע למפיק
        {
            var producer = _dataContext.producersDbSet/*.Include(p => p.ProducerEvents)*/.FirstOrDefault(p => p.ProducerId == eventt.ProducerId);

            if (producer.ProducerEvents != null)
            {
                producer.ProducerEvents.Add(eventt);
            }
            else
            {
                producer.ProducerEvents = new List<SingleEvent> { eventt };
            }
            _dataContext.SaveChanges();
        }

        public void UpdateEventDetails(SingleEvent eventt) //שינוי פרטי ארוע
        {
            SingleEvent tempeventt = _dataContext.eventDbSet.FirstOrDefault(e => e.EventCode == eventt.EventCode);
            if(tempeventt!=null)
            {
            tempeventt.EventPrice = eventt.EventPrice;
            tempeventt.EventDate = eventt.EventDate;
            }
            

            _dataContext.SaveChanges();
        }

        public void DeleteInactiveEvent(int id) //ארוע לא זמין
        {
            GetEventById(id).EventStatus = false;
            _dataContext.SaveChanges();
        }
    }
}
