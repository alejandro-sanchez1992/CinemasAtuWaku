using libConexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libLogin
{
    public class clsLoginRN
    {
        #region Constructor
        public clsLoginRN()
        {
            strUsuario = string.Empty;
            strPassword = string.Empty;
            strNombreAplicacion = string.Empty;
        }
        #endregion

        #region Atributos
        string strUsuario;
        string strPassword;
        string strNombreAplicacion;
        string strError;
        SqlParameter[] objParamSQL;
        clsConexionBD objConexion;
        SqlDataReader objReader;
        #endregion

        #region Propiedades
        public string Usuario
        {
            get
            {
                return strUsuario;
            }
            set
            {
                strUsuario = value;
            }
        }

        public string Password
        {
            set
            {
                strPassword = value;
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
        }
        #endregion

        #region Metodos Privados
        private bool ValidarDatos()
        {
            int _intNumAux;
            if (strNombreAplicacion == string.Empty)
            {
                strError = "Olvidaste enviar el nombre de la aplicación, sin esto no se puede realizar la conexión a la base de datos";
                return false;
            }
            if (this.strUsuario == string.Empty)
            {
                strError = "Debe ingresar su Numero de documento para iniciar sessión";
                return false;
            }
            if (!int.TryParse(this.strUsuario, out _intNumAux))
            {
                strError = "El número de documento solo tienen números. Verifique la información";
                return false;
            }
            if (_intNumAux < 0)
            {
                strError = "El número de documento solo tienen números positivos. Verifique la información";
                return false;
            }
            if(this.strPassword == string.Empty)
            {
                strError = "Debe de ingresar la contraseña para iniciar la sessión";
                return false;
            }
            return true;
        }
        private SqlParameter[] AgregarParametros()
        {
            try
            {
                objParamSQL = new SqlParameter[2];
                objParamSQL[0] = new SqlParameter("@Username", strUsuario);
                objParamSQL[1] = new SqlParameter("@Password", strPassword);

                return objParamSQL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Metodos Publicos
        public bool Login()
        {
            try
            {
                if (!ValidarDatos())
                {
                    return false;
                }
                SqlParameter[] _objDatosLogin;
                objConexion = new clsConexionBD(strNombreAplicacion);
                objConexion.SQL = "SP_Login";
                _objDatosLogin = AgregarParametros();
                objConexion.ParametrosSQL = _objDatosLogin;

                if (!objConexion.Consultar(true, true))
                {
                    strError = objConexion.Error;
                    objConexion = null;
                    return false;
                }
                objReader = objConexion.DataReader_Lleno;

                if (!objReader.HasRows)
                {
                    strError = "El usuario : " + strUsuario + " o la contraseña son incorrectos, por favor verifique la información.";
                    objConexion = null;
                    objReader.Close();
                    return false;
                }

                objReader.Read();
                strUsuario = objReader.GetString(0);
                objReader.Close();

                objConexion = null;
                objReader.Close();
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
