using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Shift : IValidatableObject
    {
        public int ShiftID { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public decimal Pay { get; set; }
        [Required]
        public decimal Minutes { get; set; }
        [Required]
        public string? Location { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Start.CompareTo(End) != -1)
                yield return new ValidationResult("End date has to be greater than Start date");
    }
    }
}
