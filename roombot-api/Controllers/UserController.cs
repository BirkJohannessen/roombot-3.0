using Microsoft.AspNetCore.Mvc;

namespace roombot_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase {
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger) {
        _logger = logger;
    }

    [HttpPost]
    public String login() {
        return "login";
    }
    [HttpPost]
    public String registerUser(int id) {
        return "register"+id;
    }
    [HttpGet("{id}")]
    public String user(int id) {
        return "user"+id;
    }
    [HttpDelete("{id}")]
    public String deleteUser(int id) {
        return "register"+id;
    }
    [HttpGet(Name = "users")]
    public String users() {
        return "users list";
    }
}