using Microsoft.AspNetCore.Mvc;

namespace RapitApiHotelProject.ViewComponents
{
    public class _OurServicesComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
