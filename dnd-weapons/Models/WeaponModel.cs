using System.ComponentModel.DataAnnotations;

namespace dnd_weapons.Models
{
    public class WeaponModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 50 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tipo é obrigatório")]
        [TypeValidation("Melee","Ranged","Magic", ErrorMessage = "O tipo não é válido")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(1, 10000, ErrorMessage = "O preço deve estar entre 1 e 10.000")]
        public int Price { get; set; }
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        public string? Description { get; set; }
    }
}
