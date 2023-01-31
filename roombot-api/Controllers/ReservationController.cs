
using Microsoft.AspNetCore.Mvc;

namespace roombot_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase {
    private readonly ILogger<ReservationController> _logger;

    public ReservationController(ILogger<ReservationController> logger) {
        _logger = logger;
    }
    [HttpGet("{id}")]
    public String userReservations() {
        return "user reservations";
    }
    [HttpGet(Name = "reservations")]
    public String reservations() {
        return "all reservations";
    }
    [HttpPost]
    public String newReservation() {
        return "new reservations";
    }
    [HttpDelete("{id}")]
    public String deleteReservation() {
        return "delete reservations";
    }
}