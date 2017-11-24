using libCinemaAtuWaku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace frmCinemaAtuWaku
{
    public partial class frmCrearProveedor : System.Web.UI.Page
    {
        #region Variables Globales
        clsProveedorRN objProveedor;
        string strNombreAplicacion;
        #endregion

        #region Motodos Privados
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
                if (this.txtProveedor.Text.Trim() == string.Empty || this.txtTelProveedor.Text.Trim() == string.Empty || this.txtEmailProveedor.Text.Trim() == string.Empty)
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
        private void Insertar()
        {
            try
            {
                if (!this.Validar())
                {
                    return;
                }
                objProveedor = new clsProveedorRN();
                objProveedor.NombreAplicacion = strNombreAplicacion;
                objProveedor.NombreProveedor = this.txtProveedor.Text.Trim();
                objProveedor.Telefono = this.txtTelProveedor.Text.Trim();
                objProveedor.Email = this.txtEmailProveedor.Text.Trim();

                if (!objProveedor.CrearProveedor())
                {
                    MostrarMensaje(objProveedor.Error);
                    objProveedor = null;
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
        protected void btnEnviarProvee_Click(object sender, EventArgs e)
        {
            Insertar();
        }
        #endregion
    }
}