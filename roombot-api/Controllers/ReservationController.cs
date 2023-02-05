using context;
using Microsoft.AspNetCore.Mvc;

namespace roombot_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase {
    private readonly ILogger<ReservationController> _logger;
    public ReservationHelper reservationhelper { get ; set ; }
    public ReservationController(ILogger<ReservationController> logger, RoombotContext context) {
        reservationhelper = new ReservationHelper(context);
        _logger = logger;
    }
    [HttpGet("{id}")]
    public String userReservations(int resID) {
        return reservationhelper.fetchUserReservations(resID, "cookie", 132);
    }
    [HttpGet(Name = "reservations")]
    public String reservations() {
        return reservationhelper.fetchReservations("cookie");
    }
    [HttpPost]
    public String newReservation() {
        return reservationhelper.newReservation(123, "cookie");
    }
    [HttpDelete("{id}")]
    public String deleteReservation(int resID) {
        return reservationhelper.deleteReservation(resID, "cookie");
    }
}