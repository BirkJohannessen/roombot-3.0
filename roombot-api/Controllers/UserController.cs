using Microsoft.AspNetCore.Mvc;

namespace roombot_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase {
    public UserHelper userhelper { get ; set ; }
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger) {
        _logger = logger;
        userhelper = new UserHelper();
    }

    /*[HttpPost]
    public String login() {
        return "login not implemented";
    }*/
    [HttpPost]
    public String registerUser(int id) {
        return userhelper.registerUser("username", "password", "coookie");
    }
    [HttpGet("{id}")]
    public String user(int id) {
        return userhelper.fetchUser(id, "cookie");
    }
    [HttpDelete("{id}")]
    public String deleteUser(int id) {
        return "delete not implemented";
    }
    [HttpGet(Name = "users")]
    public String users() {
        return userhelper.fetchUsers("cookie");
    }
}