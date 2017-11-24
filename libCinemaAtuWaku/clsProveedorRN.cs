using libConexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCinemaAtuWaku
{
    public class clsProveedorRN
    {
        #region Constructor
        public clsProveedorRN()
        {
            strNombreProveedor = string.Empty;
            strTelefono = string.Empty;
            strEmail = string.Empty;
            strNombreAplicacion = string.Empty;
        }
        #endregion

        #region Atributos
        string strNombreAplicacion;
        string strNombreProveedor;
        string strTelefono;
        string strEmail;
        string strError;
        SqlParameter[] objParamSQL;
        clsConexionBD objConexion;
        #endregion

        #region Propiedade
        public string Telefono
        {
            get
            {
                return strTelefono;
            }

            set
            {
                strTelefono = value;
            }
        }

        public string Email
        {
            get
            {
                return strEmail;
            }

            set
            {
                strEmail = value;
            }
        }
        public string NombreAplicacion
        {
            set
            {
                strNombreAplicacion = value;
            }
        }
        public string Error
        {
            get
            {
                return strError;
            }

            set
            {
                strError = value;
            }
        }

        public string NombreProveedor
        {
            get
            {
                return strNombreProveedor;
            }

            set
            {
                strNombreProveedor = value;
            }
        }
        #endregion

        #region Metodos Privados
        private bool ValidarDatos(string PstrTipoValidacion)
        {
            int _intNumAux;
            switch (PstrTipoValidacion)
            {
                case "Insertar":
                case "Actualizar":
                    if (this.strNombreAplicacion == string.Empty)
                    {
                        strError = "Olvidaste enviar el nombre de la aplicación, sin esto no se puede realizar la conexión a la base de datos";
                        return false;
                    }
                    if (this.strNombreProveedor == string.Empty)
                    {
                        strError = "Debes de ingresar el Nombre del Proveedor";
                        return false;
                    }
                    if (this.strTelefono == string.Empty)
                    {
                        strError = "Debes de ingresar el Número de teléfono del proveedor";
                        return false;
                    }
                    if (!int.TryParse(this.strTelefono, out _intNumAux))
                    {
                        strError = "El número de teléfono debe ser Números";
                        return false;
                    }
                    if (_intNumAux < 0)
                    {
                        strError = "El número de teléfono solo tienen números positivos. Verifique la información";
                        return false;
                    }
                    if (this.strEmail == string.Empty)
                    {
                        strError = "Debes de ingresar el correo electrónico del proveedor";
                        return false;
                    }
                    if (!this.IsValidEmail(strEmail))
                    {
                        strError = "Correo Eletrónico incorrecto verifique la informacion";
                        return false;
                    }
                    break;
            }
            return true;
        }
        private bool IsValidEmail(string strEmail)
        {
            try
            {
                var email = new System.Net.Mail.MailAddress(strEmail);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private SqlParameter[] AgregarParametros(string PstrTipoParametro)
        {
            try
            {
                switch (PstrTipoParametro)
                {
                    case "Insertar":
                        objParamSQL = new SqlParameter[5];
                        objParamSQL[0] = new SqlParameter("@opc", 1);
                        objParamSQL[1] = new SqlParameter("@id_proveedor", 1);
                        objParamSQL[2] = new SqlParameter("@nombre_empresa", strNombreProveedor);
                        objParamSQL[3] = new SqlParameter("@telefono", strTelefono);
                        objParamSQL[4] = new SqlParameter("@email", strEmail);
                        break;
                }

                return objParamSQL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Metodos Publicos
        public bool CrearProveedor()
        {
            try
            {
                if (!ValidarDatos("Insertar") || !ValidarDatos("Actualizar"))
                {
                    return false;
                }
                SqlParameter[] _objDatos;
                objConexion = new clsConexionBD(strNombreAplicacion);
                objConexion.SQL = "ProveedorCRUD";
                _objDatos = AgregarParametros("Insertar");
                objConexion.ParametrosSQL = _objDatos;

                if (!objConexion.EjecutarSentencia(true, true))
                {
                    strError = objConexion.Error;
                    objConexion.CerrarCnx();
                    objConexion = null;
                    return false;
                }

                int _intRespuesta = Convert.ToInt16(objConexion.Valor_Unico);
                objConexion.CerrarCnx();
                objConexion = null;
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
