using Android.Graphics;
using Ejercicio2_2_Firmas.Modelos;
using SignaturePad.Forms;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace Ejercicio2_2_Firmas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        byte[] ImageBytes;

   

    private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
             Stream Image = await PadView.GetImageStreamAsync(SignatureImageFormat.Png);

            try
            {
                //convertimos imagen a base 64
                var image = await PadView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
                var mStream = (MemoryStream)image;
                byte[] data = mStream.ToArray();
                string base64Val = Convert.ToBase64String(data);
                ImageBytes = Convert.FromBase64String(base64Val);
                

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }


            var firma = new Firmas
            {
                Nombre = nombre.Text,
                Descripcion = descripcion.Text,
                Imagen = ImageBytes

            };


            //var resultado = await App.BaseDatos.GuardarSitio(sitio);

            if (String.IsNullOrEmpty(nombre.Text) || String.IsNullOrEmpty(descripcion.Text))
            {
                await DisplayAlert("Aviso", "Favor no dejar campos vacios", "Ok");
                
            }
            else
            {
                await DisplayAlert("Aviso", "Firma Registrada con Exito!!!", "Ok");
                await App.BaseDatos.GuardarFirma(firma);
                PadView.Clear();
                nombre.Text = "";
                descripcion.Text = "";
            }
            
            await Navigation.PopAsync();
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
           PadView.Clear();
           
            nombre.Text=""; 
            descripcion.Text = "";
        }

        private async void btnListaFirma_Clicked(object sender, EventArgs e)
        {
            var firma = new Vistas.FirmasPage();
            await Navigation.PushAsync(firma);
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }

        

    }
}
