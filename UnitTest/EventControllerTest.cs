using Event.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest
{
    public class EventControllerTest
    {
        private readonly EventController eventController;
        public EventControllerTest()
        {
            eventController=new EventController(new FakeContext());
        }
        [Fact]
        public void Get_ReturnsOk()
        {
            var result = eventController.Get();
            Assert.IsType<ActionResult<IEnumerable<Event>>>(result);
        }
        [Fact]
        public void GetById_ReturnsOk()
        {
            var id = 0;
            var result = eventController.Get(id);
            Assert.IsType<ActionResult<Event>>(result);
        }

    }
}
