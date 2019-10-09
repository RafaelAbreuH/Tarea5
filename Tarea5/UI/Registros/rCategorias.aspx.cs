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
    public partial class rCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IdTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Categorias> Repositorio = new RepositorioBase<Categorias>();
            Categorias categoria = Repositorio.Buscar(Utils.ToInt(IdTextBox.Text));
            return (categoria != null);
        }

        private Categorias LlenaClase()
        {
            Categorias categoria = new Categorias();

            categoria.CategoriaId = Utils.ToInt(IdTextBox.Text);
            categoria.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            categoria.Categoria = CategoriaTextBox.Text;
            categoria.PromedioPerdido = Utils.ToDecimal(PromedioPerdidoTextBox.Text);

            return categoria;
        }
        private void LlenaCampo(Categorias categoria)
        {
            IdTextBox.Text = categoria.CategoriaId.ToString();
            FechaTextBox.Text = categoria.Fecha.ToString("yyyy-MM-dd");
            CategoriaTextBox.Text = categoria.Categoria;
            PromedioPerdidoTextBox.Text = categoria.PromedioPerdido.ToString();
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            CategoriaTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            PromedioPerdidoTextBox.Text = "0";
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> Repositorio = new RepositorioBase<Categorias>();

            Categorias categoria = new Categorias();

            categoria = Repositorio.Buscar(Utils.ToInt(IdTextBox.Text));

            if (categoria != null)
            {
                LlenaCampo(categoria);
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
            Categorias categoria = new Categorias();
            RepositorioBase<Categorias> Repositorio = new RepositorioBase<Categorias>();
            bool paso = false;

            categoria = LlenaClase();

            if (Utils.ToInt(IdTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(categoria);
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
                paso = Repositorio.Modificar(categoria);
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
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            int id = Utils.ToInt(IdTextBox.Text);

            var categoria = repositorio.Buscar(id);

            if (categoria != null)
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