using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class Cart
    {
        public Cart()
        {
            ArmorCarts = new HashSet<ArmorCart>();
            ShipCarts = new HashSet<ShipCart>();
            WeaponCarts = new HashSet<WeaponCart>();
        }

        public int CartId { get; set; }
        public int CookieId { get; set; }
        public DateTime DateCreated { get; set; }

        public ApplicationUser Customer { get; set; }
        public ICollection<ArmorCart> ArmorCarts { get; set; }
        public ICollection<ShipCart> ShipCarts { get; set; }
        public ICollection<WeaponCart> WeaponCarts { get; set; }
    }
}
