using QRCode.Leitor.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QRCode.Leitor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private string _codigoCapturado;

        public string CodigoCapturado
        {
            get { return _codigoCapturado; }
            set
            {
                _codigoCapturado = value;
                lblCodigo.Text = _codigoCapturado;
            }

        }

        bool iniCapt = false;
        bool exibindoMsg = false;
        ZXingScannerPage scanPage = null;

        public async Task Capturar()
        {
            scanPage = await Util.CapturarQRCodeAsync(scanPage, "Escanear código", ZXing.BarcodeFormat.QR_CODE);

            if (!iniCapt)
            {
                //configura apenas uma vez o evento de capturar
                scanPage.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            //Se há alguma mensagem a exibir é interrompido a captura do QRcode
                            if (exibindoMsg)
                            {
                                return;
                            }

                            scanPage.IsScanning = false;


                            if (!string.IsNullOrEmpty(CodigoCapturado))
                            {
                                return;
                            }

                            Util.Vibrar();

                            CodigoCapturado = result.Text;
                            await Navigation.PopAsync();
                        }
                        catch (Exception ex)
                        {
                            exibindoMsg = true;
                            await this.DisplayAlert("ATENÇÃO", "Código inválido! Tente Novamente", "OK");
                            exibindoMsg = false;
                            //ñ necessario
                            //throw;
                        }
                    });
                };
                iniCapt = true;
            }

            //sem codigo
            CodigoCapturado = "";

            //Abre a tela de captura
            await Navigation.PushAsync(scanPage);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Capturar();

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CodigosPage());
        }
    }
}
