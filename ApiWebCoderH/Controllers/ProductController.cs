using Microsoft.AspNetCore.Mvc;
using ApiWebCoderH.Models;
using ApiWebCoderH.Repositories;

namespace ApiWebCoderH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("{userId}")]
        public ActionResult<List<Product>>? Get(long userId)
        {
            try
            {
                return Ok(RProduct.SelectProduct(userId));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Product>>? Get()
        {
            try
            {
                return Ok(RProduct.SelectProducts());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] long id)
        {
            try
            {
                int rowsAffected = RProduct.DeleteProduct(id);
                if (rowsAffected > 0)
                    return Ok($"Rows affected: {rowsAffected}");
                return NotFound("Id not found");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            try
            {
                int rowsAffected = RProduct.InsertProduct(product);
                if (rowsAffected > 0)
                    return Ok($"Rows affected: {rowsAffected}");
                return NotFound("Id not found");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] Product product)
        {
            try
            {
                int rowsAffected = RProduct.UpdateProduct(product);
                if (rowsAffected > 0)
                    return Ok($"Rows affected: {rowsAffected}");
                return NotFound("Id not found");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
