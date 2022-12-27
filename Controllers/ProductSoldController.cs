using Microsoft.AspNetCore.Mvc;
using ApiWebCoderH.Models;
using ApiWebCoderH.Repositories;

namespace ApiWebCoderH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductSoldController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<ProductSold>? Get(long id)
        {
            try
            {
                return Ok(RProductSold.SelectProductSold(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<ProductSold>>? Get()
        {
            try
            {
                return Ok(RProductSold.SelectProductsSold());
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
                int rowsAffected = RProductSold.DeleteProductSold(id);
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
        public ActionResult Post([FromBody] ProductSold productSold)
        {
            try
            {
                int rowsAffected = RProductSold.InsertProductSold(productSold);
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
        public ActionResult Put([FromBody] ProductSold productSold)
        {
            try
            {
                int rowsAffected = RProductSold.UpdateProductSold(productSold);
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
