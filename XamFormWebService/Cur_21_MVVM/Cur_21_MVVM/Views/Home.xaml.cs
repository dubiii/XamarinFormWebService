using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cur_21_MVVM.Models;
using Cur_21_MVVM.ViewModels;
using Xamarin.Forms;

namespace Cur_21_MVVM.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            // BindingContext = new MainViewModel();
        }


        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoEmpleado());
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e) // 20 - crear Id y itemtapped a listview de empleados del home, bindearlo con selected empleado del mainviewmodel
        {
            var empleado = ListviewEmpleados.SelectedItem as Empleado;

            if (empleado != null)
            {
                var mainViewModel = BindingContext as MainViewModel;

                if (mainViewModel != null)
                {
                    mainViewModel.SelectedEmpleado = empleado;
                    await Navigation.PushAsync(new NuevoEmpleado(mainViewModel));
                }
            }
        }

        private async void Button_OnClicked_2(object sender, EventArgs e)// 29 - crear metodo para ir a la pagina de busqueda >> Search.xml >> Mainviewmodel
        {
            var mainViewModel = BindingContext as MainViewModel;

            if (mainViewModel != null)
            {
                await Navigation.PushAsync(new Search(mainViewModel));
            }
        }
    }
}
