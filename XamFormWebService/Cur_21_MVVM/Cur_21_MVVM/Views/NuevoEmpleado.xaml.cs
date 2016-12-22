using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cur_21_MVVM.ViewModels;
using Xamarin.Forms;

namespace Cur_21_MVVM.Views
{
    public partial class NuevoEmpleado : ContentPage
    {
        public NuevoEmpleado()
        {
            InitializeComponent();
        }

        public NuevoEmpleado(MainViewModel mainViewModel)  //21 - enviar parametro del item tapped aca y mantiene el mainviewmodel desde la otra vista, con un nuevo constructor
        {
            InitializeComponent();

            BindingContext = mainViewModel;
        }


    }
}
