using System.Drawing;
using Matchplanner.Database;
using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using QRCoder;

namespace Matchplanner.WebApi.Services;

public class TicketService(IDbContextFactory<MatchplannerContext> dbFactory) : ITicketService
{
    public byte[] GenerateQrCode(
        string movieName,
        int roomNumber,
        string time,
        string rowNumber,
        int seatNumber,
        string discountCode
    ) {
        string data = $"{movieName}\nZaal: {roomNumber}\nTijd: {time}\nRij: {rowNumber}\nStoel: {seatNumber}\nKortingscode: {discountCode}";
    
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeImage = qrCode.GetGraphic(20);
        using (MemoryStream stream = new MemoryStream())
        {
            qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }
}
