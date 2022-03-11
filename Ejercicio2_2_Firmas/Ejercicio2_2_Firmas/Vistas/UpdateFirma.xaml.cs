using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ejercicio2_2_Firmas.Modelos;
using SignaturePad.Forms;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_2_Firmas.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateFirma : ContentPage
    {
        CancellationTokenSource cts;
        public UpdateFirma()
        {
            InitializeComponent();
        }

        byte[] ImageBytes;

        private async void btnActualizar_Clicked(object sender, EventArgs e)
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

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var firma = await App.BaseDatos.BuscarFirma(Convert.ToInt32(id.Text));

            if (firma != null)
            {
                await App.BaseDatos.EliminarFirma(firma);
                await DisplayAlert("Aviso", "Firma Eliminada con Exito!!!", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
            }

            await Navigation.PopAsync();
        }


    }
}