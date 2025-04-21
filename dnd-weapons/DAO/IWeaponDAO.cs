using dnd_weapons.Models;

namespace dnd_weapons.DAO
{
    public interface IWeaponDAO
    {
        WeaponModel CreateWeapon(WeaponModel weapon);
        List<WeaponModel> ReadWeaponAll();
        WeaponModel UpdateWeapon(WeaponModel weapon);
        WeaponModel DeleteWeapon(int id);
    }
}
