using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace N7Emporium.Data
{
    public partial class N7EmporiumContext : IdentityDbContext<ApplicationUser>
    {
        public N7EmporiumContext()
        {
        }

        public N7EmporiumContext(DbContextOptions<N7EmporiumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Armor> Armors { get; set; }
        public virtual DbSet<ArmorCart> ArmorCarts { get; set; }
        public virtual DbSet<ArmorOrder> ArmorOrders { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ShipCart> ShipCarts { get; set; }
        public virtual DbSet<ShipOrder> ShipOrders { get; set; }
        public virtual DbSet<Ship> Ships { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<WeaponCart> WeaponCarts { get; set; }
        public virtual DbSet<WeaponOrder> WeaponOrders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }  
        
    }
}

/* What I did to add the OrderItems table to the database, as well as update the columns in the Orders table:
 * Went to Order.cs in the data folder
 * Added the columns to Orders
 * Added the OrderItems class (table)
 * THEN added the OrderItems class/table above to the N7Emporium Database context 
 * Then in the command prompt went to my .csproj location, entered "dotnet ef migrations add <whatever I name the migration> "OrderItems"
 * Then in the command prompt entered "dotnet ef database update"
 * WHAT THIS DID: Code first entities! One of our use cases. We created database entities via C# code
 */