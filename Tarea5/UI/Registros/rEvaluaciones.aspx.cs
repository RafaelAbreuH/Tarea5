using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tarea5.UI.Registros
{
    public partial class Evaluaciones : System.Web.UI.Page
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
                detalleGridView.DataSource = (EvaluacionesDetalle)ViewState["Evaluacion"];
                detalleGridView.DataBind();
            }
        }


        protected void detalleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void detalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {

        }


        protected void nuevoButton_Click(object sender, EventArgs e)
        {

        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {

        }

        protected void eliminarutton_Click(object sender, EventArgs e)
        {

        }

        protected void agregarLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}