using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cur_21_MVVM.Views;
using Xamarin.Forms;

namespace Cur_21_MVVM
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

            MainPage = new NavigationPage(new Home()); //15 - actualizar pagina de inicio con navigation page (evita que app crashee)
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
