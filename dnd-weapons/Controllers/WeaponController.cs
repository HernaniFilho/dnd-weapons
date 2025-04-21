using dnd_weapons.DAO;
using dnd_weapons.Models;
using Microsoft.AspNetCore.Mvc;

namespace dnd_weapons.Controllers
{
    public class WeaponController : Controller
    {
        private readonly IWeaponDAO _weaponDAO;

        public WeaponController(IWeaponDAO weaponDAO)
        {
            _weaponDAO = weaponDAO;
        }

        // Páginas
        public IActionResult Index()
        {
            var weapons = _weaponDAO.ReadWeaponAll();

            return View(weapons);
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

        // API

        [HttpPost]
        public IActionResult CreateWeapon(WeaponModel weapon)
        {
            _weaponDAO.CreateWeapon(weapon);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReadWeaponAll()
        {
            throw new NotImplementedException();
        }
    }
}
