using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Clases.Login;

namespace ProyectoReinaMadre
{
    public partial class Departamentos : System.Web.UI.Page
    {
        private ClaseDepartamentos objetoDepartamento = new ClaseDepartamentos();
        private string scriptMensaje = "";

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtDep.Focus();
            }
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
           
        }

        protected void grvVerDep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvVerDep.PageIndex = e.NewPageIndex;
            CargarDepartamentos();
        }

        protected void grvVerDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["idDepartamento"] = grvVerDep.Rows[grvVerDep.SelectedIndex].Cells[1].Text;
            CargarDepartamento();
        }

        protected void cmdGra_Click(object sender, EventArgs e)
        {
            if (ValidarAlta())
            {
                if (ViewState["idDepartamento"] == null || Convert.ToInt32(ViewState["idDepartamento"]) <= 0)
                {
                    AltaDepartamento();
                }
                else
                {
                    ModificarDepartamento();
                }
            }
        }

        protected void cmdSta_Click(object sender, EventArgs e)
        {
            if (ViewState["idDepartamento"] != null || Convert.ToInt32(ViewState["idDepartamento"]) > 0)
            {
                CambiarStatus();
            }
        }

        protected void cmdLim_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void cmdCar_Click(object sender, EventArgs e)
        {
            CargarDepartamentos();
        }
        #endregion

        #region Metodos

        private void Mensaje(string _mensaje, bool? _error)
        {
            string scriptMensaje = "";
            if (_error == true)
            {
                scriptMensaje = "alertify.error('" + _mensaje + "');";
            }
            else if (_error == false)
            {
                scriptMensaje = "alertify.success('" + _mensaje + "');";
            }
            else if (_error == null)
            {
                scriptMensaje = "alertify.custom = alertify.extend('custom'); alertify.custom('" + _mensaje + "');";
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptMensaje, true);
        }
        private void Limpiar()
        {
            ViewState["idDepartamento"] = null;
            ViewState["departamento"] = null;
            txtDep.Text = "";
            txtUbi.Text = "";
            grvVerDep.DataSource = null;
            grvVerDep.DataBind();
            lblInfo.Visible = false;
            txtDep.Focus();
        }

        private bool ValidarAlta()
        {
            if (txtDep.Text.Trim() == "")
            {
                Mensaje("Ingrese el departamento a dar de alta.", null);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void AltaDepartamento()
        {
            if (objetoDepartamento.ExisteDepartamento(txtDep.Text.Trim()))
            {
                Mensaje("El departamento que ingreso ya existe.", true);
                txtDep.Text = "";
                txtDep.Focus();
                return;
            }
            if (objetoDepartamento.AltaDepartamento(txtDep.Text.Trim(), txtUbi.Text.Trim(), ddlEmp.SelectedValue == "-seleccione-" ? -1 :Convert.ToInt32( ddlEmp.SelectedItem.Text)))
            {

                Limpiar();
                Mensaje("Se dio de alta el departamento.", false);
            }
            else
            {
                Mensaje("Error al dar de alta el departamento, intente de nuevo.", true);
            }
        }

        private void ModificarDepartamento()
        {
            //if (objetoDepartamento.ExisteDepartamento(txtDep.Text.Trim()))
            //{
            //    lblInfo.Text = "El departamento que ingreso ya existe.";
            //    lblInfo.ForeColor = Color.Blue;
            //    lblInfo.Visible = true;
            //    txtDep.Text = ViewState["departamento"].ToString();
            //    txtDep.Focus();
            //    return;
            //}
            if (objetoDepartamento.ModificarDepartamento(Convert.ToInt32(ViewState["idDepartamento"]), txtDep.Text.Trim(), txtUbi.Text.Trim()))
            {
                Limpiar();
                Mensaje("Se modifico el departamento.", false);
            }
            else
            {
                Mensaje("Error al modificar el departamento, intente de nuevo.", true);
            }
        }

        private void CambiarStatus()
        {
            objetoDepartamento = new ClaseDepartamentos(Convert.ToInt32(ViewState["idDepartamento"]));
            if (objetoDepartamento.Status == true)
            {
                if (objetoDepartamento.DesactivarDepartamento(Convert.ToInt32(ViewState["idDepartamento"])))
                {
                    Limpiar();
                    Mensaje("Se cammbio de estado al departamento.", false);
                }
                else
                {
                    Mensaje("Error al cambiar de estado al departamento, intente de nuevo.", true);
                }
            }
            else if (objetoDepartamento.Status == false)
            {
                if (objetoDepartamento.ActivarDepartamento(Convert.ToInt32(ViewState["idDepartamento"])))
                {
                    Limpiar();
                    Mensaje("Se cammbio de estado al departamento.", false);
                }
                else
                {
                    Mensaje("Error al cambiar de estado al departamento, intente de nuevo.", true);
                }
            }
            else
            {
                Mensaje("Error al cargar el departamento, pongase en contacto con el administrador del sistema.", true);
            }
        }

        private void CargarDepartamentos()
        {
            grvVerDep.DataSource = objetoDepartamento.CargarDepartamentos();
            grvVerDep.DataBind();
        }

        private void CargarDepartamento()
        {
            objetoDepartamento = new ClaseDepartamentos(Convert.ToInt32(ViewState["idDepartamento"]));
            ViewState["idDepartamento"] = objetoDepartamento.IdDepartamento;
            ViewState["departamento"] = objetoDepartamento.Departamento;
            txtDep.Text = objetoDepartamento.Departamento;
            txtUbi.Text = objetoDepartamento.Ubicacion;
        }


        #endregion
    }
}