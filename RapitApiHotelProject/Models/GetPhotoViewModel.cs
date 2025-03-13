using static RapitApiHotelProject.Models.HotelSearchViewModel;

namespace RapitApiHotelProject.Models
{
    public class GetPhotoViewModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
        public List<Data> data { get; set; }  // Burada Liste olarak değiştirdik!

        public class Data
        {
            public int id { get; set; }
            public string url { get; set; }
        }
    }
}
