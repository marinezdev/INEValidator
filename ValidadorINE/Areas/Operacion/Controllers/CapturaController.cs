using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ValidadorINE.Areas.Operacion.Controllers
{
    [Authorize]
    [Area("Operacion")]
    public class CapturaController : Controller
    {
        // GET: CapturaController
        public ActionResult Index()
        {
            return View();
        }

    }
}
