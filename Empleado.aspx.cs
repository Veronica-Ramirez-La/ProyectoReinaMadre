using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Clases.Utils;
using Negocio.Clases.Login;

namespace ProyectoReinaMadre
{
    public partial class Empleado : System.Web.UI.Page
    {
        private ClaseEmpleado objetoEmpleado = new ClaseEmpleado();
        private string scriptMensaje = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtNom.Focus();
            }
        }

        protected void cmdGra_Click(object sender, EventArgs e)
        {
            if (ValidarAlta())
            {
                if (ViewState["idEmpleado"] == null || Convert.ToInt32(ViewState["idEmpleado"]) <= 0)
                {
                    AltaEmpleado();
                }
                else
                {
                    ModificarEmpleado();
                }
            }
        }

        protected void cmdSta_Click(object sender, EventArgs e)
        {
            if (ViewState["idEmpleado"] != null || Convert.ToInt32(ViewState["idEmpleado"]) > 0)
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
            CargarEmpleado();
        }


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
            ViewState["idEmpleado"] = null;
            txtNom.Text = "";
            txtApePat.Text = "";
            txtApeMat.Text = "";
            txtCorEle.Text = "";
            txtTelefono.Text = "";
            txtCel.Text = "";
            ddlGen.SelectedIndex = 0;

            grvVerEmp.DataSource = null;
            grvVerEmp.DataBind();
            lblInfo.Visible = false;
            txtNom.Focus();
        }

        private bool ValidarAlta()
        {
            if (txtNom.Text.Trim() == "")
            {
                Mensaje("Ingrese el nombre del empleado a dar de alta.", null);
                return false;
            }
            else if (txtApePat.Text.Trim() == "")
            {
                Mensaje("Ingrese el apellido paterno del empleado a dar de alta.", null);
                return false;
            }
            else if (txtApeMat.Text.Trim() == "")
            {
                Mensaje("Ingrese el apellido materno del empleado a dar de alta.", null);
                return false;
            }
            else if (txtCorEle.Text.Trim() != "" && MetodosGenerales.ValidarMailWeb(txtCorEle) == false)
            {
                Mensaje("Revise el mail del empleado", true);
                return false;
            }           
            else
            {
                return true;
            }
        }

        private void AltaEmpleado()
        {
            if (objetoEmpleado.ExisteEmpleado(txtNom.Text.Trim(), txtApePat.Text.Trim(), txtApeMat.Text.Trim()))
            {
                Mensaje("El empleado que ingreso ya existe.", true);
                txtNom.Focus();
                return;
            }
            int _idEmpleado = objetoEmpleado.AltaEmpleado(txtNom.Text.Trim(), txtApePat.Text.Trim(), txtApeMat.Text.Trim(), txtCorEle.Text.Trim(),
                ddlGen.SelectedValue == "-seleccione-" ? "" : ddlGen.SelectedItem.Text, txtTelefono.Text.Trim(), txtCel.Text.Trim(), Convert.ToDateTime(txtFecNac.Text), Convert.ToDateTime(txtFecIni.Text));
            
            if(_idEmpleado > 0)
            {
                Limpiar();
                Mensaje("Se dio de alta el empleado, con numero de empleado " + _idEmpleado , false);
            }
            else
            {
                Mensaje("Error al dar de alta el empleado, intente de nuevo.", true);
            }
        }

        private void ModificarEmpleado()
        {
           
            if (objetoEmpleado.ModificaEmpleado(Convert.ToInt32(ViewState["idEmpleado"]), txtNom.Text.Trim(), txtApePat.Text.Trim(), txtApeMat.Text.Trim(), txtCorEle.Text.Trim(),
                ddlGen.SelectedValue == "-seleccione-" ? "" : ddlGen.SelectedItem.Text, txtTelefono.Text.Trim(), txtCel.Text.Trim(), Convert.ToDateTime(txtFecNac.Text) )        )
            {
                Limpiar();
                Mensaje("Se modifico el empleado.", false);
            }
            else
            {
                Mensaje("Error al modificar el empleado, intente de nuevo.", true);
            }
        }

        private void CambiarStatus()
        {
            objetoEmpleado = new ClaseEmpleado(Convert.ToInt32(ViewState["idEmpleado"]));
            if (objetoEmpleado.Status == true)
            {
                if (objetoEmpleado.DesactivarEmpleado(Convert.ToInt32(ViewState["idEmpleado"])))
                {
                    Limpiar();
                    Mensaje("Se cammbio de estado al empleado.", false);
                }
                else
                {
                    Mensaje("Error al cambiar de estado al empleado, intente de nuevo.", true);
                }
            }
            else if (objetoEmpleado.Status == false)
            {
                if (objetoEmpleado.ActivarEmpleado(Convert.ToInt32(ViewState["idEmpleado"])))
                {
                    Limpiar();
                    Mensaje("Se cammbio de estado al empleado.", false);
                }
                else
                {
                    Mensaje("Error al cambiar de estado al empleado, intente de nuevo.", true);
                }
            }
            else
            {
                Mensaje("Error al cargar el empleado, pongase en contacto con el administrador del sistema.", true);
            }
        }

        protected void grvVerEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvVerEmp.PageIndex = e.NewPageIndex;
            CargarEmpleados();
        }

        protected void grvVerEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["idEmpleado"] = grvVerEmp.Rows[grvVerEmp.SelectedIndex].Cells[1].Text;
            CargarEmpleados();
        }

        private void CargarEmpleado()
        {
            grvVerEmp.DataSource = objetoEmpleado.CargarEmpleados();
            grvVerEmp.DataBind();
        }

        private void CargarEmpleados()
        {
            objetoEmpleado = new ClaseEmpleado(Convert.ToInt32(ViewState["idEmpleado"]));
            ViewState["idEmpleado"] = objetoEmpleado.IdEmpleado;
            txtNom.Text = objetoEmpleado.Nombre;
            txtApePat.Text = objetoEmpleado.ApellidoPaterno;
            txtApeMat.Text = objetoEmpleado.ApellidoMaterno;
            txtCorEle.Text = objetoEmpleado.Correo;

            for (int i = 0; i < ddlGen.Items.Count; i++)
            {
                if (ddlGen.Items[i].Text == objetoEmpleado.Genero.ToString())
                {
                    ddlGen.SelectedIndex = i;
                }
            }
            txtTelefono.Text = objetoEmpleado.Telefono;
            txtCel.Text = objetoEmpleado.Celular;
        }


        #endregion

        protected void cmdFecNac_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFecNac.Text.Trim() != "")
                {
                    dtpFecNac.SelectedDate = Convert.ToDateTime(txtFecNac.Text);
                }
            }
            catch { }
            dtpFecNac.Visible = true;
        }

        protected void dtpFecNac_SelectionChanged(object sender, EventArgs e)
        {
            txtFecNac.Text = dtpFecNac.SelectedDate.ToShortDateString();
            dtpFecNac.Visible = false;
        }

        protected void cmdFecIni_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFecIni.Text.Trim() != "")
                {
                    dtpFecIni.SelectedDate = Convert.ToDateTime(txtFecIni.Text);
                }
            }
            catch { }
            dtpFecIni.Visible = true;
        }

        protected void dtpFecIni_SelectionChanged(object sender, EventArgs e)
        {
            txtFecIni.Text = dtpFecIni.SelectedDate.ToShortDateString();
            dtpFecIni.Visible = false;
        }
    }
}