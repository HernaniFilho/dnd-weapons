using dnd_weapons.Data;
using dnd_weapons.Models;

namespace dnd_weapons.DAO
{
    public class WeaponDAO : IWeaponDAO
    {
        private readonly DatabaseContext _context;
        public WeaponDAO(DatabaseContext context)
        {
            _context = context;
        }


        public WeaponModel CreateWeapon(WeaponModel weapon)
        {
            // Salvar no Banco de Dados
            _context.Weapons.Add(weapon);
            _context.SaveChanges();
            // Retornar o objeto salvo
            return weapon;
        }

        public List<WeaponModel> ReadWeaponAll()
        {
            // Recuperar todos os objetos do banco de dados
            return _context.Weapons.ToList();
        }

        public WeaponModel ReadWeaponById(int id)
        {
            // Recuperar o objeto do banco de dados
            return _context.Weapons.FirstOrDefault(w => w.Id == id);
        }

        public WeaponModel UpdateWeapon(WeaponModel weapon)
        {
            var weaponToUpdate = ReadWeaponById(weapon.Id);
            if (weaponToUpdate == null)
            {
                throw new Exception("Weapon not found");
            }
            
            weaponToUpdate.Type = weapon.Type;
            weaponToUpdate.Price = weapon.Price;
            weaponToUpdate.Description = weapon.Description;
            // Salvar no Banco de Dados
            _context.Weapons.Update(weaponToUpdate);
            _context.SaveChanges();

            return weaponToUpdate;

        }

        public bool DeleteWeaponById(int id)
        {
            var weaponToDelete = ReadWeaponById(id);
            if (weaponToDelete == null)
            {
                throw new Exception("Unable to delete weapon");
            }
            // Remover do Banco de Dados
            _context.Weapons.Remove(weaponToDelete);
            _context.SaveChanges();

            return true;
        }
    }
}
