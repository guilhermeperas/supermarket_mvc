using Microsoft.AspNetCore.Mvc;

namespace Supermarket.Controllers
{
    public class Product : Controller
    {
        private static readonly List<ProductModel> products = new()
        {
            new ProductModel { id = 1, name = "Maçã", price = 3.50M },
            new ProductModel { id = 2, name = "Banana", price = 2.20M },
            new ProductModel { id = 3, name = "Laranja", price = 4.00M }
        };
        public IActionResult list()
        {
            string html = "<h1>Lista de Produtos</h1><ul>";
            foreach (var product in products)
            {
                html += $"<li><a href=products/{product.id}>{product.name} </a> - $ {product.price}</li>";
            }
            html += "</ul>";
            return Content(html, "text/html");

        }

        [Route("products/{id}")]
        public IActionResult details(int id)
        {
            var product = products.Find(p => p.id == id);
            if (product == null)
            {
                return NotFound("<h1>Produto não encontrado</h1>");
            }
            string html = $"<h1>Detalhes do Produto</h1><p>Nome: {product.name}</p><p>Preço: $ {product.price}</p>";
            return Content(html, "text/html");
        }

        [Route("products/json")]
        public IActionResult listJSON()
        {
            return Json(products);
        }

        public class ProductModel
        {
            public int id { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
        }
    }
}
