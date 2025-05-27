using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;


namespace Restaurant.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Preencha o nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Preencha a descrição")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Preencha o preço")]
        public double Price {  get; set; }

        [ValidateNever]
        public ICollection<MesaItem>? MesaItens { get; set; } = new List<MesaItem>();
    }
}
