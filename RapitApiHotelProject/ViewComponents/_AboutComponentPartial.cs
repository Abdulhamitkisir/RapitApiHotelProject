using Microsoft.AspNetCore.Mvc;

namespace RapitApiHotelProject.ViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
            { return View(); }
    }
}
