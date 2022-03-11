using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio2_2_Firmas.Controladores;
using System.IO;

namespace Ejercicio2_2_Firmas
{
    public partial class App : Application
    {
        static FirmasDB basedatos;


        public static FirmasDB BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new FirmasDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FirmasDB.db3"));
                }
                return basedatos;

            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
