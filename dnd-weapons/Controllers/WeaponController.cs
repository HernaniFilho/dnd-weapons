using Microsoft.AspNetCore.Mvc;

namespace dnd_weapons.Controllers
{
    public class WeaponController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewWeapon()
        {
            return View();
        }

        public IActionResult AddWeapon()
        {
            return View();
        }

        public IActionResult EditWeapon()
        {
            return View();
        }

        public IActionResult DeleteWeapon()
        {
            return View();
        }
    }
}
