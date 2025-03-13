using Microsoft.AspNetCore.Mvc;

namespace RapitApiHotelProject.ViewComponents
{
    public class _FooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
            { return View(); }
    }
}
