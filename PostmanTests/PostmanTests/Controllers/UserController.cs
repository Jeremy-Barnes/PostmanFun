using Microsoft.AspNetCore.Mvc;
using PostmanTests.Entities;
using PostmanTests.Services;

namespace PostmanTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] User user)
        {
            return Ok(userService.CreateUser(user));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = userService.GetUser(id);
            if (user == null)
                return NotFound();
            else return Ok(user);
        }

        [HttpPut]
        public ActionResult Update([FromBody]User user)
        {
            return Ok(userService.UpdateUser(user));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            userService.DeleteUser(id);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult GetAll()
        {
            return Ok(userService.GetAllUsers());
        }

        
    }
}