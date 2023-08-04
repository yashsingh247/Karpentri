using Microsoft.AspNetCore.Mvc;

namespace KarpentriAPI.Controllers
{
    public class UserController : ControllerBase
    { 
            [HttpGet("api/users")]
            public JsonResult users()
            {
                return new JsonResult(
                    new List<object>
                    {
                    new {id = 1, name = "Ayush", address = "Delhi", email = "dummy@gmail.com", phone = "123456", type = "individual"},
                    new {id = 2, name = "Ankur & Co.", address = "Meerut", email = "dummy@gmail.com", phone = "123456", type = "enterprise"},
                    new {id = 3, name = "Amar", address = "Baghpat", email = "dummy@gmail.com", phone = "123456", type = "individual"}
                    }
                    );
            }
    }
}
