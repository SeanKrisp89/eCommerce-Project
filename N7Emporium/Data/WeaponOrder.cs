using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class WeaponOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int WeaponId { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Weapon Weapon { get; set; }
    }
}

