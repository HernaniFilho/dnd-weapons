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
            try
            {
                if (ModelState.IsValid)
                {
                    _weaponDAO.CreateWeapon(weapon);
                    TempData["SuccessMessage"] = "Arma criada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("AddWeapon", weapon);
            } catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao criar arma! Erro: {ex.Message}";
                ModelState.AddModelError("", "Erro ao criar arma: " + ex.Message);
                return RedirectToAction("Index");
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    _weaponDAO.UpdateWeapon(weapon);
                    TempData["SuccessMessage"] = "Arma atualizada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("EditWeapon", weapon);
            } catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao atualizar arma! Erro: {ex.Message}";
                ModelState.AddModelError("", "Erro ao atualizar arma: " + ex.Message);
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteWeaponById(int id)
        {
            try
            {
                var resultado = _weaponDAO.DeleteWeaponById(id);
                if (resultado)
                {
                    TempData["SuccessMessage"] = "Arma excluída com sucesso!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Erro ao excluir arma!";
                }
                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao excluir arma! Erro: {ex.Message}";
                ModelState.AddModelError("", "Erro ao excluir arma: " + ex.Message);
                return RedirectToAction("Index");
            }
            
        }
    }
}
