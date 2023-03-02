using context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using response;

namespace roombot_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase {
    private readonly ILogger<ReservationController> _logger;
    private readonly RoombotResponse _response;
    public ReservationHelper reservationhelper { get ; set ; }
    public ReservationController(ILogger<ReservationController> logger, RoombotContext context) {
        RoombotResponse response = new RoombotResponse();
        reservationhelper = new ReservationHelper(context, response);
        _logger = logger;
        _response = response;
    }
    [HttpGet]
    public IActionResult userReservations() {
        try{
            return Ok(reservationhelper.fetchUserReservations(""));
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return NotFound(_response);
        }
    }
    /*[HttpGet(Name = "reservations")]
    public RoombotResponse reservations() {
        return reservationhelper.fetchReservations("cookie");
    }*/
    [HttpPost]
    public IActionResult newReservation() {
        try{
            return Ok(reservationhelper.newReservation("cookie"));
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return NotFound(_response);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult deleteReservation(int resID) {
        try{
            return Ok(reservationhelper.deleteReservation(resID, "cookie"));
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return NotFound(_response);
        }
    }
}