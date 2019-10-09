using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Metodos
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static List<Estudiantes> FiltrarEstudiantes(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Estudiantes, bool>> filtro = p => true;
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();
            List<Estudiantes> list = new List<Estudiantes>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://EstudianteId
                    filtro = p => p.EstudianteId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Nombre
                    filtro = p => p.Estudiante.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 4://Puntos Perdido
                    filtro = p => p.PuntosPerdido == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Categorias> FiltrarCategorias(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Categorias, bool>> filtro = p => true;
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            List<Categorias> list = new List<Categorias>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://Id
                    filtro = p => p.CategoriaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://categoria
                    filtro = p => p.Categoria.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 4://Promedio Perdido
                    filtro = p => p.PromedioPerdido == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

    }
}
