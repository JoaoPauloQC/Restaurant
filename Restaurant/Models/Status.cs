using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Status
    {
        [Required]
        public int StatusId { get; set; }

        
        public string Name { get; set; }

    }
}
