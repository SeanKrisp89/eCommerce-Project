using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace N7Emporium.Data
{
    public partial class Order
    {
        public Order()
        {
            ArmorOrders = new HashSet<ArmorOrder>();
            ShipOrders = new HashSet<ShipOrder>();
            WeaponOrders = new HashSet<WeaponOrder>();
        }

        public int OrderId { get; set; }
        public DateTime DateOrdered { get; set; }
        public string TrackingNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public DateTime PlacementDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        [Column(TypeName = "Money")]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "Money")]
        public decimal Tax { get; set; }
        [Column(TypeName = "Money")]
        public decimal Shipping { get; set; }
        [Column(TypeName = "Money")]
        public decimal Total { get; set; }

        public string ShippingStreet1 { get; set; }
        public string ShippingStreet2 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingRecipient { get; set; }
        public string ShippingInstructions { get; set; }        

        public ApplicationUser Customer { get; set; }
        public ICollection<ArmorOrder> ArmorOrders { get; set; }
        public ICollection<ShipOrder> ShipOrders { get; set; }
        public ICollection<WeaponOrder> WeaponOrders { get; set; }
    }

    public class OrderItem
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public int WeaponID { get; set; }
        public int ArmorID { get; set; }
        public int ShipID { get; set; }
        public string WeaponName { get; set; }
        public string WeaponDescription { get; set; }
        public string ArmorName { get; set; }
        public string ArmorDescription { get; set; }
        public string ShipName { get; set; }
        public string ShipDescription { get; set; }
        [Column(TypeName = "Money")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "Money")]
        public decimal LineTotal { get; set; }

    }
}
