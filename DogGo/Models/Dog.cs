using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Owner")]
        public int OwnerId { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        [DisplayName("Picture of Dog")]
        public string ImageUrl { get; set; }

        public string Notes { get; set; }
    }
    
}
