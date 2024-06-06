using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Matchplanner.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet("GenerateQrCode")]
    public IActionResult GenerateQrCode(
        string movieName,
        int roomNumber,
        string time,
        string rowNumber,
        int seatNumber,
        string? discountCode
    ) {
        if (string.IsNullOrEmpty(discountCode))
        {
            discountCode = "Geen korting";
        }
        
        var qrCode = _ticketService.GenerateQrCode(movieName, roomNumber, time, rowNumber, seatNumber, discountCode);
        return File(qrCode, "image/png"); // return QR as image
    }
}
