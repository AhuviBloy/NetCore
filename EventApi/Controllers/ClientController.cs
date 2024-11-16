using EventCore.Data;
using EventCore.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public static IDataContext _dataContext;

        public ClientController(IDataContext context)
        {
            _dataContext = context;
        }

        // GET: api/Client
        [HttpGet]
        public ActionResult Get()
        {
            // בודק אם יש רשימה של לקוחות. אם אין, מחזיר NotFound.
            var clients = _dataContext.clientList.ToList();
            if (!clients.Any())
            {
                return NotFound("No clients found.");
            }

            return Ok(clients);  // מחזיר את רשימת הלקוחות
        }

        // GET api/Client/{id}
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            // מוודא אם הלקוח עם ה-ID נמצא ואם הסטטוס שלו True
            var client = _dataContext.clientList.FirstOrDefault(c => c.ClientId == id && c.ClientStatus == true);

            if (client == null)
            {
                return NotFound($"Client with ID {id} not found or is inactive.");
            }

            return Ok(client);  // מחזיר את הלקוח
        }


        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, int eventCode)
        {
            _dataContext.clientList.FirstOrDefault(c => c.ClientId == id).ClientTicketList.Remove(eventCode);
        }
    }
}
