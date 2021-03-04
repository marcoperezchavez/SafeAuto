using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BEApi.Models
{
    public class SafeAuto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }

        public ICollection<InformationSafeAuto> informationSafeAutos { get; set; }
    }
}
