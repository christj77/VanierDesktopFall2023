namespace FarmersMarketRESTAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }

        public string messageCode { get; set; }

        public Fruits fruits  { get; set; }

        public List<Fruits> fruit_list { get; set; }
    }
}
