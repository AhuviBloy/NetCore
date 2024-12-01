namespace Event.Core.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public bool ProducerStatus { get; set; }
        public List<SingleEvent> ProducerEventList { get; set; }

        public Producer(int id, string name)
        {
            ProducerId = id;
            ProducerName = name;
            ProducerStatus = true;
            ProducerEventList = new List<SingleEvent>();
        }

    }
}
