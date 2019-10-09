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
    public partial class rEvaluaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaCombo();
                ViewState["Evaluacion"] = new Evaluaciones();
                BindGrid();
            }
        }

        private void LlenaCombo()
        {
            RepositorioBase<Categorias> c = new RepositorioBase<Categorias>();
            RepositorioBase<Estudiantes> e = new RepositorioBase<Estudiantes>();

            CategoriaDropDownList.DataSource = c.GetList(t => true);
            CategoriaDropDownList.DataValueField = "CategoriaId";
            CategoriaDropDownList.DataTextField = "Categoria";
            CategoriaDropDownList.DataBind();

            EstudianteDropDownList.DataSource = e.GetList(t => true);
            EstudianteDropDownList.DataValueField = "EstudianteId";
            EstudianteDropDownList.DataTextField = "Estudiante";
            EstudianteDropDownList.DataBind();

        }
        protected void BindGrid()
        {
            if (ViewState["Evaluacion"] != null)
            {
                detalleGridView.DataSource = ((Evaluaciones)ViewState["Evaluacion"]).Detalle;
                detalleGridView.DataBind();
            }
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Evaluaciones> Repositorio = new RepositorioBase<Evaluaciones>();
            Evaluaciones e = Repositorio.Buscar(Utils.ToInt(IdTextBox.Text));
            return (e != null);
        }
        private Evaluaciones LlenaClase()
        {
            Evaluaciones e = new Evaluaciones();
            e = (Evaluaciones)ViewState["Evaluacion"];
            e.EvaluacionId = Utils.ToInt(IdTextBox.Text);
            e.EstudianteId = Utils.ToInt(EstudianteDropDownList.SelectedValue);
            e.CategoriaId = Utils.ToInt(CategoriaDropDownList.SelectedValue);
            e.TotalPerdido = Utils.ToDecimal(TotalPerdidoTextBox.Text);
            e.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return e;
        }
        private void LlenaCampo(Evaluaciones e)
        {
            ((Evaluaciones)ViewState["Evaluacion"]).Detalle = e.Detalle;
            IdTextBox.Text = e.EvaluacionId.ToString();
            FechaTextBox.Text = e.Fecha.ToString("yyyy-MM-dd");
            EstudianteDropDownList.SelectedValue = e.EstudianteId.ToString();
            CategoriaDropDownList.SelectedValue = e.CategoriaId.ToString();
            TotalPerdidoTextBox.Text = e.TotalPerdido.ToString();
            this.BindGrid();
        }


        protected void detalleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void detalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Evaluaciones> Repositorio = new RepositorioBase<Evaluaciones>();

            Evaluaciones evaluaciones = new Evaluaciones();

            evaluaciones = Repositorio.Buscar(Utils.ToInt(IdTextBox.Text));

            if (evaluaciones != null)
            {
                LlenaCampo(evaluaciones);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Response.Redirect(Request.RawUrl);
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }


        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            Evaluaciones E = new Evaluaciones();
            bool paso = false;

            E = LlenaClase();

            if (Utils.ToInt(IdTextBox.Text) == 0)
            {
                paso = BLL.EvaluacionBLL.Guardar(E);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    return;
                }
                paso = BLL.EvaluacionBLL.Modificar(E);
                Response.Redirect(Request.RawUrl);
            }

            if (paso)
            {
                Utils.ShowToastr(this, "Modificado", "Exito", "success");
                return;
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
        }

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Evaluaciones> repositorio = new RepositorioBase<Evaluaciones>();
            int id = Utils.ToInt(IdTextBox.Text);

            var evaluaciones = repositorio.Buscar(id);

            if (evaluaciones != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Response.Redirect(Request.RawUrl);
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }

        protected void agregarLinkButton_Click(object sender, EventArgs e)
        {
            Evaluaciones ex = new Evaluaciones();

            ex = (Evaluaciones)ViewState["Evaluacion"];

            decimal Perdido = Utils.ToDecimal(ValorTextBox.Text) - Utils.ToDecimal(LogradoTextBox.Text);
            ex.Detalle.Add(new EvaluacionesDetalle(Utils.ToInt(CategoriaDropDownList.SelectedValue),
                Utils.ToDecimal(ValorTextBox.Text),
                Utils.ToDecimal(LogradoTextBox.Text),
                Perdido));

            ViewState["Detalle"] = ex.Detalle;

            this.BindGrid();
         
            decimal Total = 0;
            foreach (var item in ex.Detalle.ToList())
            {
                Total += item.Perdido;
            }
            TotalPerdidoTextBox.Text = Total.ToString();
        }


        protected void detalleGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Evaluaciones ex = new Evaluaciones();

            ex = (Evaluaciones)ViewState["Evaluacion"];

            ViewState["Detalle"] = ex.Detalle;

            int Fila = e.RowIndex;

            ex.Detalle.RemoveAt(Fila);

            this.BindGrid();

            decimal Total = 0;
            foreach (var item in ex.Detalle.ToList())
            {
                Total += item.Perdido;
            }
            TotalPerdidoTextBox.Text = Total.ToString();
        }
    }
}