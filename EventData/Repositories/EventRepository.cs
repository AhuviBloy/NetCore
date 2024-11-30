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
    public class EventRepository :IEventRepository
    {
        private IDataContext _dataContext;

        public EventRepository(IDataContext context)
        {
            _dataContext = context;
        }
        public List<SingleEvent> GetList()
        {
            return _dataContext.eventList;
        }
    }
}
