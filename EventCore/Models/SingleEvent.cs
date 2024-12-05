using System.ComponentModel.DataAnnotations;

namespace Event.Core.Models
{
    public class SingleEvent
    {
        [Key]
        public int Id { get; set; }
        public int EventCode { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int EventPrice { get; set; }
        public bool EventStatus { get; set; }
        public int EventProducerId { get; set; }
        public string EventProducerNmae { get; set; }



    }
}
