using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class ShipCart
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ShipId { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public Ship Ship { get; set; }
    }
}
