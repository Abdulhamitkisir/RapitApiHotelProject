using Microsoft.AspNetCore.Mvc;

namespace RapitApiHotelProject.ViewComponents
{
    public class _NavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
            { return View(); }

    }
}
