using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EvaluacionBLL
    {
        public static bool Guardar(Evaluaciones i)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                RepositorioBase<Estudiantes> estudiante = new RepositorioBase<Estudiantes>();
                //  RepositorioBase<Categorias> cat = new RepositorioBase<Categorias>();


                if (db.Evaluacion.Add(i) != null)
                {
                    var id = estudiante.Buscar(i.EstudianteId);

                    id.PuntosPerdido = id.PuntosPerdido + i.TotalPerdido;


                    estudiante.Modificar(id);

                    paso = db.SaveChanges() > 0;

                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        public static bool Modificar(Evaluaciones entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Estudiantes> est = new RepositorioBase<Estudiantes>();
            RepositorioBase<Evaluaciones> entr = new RepositorioBase<Evaluaciones>();

            try
            {

                var anterior = entr.Buscar(entrada.EvaluacionId);
                var producto = est.Buscar(entrada.EstudianteId);

                producto.PuntosPerdido = producto.PuntosPerdido + (entrada.TotalPerdido - anterior.TotalPerdido);
                est.Modificar(producto);


                db.Entry(entrada).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Estudiantes> est = new RepositorioBase<Estudiantes>();
            RepositorioBase<Evaluaciones> entr = new RepositorioBase<Evaluaciones>();



            try
            {

                var entrada = entr.Buscar(id);
                var ids = est.Buscar(entrada.EstudianteId);

                ids.PuntosPerdido = ids.PuntosPerdido - entrada.TotalPerdido;
                est.Modificar(ids);

                db.Entry(entrada).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

    }
}