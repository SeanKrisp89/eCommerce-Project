using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class Ship
    {
        public Ship()
        {
            ShipCarts = new HashSet<ShipCart>();
            ShipOrders = new HashSet<ShipOrder>();
        }

        public int ShipId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool? Ftl { get; set; }
        public string Type { get; set; }
        public string ArmorType { get; set; }
        public bool? KineticBarrier { get; set; }
        public string Image { get; set; }

        public ICollection<ShipCart> ShipCarts { get; set; }
        public ICollection<ShipOrder> ShipOrders { get; set; }
    }
}
