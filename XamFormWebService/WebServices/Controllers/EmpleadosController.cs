using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cur_21_MVVM.Models;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class EmpleadosController : ApiController
    {
        private EmpleadosContext db = new EmpleadosContext();

        // GET: api/Empleados
        public IQueryable<Empleado> GetEmpleadoes()
        {
            return db.Empleadoes;
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult GetEmpleado(int id)
        {
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        // PUT: api/Empleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleado(int id, Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleado.Id)
            {
                return BadRequest();
            }

            db.Entry(empleado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleados
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult PostEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleadoes.Add(empleado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleado.Id }, empleado);
        }

        // DELETE: api/Empleados/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult DeleteEmpleado(int id)
        {
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            db.Empleadoes.Remove(empleado);
            db.SaveChanges();

            return Ok(empleado);
        }

        // GET: api/Empleados/5
        [Route("api/Empleados/Search/{nombre}")] //25 - redireccionar la URL de esta funcion y agregarle el parametro
        [ResponseType(typeof(List<Empleado>))] //24 - crear funcion en el controlador para buscar un empleado por su nombre
        public IHttpActionResult GetEmpleado(string nombre) //modificar parametro a string
        {
            List<Empleado> empleado = db.Empleadoes.Where(e => e.Name.Contains(nombre)).ToList(); //modificar busqueda del linQ
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadoExists(int id)
        {
            return db.Empleadoes.Count(e => e.Id == id) > 0;
        }
    }
}