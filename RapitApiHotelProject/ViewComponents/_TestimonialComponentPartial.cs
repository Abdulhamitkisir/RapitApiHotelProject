using Microsoft.AspNetCore.Mvc;

namespace RapitApiHotelProject.ViewComponents
{
    public class _TestimonialComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
        return View();
        }
    }
}
