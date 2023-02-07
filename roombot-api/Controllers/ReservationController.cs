using context;
using Microsoft.AspNetCore.Mvc;
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
    public RoombotResponse userReservations() {
        try{
            return reservationhelper.fetchUserReservations("cookie");
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return _response;
        }
    }
    /*[HttpGet(Name = "reservations")]
    public RoombotResponse reservations() {
        return reservationhelper.fetchReservations("cookie");
    }*/
    [HttpPost]
    public RoombotResponse newReservation() {
        try{
            return reservationhelper.newReservation("cookie");
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return _response;
        }
    }
    [HttpDelete("{id}")]
    public RoombotResponse deleteReservation(int resID) {
        try{
            return reservationhelper.deleteReservation(resID, "cookie");
        }catch(Exception){
            _response.error = "unhandled exception.";
            _response.data = null;
            _response.status = Status.Failed;
            return _response;
        }
    }
}