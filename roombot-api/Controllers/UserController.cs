using context;
using Microsoft.AspNetCore.Mvc;
using models;
using response;

namespace roombot_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase {
    public UserHelper userhelper { get ; set ; }
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, RoombotContext context) {
        RoombotResponse response = new RoombotResponse();
        userhelper = new UserHelper(context, response);
        _logger = logger;
    }

    /*[HttpPost]
    public String login() {
        return "login not implemented";
    }*/
    [HttpPost]
    public RoombotResponse registerUser(int id) {
        return userhelper.registerUser("username", "password", "coookie");
    }
    [HttpGet("{id}")]
    public RoombotResponse user(int id) {
        return userhelper.fetchUser(id, "cookie");
    }
    [HttpDelete("{id}")]
    public RoombotResponse deleteUser(int id) {
        return userhelper.deleteUser(id, "cookiw");
    }
    [HttpGet(Name = "users")]
    public RoombotResponse users() {
        return userhelper.fetchUsers("cookie");
    }
}