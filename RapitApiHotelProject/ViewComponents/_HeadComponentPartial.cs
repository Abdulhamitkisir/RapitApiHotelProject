using Microsoft.AspNetCore.Mvc;

namespace RapitApiHotelProject.ViewComponents
{
    public class _HeadComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
