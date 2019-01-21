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
    public class ArmorController : Controller
    {
        private readonly N7EmporiumContext _context;

        public ArmorController(N7EmporiumContext context)
        {
            _context = context;
            //USING ENTITY FRAMEOWRK TO INSERT DATA 
            if (context.Armors.Count() == 0)
            {
                //context.Ships.Add(new Ships { Name = "TestAddShip", Description = "Desc", ArmorType = "Ablative Armor", Ftl = false, KineticBarrier = true, Price = 5400600, Type = "Dreadnought" });
                //Even though I'm adding these to the context, they don't get added to the database just yet! EF wants to create batches of commands to run to reduce "chatter".

                //Ask Joe if this is how I'd go about adding all my data according to his recommended approach - yup! Don't even need to delete the DB data.

                context.Armors.Add(new Armor { Name = "Ariake Technologies Armor", Description = "Armor ideally suited for rough terrain.", Price = 205670, Weight = 62, Type = "Human", Dexterity = 8, KineticBarrier = false, MediGelCapacity = 4, Image = "https://vignette.wikia.nocookie.net/masseffect/images/e/e2/ME3_ariake_technologies_set.png/revision/latest?cb=20120315001407" });
                context.Armors.Add(new Armor { Name = "Blood Dragon Armor", Description = "Sought after by the most infamous bounty hunters in the galaxy, this armor can take a beating.", Price = 245000, Weight = 81, Type = "Human", Dexterity = 6, KineticBarrier = true, MediGelCapacity = 6, Image = "https://vignette.wikia.nocookie.net/masseffect/images/9/9c/ME3_Blood_Dragon_Armor.png/revision/latest?cb=20120314192826" });
                context.Armors.Add(new Armor { Name = "Cerberus Nightmare Armor", Description = "Known for its common use by assassins, this armor allows for maximum dexterity and swiftness due to its lightweight design.", Price = 228220, Weight = 42, Type = "Human", Dexterity = 10, KineticBarrier = true, MediGelCapacity = 3, Image = "https://vignette.wikia.nocookie.net/masseffect/images/6/67/Cerberus_shade.jpg/revision/latest?cb=20130308134524" });
                context.Armors.Add(new Armor { Name = "Collector Armor", Description = "Constructed by the Collectors, no Milky Way Galaxy manufacturer has been able to synthesize the main material used in this armor.", Price = 267800, Weight = 80, Type = "Human", Dexterity = 5, KineticBarrier = true, MediGelCapacity = 5, Image = "https://vignette.wikia.nocookie.net/masseffect/images/a/ac/ME3_Collector_Armor.png/revision/latest?cb=20120314183021" });
                context.Armors.Add(new Armor { Name = "Terminus Assault Armor", Description = "Often jokingly referred to as 'Tron Armor', the Terminus Assault Armor works well with biotics.", Price = 233980, Weight = 74, Type = "Human", Dexterity = 7, KineticBarrier = false, MediGelCapacity = 3, Image = "https://vignette.wikia.nocookie.net/masseffect/images/2/23/ME3_Terminus_Assault_Armor.png/revision/latest?cb=20120314195928" });
                context.Armors.Add(new Armor { Name = "Roskenov Materials Armor", Description = "Styled for heavy infantry and brute force.", Price = 185000, Weight = 82, Type = "Human", Dexterity = 5, KineticBarrier = true, MediGelCapacity = 3, Image = "https://vignette.wikia.nocookie.net/masseffect/images/d/d5/ME3_rosenkov_materials_set.png/revision/latest?cb=20120315000059" });
                context.Armors.Add(new Armor { Name = "N7 Armor", Description = "Standard issue lightweight Systems Alliance infantry armor.", Price = 172340, Weight = 60, Type = "Human", Dexterity = 8, KineticBarrier = false, MediGelCapacity = 4, Image = "https://vignette.wikia.nocookie.net/masseffect/images/d/df/ME3_N7_Armor.png/revision/latest?cb=20120314160514" });
                context.Armors.Add(new Armor { Name = "Inferno Armor", Description = "With technology borrowed from the Krogan, this armor allows individuals to withstand excessive heat typically encountered on volcanically active planets.", Price = 200890, Weight = 75, Type = "Human", Dexterity = 7, KineticBarrier = true, MediGelCapacity = 5, Image = "https://vignette.wikia.nocookie.net/masseffect/images/9/96/ME3_Inferno_Armor.png/revision/latest?cb=20120314170848" });
                context.Armors.Add(new Armor { Name = "Cerberus Armor", Description = "Standard issue Cerberus armor.", Price = 199850, Weight = 70, Type = "Human", Dexterity = 8, KineticBarrier = true, MediGelCapacity = 5, Image = "https://vignette.wikia.nocookie.net/masseffect/images/3/35/ME3_Cerberus_Assault_Armor.png/revision/latest?cb=20120314164810" });
                context.Armors.Add(new Armor { Name = "Armax Arsenal Armor", Description = "Developed by Armax Arsenal, the inspiration for this set can be derived from the Dragon Blood Armor.", Price = 212350, Weight = 79, Type = "Human", Dexterity = 9, KineticBarrier = true, MediGelCapacity = 2, Image = "https://vignette.wikia.nocookie.net/masseffect/images/0/0e/ME3_armax_arsenal_set.png/revision/latest?cb=20120315002807" });
                context.Armors.Add(new Armor { Name = "Cerberus Ajax Armor", Description = "A heavily modified version of the standard Cerberus Armor, Ajax Armor is suited for all situations (pun intended)", Price = 245780, Weight = 77, Type = "Human", Dexterity = 7, KineticBarrier = true, MediGelCapacity = 4, Image = "https://vignette.wikia.nocookie.net/masseffect/images/f/f8/ME3_Cerberus_Ajax_Armor.png/revision/latest?cb=20121123062420" });
                context.Armors.Add(new Armor { Name = "Kassa Fabrication Armor", Description = "Standard issue Kassa infantry armor.", Price = 205780, Weight = 70, Type = "Human", Dexterity = 7, KineticBarrier = false, MediGelCapacity = 3, Image = "https://vignette.wikia.nocookie.net/masseffect/images/1/1d/ME3_kassa_fabrication_set.png/revision/latest?cb=20120314235118" });
                context.SaveChanges();
            }
        }
    

        // GET: Armor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Armors.ToListAsync());
        }

        // GET: Armor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armor = await _context.Armors
                .FirstOrDefaultAsync(m => m.ArmorId == id);
            if (armor == null)
            {
                return NotFound();
            }

            return View(armor);
        }

        // GET: Armor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Armor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArmorId,Name,Description,Price,Weight,Type,Dexterity,KineticBarrier,MediGelCapacity")] Armor armor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(armor);
        }

        // GET: Armor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armor = await _context.Armors.FindAsync(id);
            if (armor == null)
            {
                return NotFound();
            }
            return View(armor);
        }

        // POST: Armor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArmorId,Name,Description,Price,Weight,Type,Dexterity,KineticBarrier,MediGelCapacity")] Armor armor)
        {
            if (id != armor.ArmorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmorExists(armor.ArmorId))
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
            return View(armor);
        }

        // GET: Armor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armor = await _context.Armors
                .FirstOrDefaultAsync(m => m.ArmorId == id);
            if (armor == null)
            {
                return NotFound();
            }

            return View(armor);
        }

        // POST: Armor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var armor = await _context.Armors.FindAsync(id);
            _context.Armors.Remove(armor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmorExists(int id)
        {
            return _context.Armors.Any(e => e.ArmorId == id);
        }

        private const string ANONYMOUS_IDENTIFIER = "AnonymousIdentifier";

        //This is handling the "Add to Cart" button in the bottom of the Armor products thumbnails
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
                customer = _context.Users.Include(x => x.Carts).ThenInclude(x => x.ArmorCarts).ThenInclude(x => x.Armor).FirstOrDefault(x => x.UserName == username);
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

                cart = _context.Carts.Include(x => x.ArmorCarts).ThenInclude(x => x.Armor).FirstOrDefault(c => c.CookieId == anonymousIdentifier);
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
            ArmorCart armorCart = cart.ArmorCarts.FirstOrDefault(x => x.ArmorId == id);
            //If that line returns NULL, it's a new CartItem:
            if (armorCart == null)
            {
                armorCart = new ArmorCart
                {
                    Quantity = 0,
                    ArmorId = id
                };
                cart.ArmorCarts.Add(armorCart);
            }

            armorCart.Quantity += quantity;
            _context.SaveChanges();

            return RedirectToAction("Index", "Carts"); // From the Armor Index form then it comes to the ADD method here and ultimately says 
                                                       // direct me to the Carts Index view
        }
    }
}

