using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mock_BestBuy_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository repo;


        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = repo.GetProducts();

            return Ok(JsonConvert.SerializeObject(products));
        }


        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var p = repo.GetProduct(id);

            return Ok(JsonConvert.SerializeObject(p));
        }


        [HttpPost]
        public void CreateProduct(Product product)
        {
            var lastId = repo.GetProducts().Last().ProductID;

            product.ProductID = lastId++;

            repo.InsertProduct(product);


        }
        [HttpPut("{id}")]
        public void UpdateProduct(int id, Product product)
        {
            product.ProductID = id;

            repo.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = repo.GetProduct(id);

            repo.DeleteProduct(product);
        }



    }
}
