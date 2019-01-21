using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class ArmorCart
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ArmorId { get; set; }
        public int Quantity { get; set; }

        public Armor Armor { get; set; }
        public Cart Cart { get; set; }
    }
}
