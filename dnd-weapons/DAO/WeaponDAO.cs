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

        public WeaponModel UpdateWeapon(WeaponModel weapon)
        {
            throw new NotImplementedException();
        }

        public WeaponModel DeleteWeapon(int id)
        {
            throw new NotImplementedException();
        }
    }
}
