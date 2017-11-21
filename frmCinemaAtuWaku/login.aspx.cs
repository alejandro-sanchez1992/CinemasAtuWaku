using libLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace frmCinemaAtuWaku
{
    public partial class login : System.Web.UI.Page
    {
        #region Variables Globales
        clsLoginRN objLogin;
        string strNombreAplicacion;
        #endregion

        #region Metodos Privados
        private void MostrarMensaje(string PstrMensaje)
        {
            this.lblMensaje.Text = PstrMensaje;

            if (PstrMensaje == string.Empty)
            {
                this.lblMensaje.Visible = false;
            }
            else
            {
                this.lblMensaje.Visible = true;
            }
        }
        private bool Validar()
        {
            try
            {
                if (this.txtUsuario.Text.Trim() == string.Empty && this.txtPassword.Text.Trim() == string.Empty)
                {
                    MostrarMensaje("Debe ingresar el documento y la Contraseña para iniciar la sessión");
                    this.txtUsuario.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
                return false;
            }
        }
        private void Ingresar()
        {
            try
            {
                MostrarMensaje("");
                if (!Validar())
                {
                    return;
                }
                objLogin = new clsLoginRN();
                objLogin.NombreAplicacion = strNombreAplicacion;
                objLogin.Usuario = this.txtUsuario.Text.Trim();
                objLogin.Password = this.txtPassword.Text.Trim();

                if (!objLogin.Login())
                {
                    MostrarMensaje(objLogin.Error);
                    objLogin = null;
                    return;
                }
                Session["strTipoUsuario"] = objLogin.Usuario;
                Response.Redirect("index.aspx", false);
                objLogin = null;
            }
            catch (Exception ex)
            {

                MostrarMensaje(ex.Message);
            }
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                strNombreAplicacion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            }
        }
        protected void btnLoginButton_Click(object sender, EventArgs e)
        {
            Ingresar();
        }
        #endregion
    }
}