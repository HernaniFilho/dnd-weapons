using System.ComponentModel.DataAnnotations;

namespace dnd_weapons.Models
{
    public class TypeValidationAttribute : ValidationAttribute
    {
        private readonly string[] _validTypes;
        public TypeValidationAttribute(params string[] validTypes)
        {
            _validTypes = validTypes;
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || !_validTypes.Contains(value.ToString()))
            {
                return new ValidationResult($"O tipo deve ser um dos seguintes: {string.Join(", ", _validTypes)}");
            }
            return ValidationResult.Success;
        }
    }
}
