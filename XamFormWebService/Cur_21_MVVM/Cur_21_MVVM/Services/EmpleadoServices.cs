using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cur_21_MVVM.Models;
using Plugin.RestClient;

namespace Cur_21_MVVM.Services
{
    public class EmpleadoServices //3 - clase responsable de agregar y eliminar empleados
    {
        public async Task<List<Empleado>> GetEmpleadosAsync() //4 - crear lista y retornar datos 
            // 6 - cambiar esta lista statica por una de la base de datos, creando un nuevo proyecto WEB asp.net > web api > no authentification
            // 12 - cambiar la lista estatica por lista dinamica desde la RestClient
        {
            RestClient<Empleado> restClient = new RestClient<Empleado>();

            var listaEmpleados = await restClient.GetAsync();

            return listaEmpleados;
        }

        public async Task PostEmpleadoAsync(Empleado empleado) //19 - crear empleado con metodo postasync
        {
            RestClient<Empleado> restClient = new RestClient<Empleado>();

            var listaEmpleados = await restClient.PostAsync(empleado);

            
        }

        internal async Task PutEmpleadoAsync(int id, Empleado empleado) //20 - crear empleado con metodo putasync debuggear siempre es coooool
        {
            RestClient<Empleado> restClient = new RestClient<Empleado>();

            var listaEmpleados = await restClient.PutAsync(id, empleado);
        }

        internal async Task DeleteEmpleadoAsync(int id, Empleado empleado) //24 - crear empleado con metodo deleteasync debuggear siempre es coooool
        {
            RestClient<Empleado> restClient = new RestClient<Empleado>();

            var listaEmpleados = await restClient.DeleteAsync(id, empleado);
        }

        public async Task<List<Empleado>> SearchEmpleadosAsync(string nombre)  //26 - crear metodo buscar empleado que acepte un parametro string para la busqueda  >> restclient
        {
            RestClient<Empleado> restClient = new RestClient<Empleado>();

            var listaEmpleados = await restClient.SearchAsync(nombre);

            return listaEmpleados;
        }
    }
}

//var lista = new List<Empleado>
//            {
//                new Empleado
//                {
//                    Name = "Mustafa",
//                    Department = "Technology"

//                },
//                new Empleado
//                {
//                    Name = "Mustafita",
//                    Department = "RRHH"

//                },
//                new Empleado
//                {
//                    Name = "Jack",
//                    Department = "RRHH"

//                },
//                new Empleado
//                {
//                    Name = "Linda",
//                    Department = "Operations"

//                },
//                new Empleado
//                {
//                    Name = "Butcher",
//                    Department = "Ventas"

//                },
//                new Empleado
//                {
//                    Name = "Camila",
//                    Department = "Ventas"

//                }

//            };