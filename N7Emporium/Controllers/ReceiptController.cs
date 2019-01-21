using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N7Emporium.Data;

namespace N7Emporium.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly N7EmporiumContext _context;

        public ReceiptController(N7EmporiumContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Receipt (string id)
        {
            var order = await _context.Orders.Include(x => x.WeaponOrders).ThenInclude(x => x.Weapon).Include(x => x.ArmorOrders).ThenInclude(x => x.Armor).Include(x => x.ShipOrders).ThenInclude(x => x.Ship).FirstOrDefaultAsync(x => x.TrackingNumber == id);
            return View(order);
        }
    }
}