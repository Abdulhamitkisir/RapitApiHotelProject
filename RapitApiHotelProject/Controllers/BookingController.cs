using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapitApiHotelProject.Models;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace RapitApiHotelProject.Controllers
{
    public class BookingController : Controller
    {

        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(string location, string checkin, string checkout, int adult, int child)
        {
            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(checkin) || string.IsNullOrEmpty(checkout))
            {
                return View();
            }



            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={location}"),
                Headers =
    {
        { "x-rapidapi-key", "e900edeca4msh1ac2d78844ebe8ep175aafjsnb5be1dd3a0a6" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var searchResponse = JsonConvert.DeserializeObject<SearchResponse>(body);
                var destinationId = searchResponse?.data?.Count > 0 ? searchResponse.data[0].dest_id : null;

                if (destinationId == null)
                {
                    return View();
                }

                return RedirectToAction("BookingHotelSearch", new { destId = destinationId, checkin, checkout, adult, child });
            }


        }

        public async Task<IActionResult> BookingHotelSearch(string destId, string checkin, string checkout, int adult, int child)
        {
            if (string.IsNullOrEmpty(destId) || string.IsNullOrEmpty(checkin) || string.IsNullOrEmpty(checkout))
            {
                return BadRequest("Gecersit arama parametresi");
            }
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={destId}&search_type=CITY&arrival_date={checkin}&departure_date={checkout}&adults={adult}&children_age={child}&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=EUR"),
                Headers =
    {
        { "x-rapidapi-key", "e900edeca4msh1ac2d78844ebe8ep175aafjsnb5be1dd3a0a6" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var apiRenponse = JsonConvert.DeserializeObject<HotelSearchViewModel>(body);
                var hotels = apiRenponse?.data?.hotels.ToList() ?? new List<HotelSearchViewModel.Hotel>();

                

                return View(hotels);
            }

        }

        public async Task<IActionResult> BookingHotelDetail(int hotelId, string checkin, string checkout)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelDetails?hotel_id={hotelId}&arrival_date={checkin}&departure_date={checkout}&units=metric&temperature_unit=c&languagecode=en-us&currency_code=EUR"),
                Headers =
    {
        { "x-rapidapi-key", "e900edeca4msh1ac2d78844ebe8ep175aafjsnb5be1dd3a0a6" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var apiResponse=JsonConvert.DeserializeObject<HotelDetailViewModel>(body);

                var hotelDetails = apiResponse?.datas?.ToList() ?? new List<HotelDetailViewModel.Data>();

                return View(apiResponse);
                //3920317 vien id
            }

        }
    }
}
