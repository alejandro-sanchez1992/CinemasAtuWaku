using libCinemaAtuWaku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace frmCinemaAtuWaku
{
    public partial class frmCrearProducto : System.Web.UI.Page
    {
        #region Variables Globales
        clsProductoRN objProducto;
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
                if (this.ddlProveedor.SelectedIndex.Equals(0) 
                    || this.txtNomProduct.Text.Trim() == string.Empty 
                    || this.txtDescripcion.Text.Trim() == string.Empty
                    || this.txtValor.Text.Trim() == string.Empty
                    || this.txtCantProduct.Text.Trim() == string.Empty
                    || this.ddlEstadoProduct.SelectedIndex.Equals(0)
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
        private void Insertar()
        {
            try
            {
                if (!this.Validar())
                {
                    return;
                }
                objProducto = new clsProductoRN();
                objProducto.NombreAplicacion = strNombreAplicacion;
                objProducto.IdProveedor = Convert.ToInt32(this.ddlProveedor.SelectedIndex);
                objProducto.NombreProducto = this.txtNomProduct.Text.Trim();
                objProducto.Descripcion = this.txtDescripcion.Text.Trim();
                objProducto.Valor = this.txtValor.Text.Trim();
                objProducto.Cantidad = Convert.ToInt32(this.txtCantProduct.Text.Trim());
                objProducto.IdEstado = Convert.ToInt32(this.ddlEstadoProduct.SelectedIndex);

                if (!objProducto.CrearProducto())
                {
                    MostrarMensaje(objProducto.Error);
                    objProducto = null;
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
        protected void btnEnviarProducto_Click(object sender, EventArgs e)
        {
            Insertar();
        }
        #endregion
    }
}