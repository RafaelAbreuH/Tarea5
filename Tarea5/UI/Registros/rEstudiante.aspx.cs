using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tarea5.Utilitarios;

namespace Tarea5.UI.Registros
{
    public partial class rEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IdTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void LlenaCampo(Estudiantes estudiante)
        {
            IdTextBox.Text = estudiante.EstudianteId.ToString();
            FechaTextBox.Text = estudiante.Fecha.ToString("yyyy-MM-dd");
            EstudianteTextBox.Text = estudiante.Estudiante;
            PuntosPerdidosTextBox.Text = estudiante.PuntosPerdido.ToString();
        }

        private Estudiantes LlenaClase()
        {
            Estudiantes estudiantes = new Estudiantes();

            estudiantes.EstudianteId = Utils.ToInt(IdTextBox.Text);
            estudiantes.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            estudiantes.Estudiante = EstudianteTextBox.Text;
            estudiantes.PuntosPerdido = Utils.ToDecimal(PuntosPerdidosTextBox.Text);

            return estudiantes;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Estudiantes> Repositorio = new RepositorioBase<Estudiantes>();
            Estudiantes estudiante = Repositorio.Buscar(Utils.ToInt(IdTextBox.Text));
            return (estudiante != null);
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            EstudianteTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            PuntosPerdidosTextBox.Text = "";
        }


        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> Repositorio = new RepositorioBase<Estudiantes>();

            Estudiantes estudiante = new Estudiantes();

            estudiante = Repositorio.Buscar(Utils.ToInt(IdTextBox.Text));

            if (estudiante != null)
            {
                LlenaCampo(estudiante);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            Estudiantes estudiante = new Estudiantes();
            RepositorioBase<Estudiantes> Repositorio = new RepositorioBase<Estudiantes>();
            bool paso = false;

            estudiante = LlenaClase();

            if (Utils.ToInt(IdTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(estudiante);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    Utils.ShowToastr(this, "Id no existe", "Error", "error");
                    return;
                }
                paso = Repositorio.Modificar(estudiante);
                Utils.ShowToastr(this, "Modificado", "Exito", "success");
            }

            if (paso)
            {
                Limpiar();
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
        }
    

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>();
            int id = Utils.ToInt(IdTextBox.Text);

            var estudiante = repositorio.Buscar(id);

            if (estudiante != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }
    }
}