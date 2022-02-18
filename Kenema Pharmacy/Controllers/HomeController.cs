using Kenema_Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenema_Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        Kenema_PharmacyEntities1 _context = new Kenema_PharmacyEntities1();
        public ActionResult Index(string search = " ")
        {

            if (search.Equals(" "))
            {


                var lists = _context.MedicalProducts.ToList();

                return View(lists);
            }
            else
            {
                var lists = _context.MedicalProducts.Where(x => x.Category.CategoryName.Contains(search)).ToList();
                return View(lists);

            }
        }
            public ActionResult AddtoCart(int productId)
            {
                if (Session["cart"] == null)
                {
                    List<Item> cart = new List<Item>();
                    var product = _context.MedicalProducts.Find(productId);
                    cart.Add(new Item()
                    {
                        Product = product,
                        Stock = 1
                    });
                    Session["cart"] = cart;

                }
                else
                {
                    List<Item> cart = (List<Item>)Session["cart"];
                    var product = _context.MedicalProducts.Find(productId);
                    foreach (var item in cart.ToList())
                    {
                        if (item.Product.ProductId == productId)
                        {
                            int prevItem = item.Stock;
                            cart.Remove(item);
                            cart.Add(new Item()
                            {
                                Product = product,
                                Stock = prevItem + 1
                            });
                            break;
                        }
                        else
                        {

                            cart.Add(new Item()
                            {
                                Product = product,
                                Stock = 1
                            });


                        }

                    }

                    Session["cart"] = cart;

                }



                return Redirect("Index");

            }

        public ActionResult RemovefromCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            ViewBag.count = cart.Count();
            foreach (var item in cart)
            {
                if (item.Product.ProductId == productId)
                {
                    cart.Remove(item);
                    break;
                }
            }

            Session["cart"] = cart;

            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
             _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }






    }
}