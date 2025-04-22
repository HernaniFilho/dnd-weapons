using dnd_weapons.Models;

namespace dnd_weapons.DAO
{
    public interface IWeaponDAO
    {
        WeaponModel CreateWeapon(WeaponModel weapon);
        List<WeaponModel> ReadWeaponAll();
        WeaponModel ReadWeaponById(int id);
        WeaponModel UpdateWeapon(WeaponModel weapon);
        bool DeleteWeaponById(int id);
    }
}
