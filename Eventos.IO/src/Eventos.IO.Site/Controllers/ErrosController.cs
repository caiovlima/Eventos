using Eventos.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.IO.Site.Controllers
{
    public class ErroController : Controller
    {
        private readonly IUser _user;

        public ErroController(IUser user)
        {
            _user = user;
        }

        [Route("/erro-de-aplicacao")]
        [Route("/erro-de-aplicacao/{id}")]
        public IActionResult Erros(string id)
        {
            switch (id)
            {
                case "404":
                    return View("NotFound");
                case "403":
                case "401":
                    if (!_user.IsAuthenticated()) return RedirectToAction("Login", "Account");
                    return View("AccessDenied");
            }

            return View("Error");
        }
    }
}
