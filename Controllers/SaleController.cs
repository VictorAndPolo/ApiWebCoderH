using Microsoft.AspNetCore.Mvc;
using ApiWebCoderH.Models;
using ApiWebCoderH.Repositories;

namespace ApiWebCoderH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<Sale>? Get(long id)
        {
            try
            {
                return Ok(RSale.SelectSale(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult<List<Sale>>? GetSales()
        {
            try
            {
                return Ok(RSale.SelectSales());
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
                int rowsAffected = RSale.DeleteSale(id);
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
        public ActionResult Post([FromBody] Sale sale)
        {
            try
            {
                int rowsAffected = RSale.InsertSale(sale);
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
        public ActionResult Put([FromBody] Sale sale)
        {
            try
            {
                int rowsAffected = RSale.UpdateSale(sale);
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
