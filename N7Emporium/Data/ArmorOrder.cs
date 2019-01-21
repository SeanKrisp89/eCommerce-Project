using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class ArmorOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ArmorId { get; set; }
        public int Quantity { get; set; }

        public Armor Armor { get; set; }
        public Order Order { get; set; }
    }
}
