using System.ComponentModel.DataAnnotations;

namespace Event.Core.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public bool ProducerStatus { get; set; }
        public List<SingleEvent> ProducerEvents { get; set; }=new List<SingleEvent>() { };
    }
}
