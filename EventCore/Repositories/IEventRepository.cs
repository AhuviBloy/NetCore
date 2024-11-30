using Event.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Core.Repositories
{
    public interface IEventRepository
    {
        public List<SingleEvent> GetList();
    }
}
