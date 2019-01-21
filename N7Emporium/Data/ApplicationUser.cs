using System;
using System.Collections.Generic;

namespace N7Emporium.Data
{
    public partial class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public ApplicationUser()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }
        
        public string Fname { get; set; }
        public string Lname { get; set; }
        
        public DateTime Birthdate { get; set; }

        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
