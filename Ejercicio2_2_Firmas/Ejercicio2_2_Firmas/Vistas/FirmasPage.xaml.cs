using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Ejercicio2_2_Firmas.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_2_Firmas.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirmasPage : ContentPage
    {
        Firmas users = new Firmas();
        public FirmasPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //ListaPersonas.ItemsSource = await App.BaseDatos.listapersonas();

            var listaFirmas = await App.BaseDatos.ListaFirmas();
            //Creamos un colleccion observable para que los cambios que se realizan en el modelo se reflejen de maner automatica
            //en la vista
            ObservableCollection<Firmas> observableCollectionFotos = new ObservableCollection<Firmas>();
            listafirmas.ItemsSource = observableCollectionFotos;
            foreach (Firmas imagen in listaFirmas)
            {
                observableCollectionFotos.Add(imagen);
            }


        }

        private async void listafirmas_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            try
            {
                //await DisplayAlert("Aviso", "Has dado clik en una persona!!!", "Ok");
                Modelos.Firmas item = (Modelos.Firmas)e.Item;
                var newpage = new Vistas.UpdateFirma();
                newpage.BindingContext = item;
                await Navigation.PushAsync(newpage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }


    }
}