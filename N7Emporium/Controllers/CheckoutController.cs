using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N7Emporium.Data;
using N7Emporium.Models;

namespace N7Emporium.Controllers
{
    public class CheckoutController : Controller
    {
        private const string ANONYMOUS_IDENTIFIER = "AnonymousIdentifier";

        private readonly N7EmporiumContext _context;

        public CheckoutController(N7EmporiumContext context)
        {
            _context = context;
        }

        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            string username = null;
            int? anonymousIdentifier = null;
            Cart cart = null;
            ApplicationUser customer = null;
            if (User.Identity.IsAuthenticated)   //All controllers and views have a "User" property which I can check.  This returns True if they are logged in, false otherwise
            {
                username = User.Identity.Name;   //I can track carts by user name
                customer = _context.Users.Include(x => x.Carts).ThenInclude(x => x.ShipCarts).ThenInclude(x => x.Ship).Include(x => x.Carts).ThenInclude(x => x.WeaponCarts).ThenInclude(x => x.Weapon).Include(x => x.Carts).ThenInclude(x => x.ArmorCarts).ThenInclude(x => x.Armor).FirstOrDefault(x => x.UserName == username);
                cart = customer.Carts.FirstOrDefault();
            }
            else
            {
                anonymousIdentifier = null;
                if (Request.Cookies.ContainsKey(ANONYMOUS_IDENTIFIER))
                {
                    anonymousIdentifier = int.Parse(Request.Cookies[ANONYMOUS_IDENTIFIER]);
                }
                else
                {
                    anonymousIdentifier = int.Parse(Guid.NewGuid().ToString());
                    Response.Cookies.Append(ANONYMOUS_IDENTIFIER, anonymousIdentifier.ToString());
                }

                cart = _context.Carts.Include(x => x.ShipCarts).ThenInclude(x => x.Ship).Include(x => x.WeaponCarts).ThenInclude(x => x.Weapon).Include(x => x.ArmorCarts).ThenInclude(x => x.Armor).FirstOrDefault(c => c.CookieId == anonymousIdentifier);
            }

            if (ModelState.IsValid)
            {
                Order order = new Order
                {
                    ContactEmail = model.Email,
                    ContactPhoneNumber = model.PhoneNumber,
                    ShippingStreet1 = model.Street1,
                    ShippingStreet2 = model.Street2,
                    ShippingCity = model.City,
                    ShippingState = model.State,
                    ShippingPostalCode = model.PostalCode,


                    PlacementDate = DateTime.UtcNow,
                    TrackingNumber = Guid.NewGuid().ToString().Substring(0, 8),
                    SubTotal = cart.WeaponCarts.Sum(x => x.Quantity * x.Weapon.Price) + cart.ArmorCarts.Sum(x => x.Quantity * x.Armor.Price) + cart.ShipCarts.Sum(x => x.Quantity * x.Ship.Price),
                    Total = cart.WeaponCarts.Sum(x => x.Quantity * x.Weapon.Price) + cart.ArmorCarts.Sum(x => x.Quantity * x.Armor.Price) + cart.ShipCarts.Sum(x => x.Quantity * x.Ship.Price),
                    ArmorOrders = cart.ArmorCarts.Select(cartItem => new ArmorOrder
                    {   
                        Quantity = cartItem.Quantity, ArmorId = cartItem.ArmorId
                    }).ToArray(),
                    WeaponOrders = cart.WeaponCarts.Select(cartItem => new WeaponOrder
                    {
                        Quantity = cartItem.Quantity,
                        WeaponId = cartItem.WeaponId
                    }).ToArray(),
                    ShipOrders = cart.ShipCarts.Select(cartItem => new ShipOrder
                    {
                        Quantity = cartItem.Quantity,
                        ShipId = cartItem.ShipId
                    }).ToArray(),
                };
                _context.Orders.Add(order);
                _context.Carts.Remove(cart);
                Response.Cookies.Delete(ANONYMOUS_IDENTIFIER);
                _context.SaveChanges();
                return RedirectToAction("Receipt", "Receipt", new { id = order.TrackingNumber });
            }


            return View();
        }
    }
}