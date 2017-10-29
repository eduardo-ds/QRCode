using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

namespace QRCode.Leitor.Helpers
{
    public class Util
    {
        public static void Vibrar()
        {
            try
            {
                var device = CrossVibrate.Current;
                device.Vibration();
            }
            catch { }
            //catch (Exception ex) { throw ex; }

        }

        public async static Task<ZXingScannerPage> CapturarQRCodeAsync(ZXingScannerPage scanPage, string titulo, ZXing.BarcodeFormat barcodeFormat)
        {
            if (scanPage == null)
            {
                var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
                options.PossibleFormats = new List<ZXing.BarcodeFormat>() { barcodeFormat };

#if __ANDROID__
                                    //para codigo espeficifico do Android
                                    //Initialize the scanner first so it can track the current context
                                    MobileBarcodeScanner.Initialize(Application);
#endif

                scanPage = new ZXingScannerPage(options);
                scanPage.IsScanning = true;

            }

            scanPage.Title = titulo;
            return scanPage;
        }

    }
}
