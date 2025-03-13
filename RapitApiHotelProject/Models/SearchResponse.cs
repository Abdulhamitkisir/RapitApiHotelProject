namespace RapitApiHotelProject.Models
{
    public class SearchResponse
    {
        public List<Destination> data {  get; set; }
    }
    public class Destination
    {
        public string dest_id { get; set; }
        public string city_name { get; set; }
    }
}
