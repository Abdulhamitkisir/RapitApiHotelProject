using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapitApiHotelProject.Models;
using System.Net.Http.Headers;

namespace RapitApiHotelProject.ViewComponents
{
    public class _DetailPhotoComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int hotel_id)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelPhotos?hotel_id={hotel_id}"),
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
                var result=JsonConvert.DeserializeObject<GetPhotoViewModel>(body);
                return View(result);
            }
           
        }
    }
}
