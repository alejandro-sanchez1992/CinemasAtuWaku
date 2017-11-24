using libCinemaAtuWaku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace frmCinemaAtuWaku
{
    public partial class frmCrearUsuario : System.Web.UI.Page
    {
        #region Variables Globales
        clsUsuariosRN objUsuario;
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
                if (this.txtDocumento.Text.Trim() == string.Empty
                    || this.ddlTipoUSuario.SelectedIndex.Equals(0)
                    || this.txtEmail.Text.Trim() == string.Empty
                    || this.txtNombre.Text.Trim() == string.Empty
                    || this.txtApellido.Text.Trim() == string.Empty
                    || this.txtDireccion.Text.Trim() == string.Empty
                    || this.txtTelefono.Text.Trim() == string.Empty
                    || this.ddlEstado.SelectedIndex.Equals(0)
                    )
                {
                    MostrarMensaje("Faltan Datos por completar o son incorrectos por favor verifique la información");
                    this.Focus();
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
        private bool ValidarPassword()
        {
            if (this.txtPassword2.Text.Trim() != this.txtPassword1.Text.Trim())
            {
                MostrarMensaje("La contraseña no coincide, porfavor verifica la información");
                this.Focus();
                return false;
            }
            return true;
        }
        private void Insertar()
        {
            try
            {
                if (!this.Validar())
                {
                    return;
                }
                if (!this.ValidarPassword())
                {
                    return;
                }
                objUsuario = new clsUsuariosRN();
                objUsuario.NombreAplicacion = strNombreAplicacion;
                objUsuario.TipoUsuario = Convert.ToInt32(this.ddlTipoUSuario.SelectedIndex);
                objUsuario.Email = this.txtEmail.Text.Trim();
                objUsuario.Nombre = this.txtNombre.Text.Trim();
                objUsuario.Apellido = this.txtApellido.Text.Trim();
                objUsuario.Direccion = this.txtDireccion.Text.Trim();
                objUsuario.Telefono = this.txtTelefono.Text.Trim();
                objUsuario.Estado = Convert.ToInt32(this.ddlEstado.SelectedIndex);

                if (!objUsuario.CrearUsuario())
                {
                    MostrarMensaje(objUsuario.Error);
                    objUsuario = null;
                    return;
                }
                else
                {
                    MostrarMensaje("Se ejecuto correctamente la operación");
                }

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
        protected void btnEnviarUsuario_Click(object sender, EventArgs e)
        {
            Insertar();
        }
        #endregion
    }
}