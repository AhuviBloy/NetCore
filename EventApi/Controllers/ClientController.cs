using EventCore.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public static IDataContext dataContext;

        public ClientController(IDataContext context)
        {
            dataContext = context;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(dataContext.clientList);
        }


        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(dataContext.clientList.FirstOrDefault(c => c.ClientId == id && c.ClientStatus == true));
        }


        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, int eventCode)
        {
            dataContext.clientList.FirstOrDefault(c => c.ClientId == id).ClientTicketList.Remove(eventCode);
        }
    }
}
