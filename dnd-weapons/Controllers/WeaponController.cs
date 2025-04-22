using dnd_weapons.DAO;
using dnd_weapons.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dnd_weapons.Controllers
{
    public class WeaponController : Controller
    {
        private readonly IWeaponDAO _weaponDAO;
        private readonly List<SelectListItem> _validTypes = new List<SelectListItem>
        {
            new SelectListItem { Value = "Melee", Text = "Corpo a corpo" },
            new SelectListItem { Value = "Ranged", Text = "À distância" },
            new SelectListItem { Value = "Magic", Text = "Mágica" },
        };

        public WeaponController(IWeaponDAO weaponDAO)
        {
            _weaponDAO = weaponDAO;
        }

        // Carrega os tipos de armas para o ViewBag antes de cada ação
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            ViewBag.Type = _validTypes;
        }

        // Páginas
        public IActionResult Index()
        {
            var weapons = _weaponDAO.ReadWeaponAll();

            return View(weapons);
        }

        public IActionResult ViewWeapon()
        {
            throw new NotImplementedException();
        }

        public IActionResult AddWeapon()
        {

            //ViewBag.Type = _validTypes;
            return View();
        }

        public IActionResult EditWeapon(int id)
        {
            //ViewBag.Type = _validTypes;

            var weapon = _weaponDAO.ReadWeaponById(id);
            if (weapon == null)
            {
                return NotFound();
            }

            return View(weapon);
        }

        public IActionResult DeleteWeapon(int id)
        {
            var weapon = _weaponDAO.ReadWeaponById(id);
            if (weapon == null) {
                return NotFound();
            }
            return View(weapon);
        }



        // API

        [HttpPost]
        public IActionResult CreateWeapon(WeaponModel weapon)
        {
            if (ModelState.IsValid)
            {
                _weaponDAO.CreateWeapon(weapon);
                return RedirectToAction("Index");
            }

            return View("AddWeapon",weapon);
        }

        [HttpGet]
        public IActionResult ReadWeaponAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult ReadWeaponById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult UpdateWeapon(WeaponModel weapon)
        {
            if(ModelState.IsValid)
            {
                _weaponDAO.UpdateWeapon(weapon);
                return RedirectToAction("Index");
            }

            return View("EditWeapon", weapon);
        }

        public IActionResult DeleteWeaponById(int id)
        {
            var resultado = _weaponDAO.DeleteWeaponById(id);
            return RedirectToAction("Index");
        }
    }
}
