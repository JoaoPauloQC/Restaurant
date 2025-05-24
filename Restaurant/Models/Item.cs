using System.ComponentModel.DataAnnotations;


namespace Restaurant.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Preencha a descrição")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Preencha o preço")]
        public double Price {  get; set; }
    }
}
