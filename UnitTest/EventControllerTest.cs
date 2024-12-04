//using Event.Api.Controllers;
//using Event.Core.Models;
//using EventApi.Controllers;
//using EventCore.Data;
//using Microsoft.AspNetCore.Mvc;

//namespace UnitTest
//{
//    public class EventControllerTest
//    {
//        private readonly EventController eventController;
//        public EventControllerTest()
//        {
//            eventController=new EventController(new FakeContext());
//        }
//        [Fact]
//        public void Get_ReturnsOk()
//        {
//            var result = eventController.Get();
//            Assert.IsType<ActionResult<IEnumerable<SingleEvent>>>(result);
//        }
//        [Fact]
//        public void GetById_ReturnsOk()
//        {
//            var id = 0;
//            var result = eventController.Get(id);
//            Assert.IsType<ActionResult<SingleEvent>>(result);
//        }

//    }
//}
