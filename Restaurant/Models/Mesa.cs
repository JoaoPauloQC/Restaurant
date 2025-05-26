using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Mesa
    {
        [Key]
        public int MesaId { get; set; }

        [Required]
        public int StatusId { get; set; }
        [ValidateNever]
        public Status Status { get; set; }

        [ValidateNever]
        public List<MesaItem> MesaItens { get; set; }

    }
}
