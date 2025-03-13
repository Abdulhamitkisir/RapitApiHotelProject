using Microsoft.AspNetCore.Mvc;

namespace RapitApiHotelProject.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
