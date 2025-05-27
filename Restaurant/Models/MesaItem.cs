using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MesaItem
    {
        [Key]
        public int Id { get; set; }
        public int MesaId { get; set; }
        public Mesa mesa { get; set; }

        public int ItemId { get; set; }
        public Item item { get; set; }

    }
}
