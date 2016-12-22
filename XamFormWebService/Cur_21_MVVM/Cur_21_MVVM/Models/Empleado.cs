using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cur_21_MVVM.Models
{
    public class Empleado //1 - crear carpetas model, viewmodel, views y crear las clases correspondientes por model y viewmodel // 7 - cópiar y pegar en models de webservice 
    {
        public int Id { get; set; } //22 - agregar el id a la clase empleado de la version portable
        public string Name { get; set; }
        public string Department { get; set; }
    }

    // 8 - crear la BDD: ir al empleado del webservice
    // 10 - proyecto portable > manage nuget packages - instalar plugin.restclient - newtonjsoft = transformar datos json en objetos .net
}
