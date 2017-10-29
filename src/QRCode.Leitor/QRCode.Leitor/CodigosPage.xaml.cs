using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace QRCode.Leitor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodigosPage : ContentPage
    {
        ZXingBarcodeImageView barcode_um;
        ZXingBarcodeImageView barcode_dois;

        public CodigosPage()
        {
            InitializeComponent();
            ExibirCodigos();
        }

        private void ExibirCodigos()
        {
            barcode_um = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
                Margin = new Thickness(10)
            };

            barcode_um.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode_um.BarcodeOptions.Width = 400;
            barcode_um.BarcodeOptions.Height = 400;
            barcode_um.BarcodeOptions.Margin = 0;
            barcode_um.BarcodeValue = "https://www.youtube.com/";
            //Propaganda!
            //barcode_um.BarcodeValue = "https://www.youtube.com/ata275";

            stackPrincipal.Children.Add(barcode_um);

            barcode_dois = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
                Margin = new Thickness(10)
            };

            barcode_dois.BarcodeFormat = ZXing.BarcodeFormat.EAN_13; //formato simples de código de barras
            barcode_dois.BarcodeOptions.Width = 400;
            barcode_dois.BarcodeOptions.Height = 400;
            barcode_dois.BarcodeOptions.Margin = 0;
            barcode_dois.BarcodeValue = "1232797466045"; //código EAN_13 válido para renderizar

            stackPrincipal.Children.Add(barcode_dois);
        }
    }
}