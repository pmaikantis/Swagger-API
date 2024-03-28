using System.ComponentModel.DataAnnotations;

namespace AthenaApothecary.Models
{
    public class Fragrance
    {
        public Fragrance() { }

        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Perfumer { get; set; }

        public string? Gender { get; set; }

        [MaxLength(2000)]
        public string? Description { get; set; }

        public string? FragranceNotes { get; set; }
        [Required]
        public double? Price { get; set; }

        internal static object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
