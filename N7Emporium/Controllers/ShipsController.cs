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
    public class ShipsController : Controller
    {
        private readonly N7EmporiumContext _context;

        public ShipsController(N7EmporiumContext context)
        {
            _context = context;
            //USING ENTITY FRAMEOWRK TO INSERT DATA 
            if (context.Ships.Count() == 0)
            {
                //context.Ships.Add(new Ships { Name = "TestAddShip", Description = "Desc", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought" });
                //Even though I'm adding these to the context, they don't get added to the database just yet! EF wants to create batches of commands to run to reduce "chatter".

                //Ask Joe if this is how I'd go about adding all my data according to his recommended approach
                context.Ships.Add(new Ship { Name = "Alarei", Description = "A ship used by Admiral Rael-Zorah to carry out his studies on Geth countermeasures. Overtaken by reactivated Geth units in 2185.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://i.redd.it/v8c4o2tlyg7y.png" });
                context.Ships.Add(new Ship { Name = "Normandy SR-2", Description = "A Cerberus frigate based on the SSV Normandy SR-1. Claimed, assigned the SSV prefix, and refitted by the Alliance in 2186. Commanded by Commander Shepard.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://vignette.wikia.nocookie.net/masseffect/images/b/b4/Codex_Normandy_SR-2_%28ME3%29.png/revision/latest?cb=20120320202410" });
                context.Ships.Add(new Ship { Name = "Penumbra Apex", Description = "The flagship of the Prothean Empire's navy.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://i.pinimg.com/originals/8a/0d/a8/8a0da89d17b2a491e4f19aadd50ab437.jpg" });
                context.Ships.Add(new Ship { Name = "Quarian Envoy Ship", Description = "A quarian diplomatic frigate of advanced design sent to meet Commander Shepard in the Dholen system in 2186.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/intermediary/f/14742e20-ac3e-4580-b025-163d5b8c6575/dba5sw1-2bb790bc-ba12-4a84-b2aa-bc9407f5f84f.jpg/v1/fill/w_1131,h_707,q_70,strp/envoy_ship_by_euderion_dba5sw1-pre.jpg" });
                context.Ships.Add(new Ship { Name = "Periphona", Description = "A survey vessel from the Leusinia ark. Flight recorder ended up on the frozen wastes of Voeld.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://cdn.segmentnext.com/wp-content/uploads/2017/03/7-1.jpg" });
                context.Ships.Add(new Ship { Name = "Destiny Ascension", Description = "The most powerful warship built by the asari and flagship of the Citadel Fleet in 2183. Spared during the Battle of the Citadel. Commanded by Matriarch Lidanya.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://vignette.wikia.nocookie.net/masseffect/images/e/e8/WA_AsariCruiser.png/revision/latest?cb=20120326173630" });
                context.Ships.Add(new Ship { Name = "MSV Icarus", Description = "A freighter chartered by the Project Scarab team of Task Force Aurora, headed by Dr. Ann Bryson. The Icarus was designed for long-range FTL travel.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://www.wallpaperup.com/uploads/wallpapers/2014/01/24/236168/e587711e9fd72a116936ee1222472adb-700.jpg" });
                context.Ships.Add(new Ship { Name = "Tempest", Description = "The only one left in existence, the Andromeda Initiative Survey Ship is designed for a Pathfinder. Lightweight and lacking weapons, it relies on an IES stealth system and kinetic barriers for defense. Commanded by Pathfinder Ryder.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://www.rockpapershotgun.com/images/17/jan/tempest1.jpg/RPSS/resize/760x-1/format/jpg/quality/70" });
                context.Ships.Add(new Ship { Name = "Kwunu", Description = "The Vol Protectorate's sole dreadnought, named for the volus who negotiated client-race status with the turians. Its construction was funded by the Elkoss Combine.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://vignette.wikia.nocookie.net/masseffectships/images/1/19/Images_%282%29.jpg/revision/latest?cb=20120727103452" });
                context.Ships.Add(new Ship { Name = "Harbinger", Description = "Believed to be the oldest and largest Reaper. Instigated the Collector attacks on human colonies in 2185, and participated in the Reaper invasion of Earth in 2186.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "http://3.bp.blogspot.com/-BkyxFXcz77w/T2YgEgA6oJI/AAAAAAAABkw/AM_-oaqRZRE/s640/Mass-Effect-3-Earth-Reaper.jpg" });
                context.Ships.Add(new Ship { Name = "Derelict Repaer", Description = "	A Reaper in orbit above Mnemosyne that was disabled 37 million years ago. In 2185, Commander Shepard retrieves the Reaper's IFF.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://i.pinimg.com/originals/c3/19/f9/c319f9003e8e034427755e3ee2b8751f.jpg" });
                context.Ships.Add(new Ship { Name = "Elbrus", Description = "Flagship of a Cerberus fleet sent to Omega in 2186. Commanded by Oleg Petrovsky.", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought", Image = "https://cdn.player.one/sites/player.one/files/styles/lg/public/2017/03/23/mass-effect-spaceship.jpg" });
                context.SaveChanges();
                //The context.SaveChanes() method is the "sync" operation. It's saying go ahead and persist these records!
            }
        }

        // GET: Ships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ships.ToListAsync());
        }

        // GET: Ships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ships = await _context.Ships
                .FirstOrDefaultAsync(m => m.ShipId == id);
            if (ships == null)
            {
                return NotFound();
            }

            return View(ships);
        }

        // GET: Ships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipId,Name,Description,Price,Ftl,Type,ArmorType,KineticBarrier")] Ship ships)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ships);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ships);
        }

        // GET: Ships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ships = await _context.Ships.FindAsync(id);
            if (ships == null)
            {
                return NotFound();
            }
            return View(ships);
        }

        // POST: Ships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipId,Name,Description,Price,Ftl,Type,ArmorType,KineticBarrier")] Ship ships)
        {
            if (id != ships.ShipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ships);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipsExists(ships.ShipId))
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
            return View(ships);
        }

        // GET: Ships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ships = await _context.Ships
                .FirstOrDefaultAsync(m => m.ShipId == id);
            if (ships == null)
            {
                return NotFound();
            }

            return View(ships);
        }

        // POST: Ships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ships = await _context.Ships.FindAsync(id);
            _context.Ships.Remove(ships);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipsExists(int id)
        {
            return _context.Ships.Any(e => e.ShipId == id);
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
                customer = _context.Users.Include(x => x.Carts).ThenInclude(x => x.ShipCarts).ThenInclude(x => x.Ship).FirstOrDefault(x => x.UserName == username);
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

                cart = _context.Carts.Include(x => x.ShipCarts).ThenInclude(x => x.Ship).FirstOrDefault(c => c.CookieId == anonymousIdentifier);
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
            ShipCart shipCart = cart.ShipCarts.FirstOrDefault(x => x.ShipId == id);
            //If that line returns NULL, it's a new CartItem:
            if (shipCart == null)
            {
                shipCart = new ShipCart
                {
                    Quantity = 0,
                    ShipId = id
                };
                cart.ShipCarts.Add(shipCart);
            }

            shipCart.Quantity += quantity;
            _context.SaveChanges();

            return RedirectToAction("Index", "Carts"); // From the Ship Index form then it comes to the ADD method here and ultimately says 
                                                       // direct me to the Carts Index view
        }
    }
}
