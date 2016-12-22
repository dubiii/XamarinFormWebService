using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cur_21_MVVM.Models
{
    public class Empleado //1 - crear carpetas model, viewmodel, views y crear las clases correspondientes por model y viewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; } // 9 - desde aca crear nuevo controlador
    }
}

// debe ser WebAPI con acciones usando EF > model class: Eempleado > Data Context: EmpleadoContext > Controlador: EmpleadosController
// Luego agregar otro controlador MVC5 con vistas usando EF Model class: Empleado > DataContext EmpleadoContext > Controlador EmpleadosMVCController
