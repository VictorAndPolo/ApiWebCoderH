using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ApiWebCoderH.Models;
using ApiWebCoderH.Repositories;

namespace ApiWebCoderH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet("LogIn")]
        public ActionResult<User>? Get([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                return Ok(RUser.LogIn(username, password));
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} User and password not found.");
            }
        }

        [HttpGet("{username}")]
        public ActionResult<User>? GetUserName(string username)
        {
            try
            {
                return Ok(RUser.SelectUsername(username));
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} User and password not found.");
            }
        }

        /*[HttpGet("{id}")]
        public ActionResult<User>? GetId(long id)
        {
            try
            {
                return Ok(ADO_User.SelectUser(id));
            }
            catch (Exception ex) {
                return Problem(ex.Message);
            }  
        }*/

        [HttpGet]
        public ActionResult<List<User>>? Get()
        {
            try
            {
                return Ok(RUser.SelectUsers());
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
                int rowsAffected = RUser.DeleteUser(id);
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
        public ActionResult Post([FromBody] User user)
        {
            try
            {
                int rowsAffected = RUser.InsertUser(user);
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
        public ActionResult Put([FromBody] User user)
        {
            try
            {
                int rowsAffected = RUser.UpdateUser(user);
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
