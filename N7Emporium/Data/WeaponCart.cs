using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class WeaponCart
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int WeaponId { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public Weapon Weapon { get; set; }
    }
}
