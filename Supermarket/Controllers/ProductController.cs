using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;

namespace Supermarket.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new()
        {
            new Product { id = 1, name = "Maçã", price = 3.50 },
            new Product { id = 2, name = "Banana", price = 2.20 },
            new Product { id = 3, name = "Laranja", price = 4.00 }
        };
        public IActionResult List()
        {
           return View(products);
        }

        public IActionResult Detail(int id)
        {
            var product = products.Find(p => p.id == id);
            if (product == null)
            {
                return View("NotFound");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = products.Find(p => p.id == id);
            if (product == null)
            {
                return View("NotFound");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product updated_product)
        {
            var product = products.Find(p => p.id == updated_product.id);
            if (product == null)
            {
                return View("NotFound");
            }
            product.name = updated_product.name;
            product.price = updated_product.price;
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var product = products.Find(p => p.id == id);
            if (product == null)
            {
                return View("NotFound");
            }
            products.Remove(product);
            return RedirectToAction("List");
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product new_product)
        {
            if(new_product == null)
                return View("NotFound");
            products.Add(new_product);
            return RedirectToAction("List");
        }

        [Route("products/json")]
        public IActionResult listJSON()
        {
            return Json(products);
        }
    }
}
