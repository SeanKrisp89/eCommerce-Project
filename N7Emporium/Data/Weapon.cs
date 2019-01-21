using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class Weapon
    {
        public Weapon()
        {
            WeaponCarts = new HashSet<WeaponCart>();
            WeaponOrders = new HashSet<WeaponOrder>();
        }

        public int WeaponId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? Weight { get; set; }
        public string Type { get; set; }
        public int? Range { get; set; }
        public int? ClipSize { get; set; }
        public int? FireRate { get; set; }
        public string Image { get; set; }

        public ICollection<WeaponCart> WeaponCarts { get; set; }
        public ICollection<WeaponOrder> WeaponOrders { get; set; }
    }
}
