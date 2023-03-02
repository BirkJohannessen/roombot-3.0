using context;
using Microsoft.AspNetCore.Mvc;
using models;
using response;
using requests;

namespace roombot_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase {
    public UserHelper userhelper { get ; set ; }
    private readonly ILogger<UserController> _logger;
    private readonly RoombotResponse _response;

    public UserController(ILogger<UserController> logger, RoombotContext context) {
        RoombotResponse response = new RoombotResponse();
        userhelper = new UserHelper(context, response);
        _response = response;
        _logger = logger;
    }

    /*[HttpPost]
    public String login() {
        return "login not implemented";
    }*/
    [HttpPost]
    public IActionResult registerUser(Login login) {
        try{
            RoombotResponse response = userhelper.registerUser(login._username, login._password, "cookie");
            HttpContext.Response.Headers.Add("Set-Cookie", "asdf");
            return Ok(_response);
        } catch(Exception) {
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return NotFound(_response);
        }
    }
    [HttpGet("{id}")]
    public IActionResult user(int id) {
        try{
            return Ok(userhelper.fetchUser(id, "cookie"));
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return NotFound(_response);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult deleteUser(int id) {
        try{
            return Ok(userhelper.deleteUser(id, "cookie"));
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return NotFound(_response);
        }
    }
    [HttpGet(Name = "users")]
    public IActionResult users() {
        try{
            return Ok(userhelper.fetchUsers("cookie"));
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return NotFound(_response);
        }
    }
}