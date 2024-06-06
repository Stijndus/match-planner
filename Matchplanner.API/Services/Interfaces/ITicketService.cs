namespace Matchplanner.WebApi.Services.Interfaces;

public interface ITicketService
{
    byte[] GenerateQrCode(
        string movieName,
        int roomNumber,
        string time,
        string rowNumber,
        int seatNumber,
        string discountCode
    );
}
