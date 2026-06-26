namespace WarehouseManagementApp.Services   
{
using QRCoder;
    public class QrCodeService
    {
        public string GenerateQrCode(string text)
        {
            using QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            using QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageString = qrCode.GetGraphic(20, "#000000", "#FFFFFF");
            return $"data:image/png;base64,{qrCodeImageString}";
        }
    }
}
