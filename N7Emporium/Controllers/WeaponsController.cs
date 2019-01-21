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
    public class WeaponsController : Controller
    {
        private readonly N7EmporiumContext _context;

        public WeaponsController(N7EmporiumContext context)
        {
            _context = context;
            //USING ENTITY FRAMEOWRK TO INSERT DATA 
            if (context.Weapons.Count() == 0)
            {
                //context.Ships.Add(new Ships { Name = "TestAddShip", Description = "Desc", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought" });
                //Even though I'm adding these to the context, they don't get added to the database just yet! EF wants to create batches of commands to run to reduce "chatter".

                //Ask Joe if this is how I'd go about adding all my data according to his recommended approach - yup! Don't even need to delete the DB data.

                context.Weapons.Add(new Weapon { Name = "Cerberus Harrier", Description = "Fully automatic assault rifle by Cerberus Corps.", Price = 50000, Weight = 14, Type = "Assault", Range = 40, ClipSize = 50, FireRate = 5, Image = "https://vignette.wikia.nocookie.net/masseffect/images/0/0d/ME3_Cerberus_Harrier.png/revision/latest?cb=20120530214013" });
                context.Weapons.Add(new Weapon { Name = "Chakram Launcher", Description = "Fully automatic assault rifle by Ama-Lur Equipment.", Price = 75000, Weight = 22, Type = "Assault", Range = 60, ClipSize = 8, FireRate = 1, Image = "https://vignette.wikia.nocookie.net/masseffect/images/5/56/ME3_Chakram_Assault_Rifle.png/revision/latest?cb=20120317175958" });
                context.Weapons.Add(new Weapon { Name = "Collector Assault Rifle", Description = "Fully automatic assault rifle with Collector-infused technology.", Price = 120000, Weight = 12, Type = "Assault", Range = 35, ClipSize = 60, FireRate = 20, Image = "https://vignette.wikia.nocookie.net/masseffect/images/f/f8/ME3_Collector_Assault_Rifle.png/revision/latest?cb=20120317180554" });
                context.Weapons.Add(new Weapon { Name = "Geth Pulse Rifle", Description = "Main rifle utilized by Geth infantry, developed by Geth Armory.", Price = 30000, Weight = 10, Type = "Assault", Range = 25, ClipSize = 40, FireRate = 15, Image = "https://vignette.wikia.nocookie.net/masseffect/images/9/92/ME3_Geth_Pulse_Assault_Rifle.png/revision/latest?cb=20120317181047" });
                context.Weapons.Add(new Weapon { Name = "Geth Spitfire", Description = "", Price = 60000, Weight = 16, Type = "Assault", Range = 45, ClipSize = 50, FireRate = 15, Image = "https://vignette.wikia.nocookie.net/masseffect/images/1/1d/ME3_Geth_Spitfire_Heavy_Weapon.png/revision/latest?cb=20120317194711" });
                context.Weapons.Add(new Weapon { Name = "M7 Lancer", Description = "", Price = 50000, Weight = 11, Type = "Assault", Range = 40, ClipSize = 40, FireRate = 15, Image = "https://vignette.wikia.nocookie.net/masseffect/images/c/c6/ME3_Lancer_AS.png/revision/latest?cb=20130227094559" });
                context.Weapons.Add(new Weapon { Name = "M8 Avenger", Description = "", Price = 33000, Weight = 15, Type = "Assault", Range = 30, ClipSize = 100, FireRate = 13, Image = "https://vignette.wikia.nocookie.net/masseffect/images/2/29/ME3_Avenger_Assault_Rifle.png/revision/latest?cb=20120317171316" });
                context.Weapons.Add(new Weapon { Name = "M55 Argus", Description = "", Price = 151000, Weight = 18, Type = "Assault", Range = 50, ClipSize = 150, FireRate = 23, Image = "https://vignette.wikia.nocookie.net/masseffect/images/9/95/ME3_Argus_Assault_Rifle.png/revision/latest?cb=20120317173420" });
                context.Weapons.Add(new Weapon { Name = "N7 Valkyrie", Description = "", Price = 44500, Weight = 10, Type = "Assault", Range = 50, ClipSize = 40, FireRate = 8, Image = "https://vignette.wikia.nocookie.net/masseffect/images/0/08/ME3_N7_Valkyrie_Assault_Rifle.png/revision/latest?cb=20120317181450" });
                context.Weapons.Add(new Weapon { Name = "M96 Mattock", Description = "", Price = 67000, Weight = 11, Type = "Assault", Range = 38, ClipSize = 28, FireRate = 27, Image = "https://vignette.wikia.nocookie.net/masseffect/images/9/93/ME3_Mattock_Assault_Rifle.png/revision/latest?cb=20120317182842" });
                context.Weapons.Add(new Weapon { Name = "Black Widow", Description = "", Price = 182000, Weight = 18, Type = "Sniper Rifle", Range = 200, ClipSize = 12, FireRate = 3, Image = "https://vignette.wikia.nocookie.net/masseffect/images/4/44/ME3_Black_Widow_Sniper_Rifle.png/revision/latest?cb=20120317191926" });
                context.Weapons.Add(new Weapon { Name = "Collector Sniper Rifle", Description = "", Price = 210000, Weight = 22, Type = "Sniper Rifle", Range = 212, ClipSize = 15, FireRate = 2, Image = "https://vignette.wikia.nocookie.net/masseffect/images/4/40/ME3_Collector_Sniper_Rifle.png/revision/latest?cb=20121009204028" });
                context.Weapons.Add(new Weapon { Name = "Javelin", Description = "", Price = 222000, Weight = 25, Type = "Sniper Rifle", Range = 40, ClipSize = 8, FireRate = 1, Image = "https://vignette.wikia.nocookie.net/masseffect/images/7/7b/ME3_Javelin_Sniper_Rifle.png/revision/latest?cb=20120317192031" });
                context.Weapons.Add(new Weapon { Name = "Kishock Harpoon Gun", Description = "", Price = 100000, Weight = 16, Type = "Sniper Rifle", Range = 170, ClipSize = 10, FireRate = 5, Image = "https://vignette.wikia.nocookie.net/masseffect/images/d/db/ME3_Kishock_Harpoon_Gun.png/revision/latest?cb=20120411201323" });
                context.Weapons.Add(new Weapon { Name = "Krysae Sniper Rifle", Description = "", Price = 183500, Weight = 21, Type = "Sniper Rifle", Range = 242, ClipSize = 15, FireRate = 5, Image = "https://vignette.wikia.nocookie.net/masseffect/images/2/2f/ME3_Krysae_Sniper_Rifle.png/revision/latest?cb=20120530214006" });
                context.Weapons.Add(new Weapon { Name = "M13 Raptor", Description = "", Price = 178300, Weight = 19, Type = "Sniper Rifle", Range = 238, ClipSize = 10, FireRate = 4, Image = "https://vignette.wikia.nocookie.net/masseffect/images/7/70/ME3_Raptor_Sniper_Rifle.png/revision/latest?cb=20120317191426" });
                context.Weapons.Add(new Weapon { Name = "M29 Incisor", Description = "", Price = 165780, Weight = 23, Type = "Sniper Rifle", Range = 226, ClipSize = 10, FireRate = 4, Image = "https://vignette.wikia.nocookie.net/masseffect/images/7/70/ME3_Raptor_Sniper_Rifle.png/revision/latest?cb=20120317191426" });
                context.Weapons.Add(new Weapon { Name = "M92 Mantis", Description = "", Price = 177450, Weight = 18, Type = "Sniper Rifle", Range = 205, ClipSize = 20, FireRate = 7, Image = "https://vignette.wikia.nocookie.net/masseffect/images/7/7b/ME3_Mantis_Sniper_Rifle.png/revision/latest?cb=20120317191621" });
                context.Weapons.Add(new Weapon { Name = "Acolyte", Description = "", Price = 85450, Weight = 6, Type = "Heavy Pistol", Range = 40, ClipSize = 20, FireRate = 5, Image = "https://vignette.wikia.nocookie.net/masseffect/images/b/b9/ME3_Acolyte_Pistol.png/revision/latest?cb=20120714073045" });
                context.Weapons.Add(new Weapon { Name = "Arc Pistol", Description = "", Price = 88900, Weight = 6, Type = "Heavy Pistol", Range = 40, ClipSize = 20, FireRate = 5, Image = "https://vignette.wikia.nocookie.net/masseffect/images/e/e8/ME3_Arc_Heavy_Pistol.png/revision/latest?cb=20120317185747" });
                context.Weapons.Add(new Weapon { Name = "m3 Predator", Description = "", Price = 72340, Weight = 4, Type = "Heavy Pistol", Range = 30, ClipSize = 18, FireRate = 5, Image = "https://vignette.wikia.nocookie.net/masseffect/images/c/c8/ME3_Predator_Heavy_Pistol.png/revision/latest?cb=20120317185446" });
                context.Weapons.Add(new Weapon { Name = "M5 Phalanx", Description = "", Price = 78450, Weight = 4, Type = "Heavy Pistol", Range = 45, ClipSize = 18, FireRate = 7, Image = "https://vignette.wikia.nocookie.net/masseffect/images/a/ae/ME3_Phalanx_Heavy_Pistol.png/revision/latest?cb=20120317185535" });
                context.Weapons.Add(new Weapon { Name = "M6 Carnifex", Description = "", Price = 65780, Weight = 7, Type = "Heavy Pistol", Range = 45, ClipSize = 18, FireRate = 7, Image = "https://vignette.wikia.nocookie.net/masseffect/images/8/88/ME3_Carnifex_Heavy_Pistol.png/revision/latest?cb=20120317185613" });
                context.Weapons.Add(new Weapon { Name = "M77 Paladin", Description = "", Price = 88940, Weight = 8, Type = "Heavy Pistol", Range = 45, ClipSize = 12, FireRate = 6, Image = "https://vignette.wikia.nocookie.net/masseffect/images/4/43/ME3_Paladin_Heavy_Pistol.png/revision/latest?cb=20120317185630" });
                context.Weapons.Add(new Weapon { Name = "M358 Talon", Description = "", Price = 90000, Weight = 5, Type = "Heavy Pistol", Range = 45, ClipSize = 20, FireRate = 8, Image = "https://vignette.wikia.nocookie.net/masseffect/images/9/99/ME3_Talon_Heavy_Pistol.png/revision/latest?cb=20120317185721" });
                context.Weapons.Add(new Weapon { Name = "N7 Eagle", Description = "", Price = 72350, Weight = 7, Type = "Heavy Pistol", Range = 45, ClipSize = 20, FireRate = 8, Image = "https://vignette.wikia.nocookie.net/masseffect/images/0/01/ME3_N7_Eagle_Heavy_Pistol.png/revision/latest?cb=20120317185811" });
                context.Weapons.Add(new Weapon { Name = "M11 Suppressor", Description = "", Price = 72350, Weight = 4, Type = "Heavy Pistol", Range = 45, ClipSize = 12, FireRate = 8, Image = "https://vignette.wikia.nocookie.net/masseffect/images/8/84/ME3_Suppressor.png/revision/latest?cb=20130227094606" });
                context.Weapons.Add(new Weapon { Name = "Scorpion", Description = "", Price = 112000, Weight = 4, Type = "Heavy Pistol", Range = 52, ClipSize = 21, FireRate = 8, Image = "https://vignette.wikia.nocookie.net/masseffect/images/4/40/ME3_Scorpion_Heavy_Pistol.png/revision/latest?cb=20120317185843" });
                context.Weapons.Add(new Weapon { Name = "M98 Widow", Description = "", Price = 180310, Weight = 14, Type = "Sniper Rifle", Range = 188, ClipSize = 16, FireRate = 5, Image = "https://vignette.wikia.nocookie.net/masseffect/images/1/1d/ME3_Widow_Sniper_Rifle.png/revision/latest?cb=20120317191850" });
                context.Weapons.Add(new Weapon { Name = "N7 Valiant", Description = "", Price = 118960, Weight = 14, Type = "Sniper Rifle", Range = 178, ClipSize = 11, FireRate = 3, Image = "https://vignette.wikia.nocookie.net/masseffect/images/1/14/ME3_N7_Valiant_Sniper_Rifle.png/revision/latest?cb=20120317192204" });
                context.SaveChanges();
            }
        }

            // GET: Weapons
            public async Task<IActionResult> Index()
        {
            return View(await _context.Weapons.ToListAsync());
        }

        // GET: Weapons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapons = await _context.Weapons
                .FirstOrDefaultAsync(m => m.WeaponId == id);
            if (weapons == null)
            {
                return NotFound();
            }

            return View(weapons);
        }

        // GET: Weapons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weapons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeaponId,Name,Description,Price,Weight,Type,Range,ClipSize,FireRate")] Weapon weapons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weapons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weapons);
        }

        // GET: Weapons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapons = await _context.Weapons.FindAsync(id);
            if (weapons == null)
            {
                return NotFound();
            }
            return View(weapons);
        }

        // POST: Weapons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WeaponId,Name,Description,Price,Weight,Type,Range,ClipSize,FireRate")] Weapon weapons)
        {
            if (id != weapons.WeaponId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weapons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeaponsExists(weapons.WeaponId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(weapons);
        }

        // GET: Weapons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapons = await _context.Weapons
                .FirstOrDefaultAsync(m => m.WeaponId == id);
            if (weapons == null)
            {
                return NotFound();
            }

            return View(weapons);
        }

        // POST: Weapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weapons = await _context.Weapons.FindAsync(id);
            _context.Weapons.Remove(weapons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeaponsExists(int id)
        {
            return _context.Weapons.Any(e => e.WeaponId == id);
        }

        private const string ANONYMOUS_IDENTIFIER = "AnonymousIdentifier";

        //This is handling the "Add to Cart" button in the bottom of the ships products thumbnails
        public IActionResult Add(int quantity, int id)
        {

            //An anonymous user adds a new item to a new cart 
            //An anonymous user adds a new item to an existing cart
            //An anonymous user an existing item to an existing cart 
            //A registered user adds a new item to a new cart 
            //A registered user adds a new item to an existing cart
            //A registered user an existing item to an existing cart 

            //Three questions need to be answered:

            //Who is the user? (if anonymous, how do I track them?), Does the cart exist, does the item exist? 
            string username = null;
            int? anonymousIdentifier = null;
            Cart cart = null;
            ApplicationUser customer = null;
            if (User.Identity.IsAuthenticated)   //All controllers and views have a "User" property which I can check.  This returns True if they are logged in, false otherwise
            {
                username = User.Identity.Name;   //I can track carts by user name
                customer = _context.Users.Include(x => x.Carts).ThenInclude(x => x.WeaponCarts).ThenInclude(x => x.Weapon).FirstOrDefault(x => x.UserName == username);
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

                cart = _context.Carts.Include(x => x.WeaponCarts).ThenInclude(x => x.Weapon).FirstOrDefault(c => c.CookieId == anonymousIdentifier);
            }
            //If I get to this line and cart is still NULL, the user doesn't have an existing Cart!  Create one!
            if (cart == null)
            {
                cart = new Cart
                {
                    CookieId = anonymousIdentifier ?? -1,
                    Customer = customer,
                    DateCreated = DateTime.UtcNow
                };
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            //Once I get past that last block, I will have a Cart (either a completely new one, or an existing one)
            //I now need to see if the cart contains the item already.
            WeaponCart weaponCart = cart.WeaponCarts.FirstOrDefault(x => x.WeaponId == id);
            //If that line returns NULL, it's a new CartItem:
            if (weaponCart == null)
            {
                weaponCart = new WeaponCart
                {
                    Quantity = 0,
                    WeaponId = id
                };
                cart.WeaponCarts.Add(weaponCart);
            }

            weaponCart.Quantity += quantity;
            _context.SaveChanges();

            return RedirectToAction("Index", "Carts"); // From the Weapon Index form then it comes to the ADD method here and ultimately says 
                                                       // direct me to the Carts Index view
        }
    }
}
