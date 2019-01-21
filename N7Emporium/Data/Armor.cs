using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class Armor
    {
        public Armor()
        {
            ArmorCarts = new HashSet<ArmorCart>();
            ArmorOrders = new HashSet<ArmorOrder>();
        }

        public int ArmorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? Weight { get; set; }
        public string Type { get; set; }
        public int? Dexterity { get; set; }
        public bool? KineticBarrier { get; set; }
        public int? MediGelCapacity { get; set; }
        public string Image { get; set; }

        public ICollection<ArmorCart> ArmorCarts { get; set; }
        public ICollection<ArmorOrder> ArmorOrders { get; set; }
    }
}
