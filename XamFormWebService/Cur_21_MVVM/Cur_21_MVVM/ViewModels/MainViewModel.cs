using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Cur_21_MVVM.Models;
using Cur_21_MVVM.Services;
using Xamarin.Forms;

namespace Cur_21_MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged // 2  - crear lista de empleados en el viewmodel (inotifychanged permite refrescar los datos cuando el cliente cambia datos desde el UI)
    {
        private List<Empleado> _listaEmpleado; //crear backfield
        private Empleado _selectedEmpleado = new Empleado(); //19 - actualizar 
        private List<Empleado> _searchedEmpleados;
        private string _nombreEmpleado;

        public List<Empleado> ListaEmpleado
        {
            get { return _listaEmpleado; }
            set
            {
                _listaEmpleado = value;
                OnPropertyChanged();
            }
        }

        public string nombreEmpleado //30 - se crea nueva propiedad string para buscar el empleado y bindearlo en el entry
        {
            get { return _nombreEmpleado; }
            set
            {
                _nombreEmpleado = value;
                OnPropertyChanged();
            }
        }


        public Command GuardarDatos //18 - se crea comando y luego actualizar empleadoservice con un nuevo metodo POST
        {
            get
            {
                return new Command(async () =>
                {
                    var empleadoservices = new EmpleadoServices();
                    await empleadoservices.PostEmpleadoAsync(_selectedEmpleado);
                });
            }
        }

        public Command BorrarDatos //22 - se crea comando y luego actualizar empleadoservice borrando al empleado con un nuevo metodo PUT
        {
            get
            {
                return new Command(async () =>
                {
                    var empleadoservices = new EmpleadoServices();
                    await empleadoservices.DeleteEmpleadoAsync(_selectedEmpleado.Id, _selectedEmpleado);
                });
            }
        }

        public Command EditarDatos //21 - se crea comando y luego actualizar empleadoservice editando al empleado con un nuevo metodo PUT
        {
            get
            {
                return new Command(async () =>
                {
                    var empleadoservices = new EmpleadoServices();
                    await empleadoservices.PutEmpleadoAsync(_selectedEmpleado.Id, _selectedEmpleado); 
                });
            }
        }

        public Command BuscarEmpleado //29 - se crea comando y luego actualizar empleadoservice editando al empleado con un nuevo metodo PUT
        {
            get
            {
                return new Command(async () =>
                {
                    var empleadoservices = new EmpleadoServices();
                    SearchedEmpleados = await empleadoservices.SearchEmpleadosAsync(_nombreEmpleado);
                });
            }
        }

        public Empleado SelectedEmpleado
        {
            get { return _selectedEmpleado; }
            set
            {
                _selectedEmpleado = value;
                OnPropertyChanged();
            }
        }

        //17 - crear una propiedad empleado seleccionado con backing field y bindearla con el entry del XML empleadonuevo

        public List<Empleado> SearchedEmpleados
        {
            get { return _searchedEmpleados; }
            set
            {
                _searchedEmpleados = value;
                OnPropertyChanged();
            }
        }//28 - crear propiedad de empleado buscado con backing field >> home.xml.cs

        public MainViewModel() // ctor = clave para crear un constructor
        {
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var empleadoservices = new EmpleadoServices();

            ListaEmpleado = await empleadoservices.GetEmpleadosAsync(); //5 - inflar la lista empleados con la lista creada en empleadoservices
        } // 13 - crear metodo async initializedatasync, porque el constructor no permite usar el async, asi que se crea un metodo y simplemente el constructor lo llama

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
