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
    public RoombotResponse registerUser(int id) {
        try{
            return userhelper.registerUser("teh_admin", "password", "cookie");
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return _response;
        }
    }
    [HttpGet("{id}")]
    public RoombotResponse user(int id) {
        try{
            return userhelper.fetchUser(id, "cookie");
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return _response;
        }
    }
    [HttpDelete("{id}")]
    public RoombotResponse deleteUser(int id) {
        try{
            return userhelper.deleteUser(id, "cookie");
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return _response;
        }
    }
    [HttpGet(Name = "users")]
    public RoombotResponse users() {
        try{
            return userhelper.fetchUsers("cookie");
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return _response;
        }
    }
}