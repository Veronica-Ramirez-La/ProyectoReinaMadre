using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Negocio.Clases.Login;

namespace ProyectoReinaMadre
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Variables
        private ClaseLogin objetoUsuario = new ClaseLogin();
        #endregion

        //string patron = "reinaMadre";
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {

          

             objetoUsuario = new ClaseLogin(tbUsuario.Text, tbPassword.Text);
            if (objetoUsuario.Id > 0)
            {

            

            //string conectar =  ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            //SqlConnection sqlConectar = new SqlConnection(conectar);
            //SqlCommand cmd = new SqlCommand("SP_ValidarUsuario", sqlConectar)
            //{
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Connection.Open();
            //cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = tbUsuario.Text;
            //cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 50).Value = tbPassword.Text;
            //cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
                //Agregamos una sesion de usuario
                Session["usuariologueado"] = tbUsuario.Text;
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                lblError.Text = "Error de Usuario o Contrasenia";
            }

            //cmd.Connection.Close();
        }
        }
}