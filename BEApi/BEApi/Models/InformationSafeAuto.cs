using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEApi.Models
{
    public class InformationSafeAuto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The StartTrip is required")]
        [MaxLength(200)]
        public string StartTrip { get; set; }

        [Required(ErrorMessage = "The EndTrip is required")]
        [MaxLength(200)]
        public string EndTrip { get; set; }

        [Required(ErrorMessage = "The Miles is required")]
        public float Miles { get; set; }
        public int? SafeAutoId { get; set; }

        [NotMapped]
        public SafeAuto SafeAuto { get; set; }

    }
}
