using System.ComponentModel.DataAnnotations;

namespace dnd_weapons.Models
{
    public class WeaponMaterial
    {
        public int WeaponId { get; set; }
        public int MaterialId { get; set; }
        public WeaponModel? Weapon { get; set; }
        public MaterialModel? Material { get; set; }
        [Required(ErrorMessage = "Quantidade é obrigatória")]
        public required int Quantity { get; set; } = 1; // Default quantity is 1
    }
}
