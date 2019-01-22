using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N7Emporium.Data;
using N7Emporium.Models;
using SendGrid;
using Braintree;

namespace N7Emporium.Controllers
{
    public class CheckoutController : Controller
    {
        private const string ANONYMOUS_IDENTIFIER = "AnonymousIdentifier";

        private readonly N7EmporiumContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IBraintreeGateway _braintreeGateway;

        public CheckoutController(N7EmporiumContext context, IEmailSender emailSender, IBraintreeGateway braintreeGateway)
        {
            _context = context;
            _emailSender = emailSender;
            _braintreeGateway = braintreeGateway;
        }

        public async Task<IActionResult> Checkout()
        {
            ViewBag.BraintreeClientToken = await _braintreeGateway.ClientToken.GenerateAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model, string braintreeNonce)
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
                TransactionRequest transactionRequest = new TransactionRequest
                {
                    Amount = cart.WeaponCarts.Sum(x => x.Quantity * x.Weapon.Price) + cart.ArmorCarts.Sum(x => x.Quantity * x.Armor.Price) + cart.ShipCarts.Sum(x => x.Quantity * x.Ship.Price),
                    PaymentMethodNonce = braintreeNonce
                };
                var transactionResult = await _braintreeGateway.Transaction.SaleAsync(transactionRequest);
                if (transactionResult.IsSuccess())
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
                            Quantity = cartItem.Quantity,
                            ArmorId = cartItem.ArmorId
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

                    /*var message = new SendGrid.Helpers.Mail.SendGridMessage
                    {
                        From = new SendGrid.Helpers.Mail.EmailAddress(
                            "N7Emporium.Admin@N7.com", "N7 Administration"),
                        Subject = "Receipt for order #" + order.TrackingNumber,
                        HtmlContent = "Thanks for your order!"
                    };
                    message.AddTo(model.Email);*/

                    await _emailSender.SendEmailAsync(
                        model.Email,
                        "Receipt for order #" + order.TrackingNumber,
                        "Thanks for your order!"
                        );
                //The "actionname" i.e. the first argument must be the actual name of the view. So my receipt controller, has a method called Receipt, which is the view name. 
                return RedirectToAction("Receipt", "Receipt", new { id = order.TrackingNumber });
                }

            }


            return View();
        }


        /*private string FormatOrderAsHtml(Order order, HttpRequest httpRequest)
        {
            return string.Format(@"
               <div>
                <h1>Thank you for Your Order!</h1>
                <p>Thanks for order from N7 Emporium on {0}, your order is {1}. Please check {2} to track shipping and delivery.</p>
                <h2>Order Items</h2>
                <table>
                    {3}
                </table>
              </div>",
              DateTime.Now,
              order.TrackingNumber,
              string.Format("{0}://{1}receipt/index/{2}", httpRequest.Scheme, httpRequest.Host, order.TrackingNumber),
              string.Join("", order.WeaponOrders.Select(OrderItem => string.Format()
        }*/
    }
}