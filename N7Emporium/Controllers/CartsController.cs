using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using N7Emporium.Data;

namespace N7Emporium.Controllers
{
    public class CartsController : Controller
    {
        private readonly N7EmporiumContext _context;

        public CartsController(N7EmporiumContext context)
        {
            _context = context;
        }

        private const string ANONYMOUS_IDENTIFIER = "AnonymousIdentifier";

        // GET: Carts
        public async Task<IActionResult> Index()
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
                    anonymousIdentifier = _context.Carts.Any() ? _context.Carts.Max(x => x.CookieId) + 1 : 1;
                    Response.Cookies.Append(ANONYMOUS_IDENTIFIER, anonymousIdentifier.ToString());
                }

                cart = _context.Carts.Include(x => x.ShipCarts).ThenInclude(x => x.Ship).Include(x => x.WeaponCarts).ThenInclude(x => x.Weapon).Include(x => x.ArmorCarts).ThenInclude(x => x.Armor).FirstOrDefault(c => c.CookieId == anonymousIdentifier);
            }
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart); //Here we're saying return our index view and pass in the parameter of "cart" (data type/model of 'cart')
                               //Or if we said "return View("Index", cart) where index, the first parameter, is the view and cart is the object model 
        }

        public IActionResult Remove(int id, string type)
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
                    anonymousIdentifier = _context.Carts.Any() ? _context.Carts.Max(x => x.CookieId) + 1 : 1;
                    Response.Cookies.Append(ANONYMOUS_IDENTIFIER, anonymousIdentifier.ToString());
                }

                cart = _context.Carts.Include(x => x.ShipCarts).ThenInclude(x => x.Ship).Include(x => x.WeaponCarts).ThenInclude(x => x.Weapon).Include(x => x.ArmorCarts).ThenInclude(x => x.Armor).FirstOrDefault(c => c.CookieId == anonymousIdentifier);
            }
            switch (type.ToLowerInvariant())
            {
                case "weapon":
                    {
                        var weapon = cart.WeaponCarts.FirstOrDefault(x => x.WeaponId == id);
                        if (weapon != null)
                        {
                            _context.WeaponCarts.Remove(weapon);
                            _context.SaveChanges();
                        }
                        break;
                    }
                case "armor":
                    {
                        var armor = cart.ArmorCarts.FirstOrDefault(x => x.ArmorId == id);
                        if (armor != null)
                        {
                            _context.ArmorCarts.Remove(armor);
                            _context.SaveChanges();
                        }
                        break;
                    }
                case "ship":
                    {
                        var ship = cart.ShipCarts.FirstOrDefault(x => x.ShipId == id);
                        if (ship != null)
                        {
                            _context.ShipCarts.Remove(ship);
                            _context.SaveChanges();
                        }
                        break;
                    }
            }
            return RedirectToAction("Index", "Carts"); 

        }

        public async Task<IActionResult> Update(int id, int quantity, string type)
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

            switch (type.ToLowerInvariant())
            {
                case "weapon":
                    {
                        var weapon = cart.WeaponCarts.FirstOrDefault(x => x.WeaponId == id);
                        if (weapon != null)
                        {
                            weapon.Quantity = quantity;
                            _context.SaveChanges();
                        }
                        break;
                    }
                case "armor":
                    {
                        var armor = cart.ArmorCarts.FirstOrDefault(x => x.ArmorId == id);
                        if (armor != null)
                        {
                            armor.Quantity = quantity;
                            _context.SaveChanges();
                        }
                        break;
                    }
                case "ship":
                    {
                        var ship = cart.ShipCarts.FirstOrDefault(x => x.ShipId == id);
                        if (ship != null)
                        {
                            ship.Quantity = quantity;
                            _context.SaveChanges();
                        }
                        break;
                    }
            }
            return RedirectToAction("Index", "Carts"); 
        }

    }
}
