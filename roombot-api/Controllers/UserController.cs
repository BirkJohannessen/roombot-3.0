using context;
using Microsoft.AspNetCore.Mvc;

namespace roombot_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase {
    public UserHelper userhelper { get ; set ; }
    private readonly ILogger<UserController> _logger;

    private readonly RoombotContext _context;
    public UserController(ILogger<UserController> logger, RoombotContext context) {
        userhelper = new UserHelper();
        _logger = logger;
        _context=context;
    }

    /*[HttpPost]
    public String login() {
        return "login not implemented";
    }*/
    [HttpPost]
    public String registerUser(int id) {
        return userhelper.registerUser("username", "password", "coookie", _context);
    }
    [HttpGet("{id}")]
    public String user(int id) {
        return userhelper.fetchUser(id, "cookie", _context);
    }
    [HttpDelete("{id}")]
    public String deleteUser(int id) {
        return "delete not implemented";
    }
    [HttpGet(Name = "users")]
    public String users() {
        return userhelper.fetchUsers("cookie", _context);
    }
}