namespace Restaurant.Models
{
    public class MesaItem
    {

        public int MesaId { get; set; }
        public Mesa mesa { get; set; }

        public int ItemId { get; set; }
        public Item item { get; set; }

    }
}
