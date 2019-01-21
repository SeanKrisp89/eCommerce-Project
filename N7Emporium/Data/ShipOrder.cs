using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class ShipOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ShipId { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Ship Ship { get; set; }
    }
}
