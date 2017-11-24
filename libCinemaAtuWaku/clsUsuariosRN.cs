using libConexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCinemaAtuWaku
{
    public class clsUsuariosRN
    {


        #region "Constructor"
        public clsUsuariosRN()
        {
            string strCedula = string.Empty;
            string strNombre = string.Empty;
            string strApellido = string.Empty;
            string strEmail = string.Empty;
            string strDir = string.Empty;
            string strTelefono = string.Empty;
            int intTipoUsuario = -1;
            string strPassword = string.Empty;
            int intEstado = -1;
            string strNombreAplicacion = string.Empty;
        }

        #endregion

        #region "Atributos"

        private string strCedula;
        private string strNombre;
        private string strApellido;
        private string strEmail;
        private string strDireccion;
        private string strTelefono;
        private int intTipoUsuario;
        private string strPassword;
        private int intEstado;
        private string strNombreAplicacion;
        private string strError;
        SqlParameter[] objParamSql;
        clsConexionBD objConexion;
        SqlDataReader objReader;

        #endregion

        #region "Propiedades"
        public string Cedula
        {
            get
            {
                return strCedula;
            }

            set
            {
                strCedula = value;
            }
        }

        public string Nombre
        {
            get
            {
                return strNombre;
            }

            set
            {
                strNombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return strApellido;
            }

            set
            {
                strApellido = value;
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

        public string Direccion
        {
            get
            {
                return strDireccion;
            }

            set
            {
                strDireccion = value;
            }
        }

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

        public int TipoUsuario
        {
            get
            {
                return intTipoUsuario;
            }

            set
            {
                intTipoUsuario = value;
            }
        }

        public string Password
        {
            get
            {
                return strPassword;
            }

            set
            {
                strPassword = value;
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

        public int Estado
        {
            get
            {
                return intEstado;
            }

            set
            {
                intEstado = value;
            }
        }

        public string NombreAplicacion
        {
            get
            {
                return strNombreAplicacion;
            }

            set
            {
                strNombreAplicacion = value;
            }
        }

        #endregion

        #region "Métodos Privados"
        private bool ValidarUsuario(string strTipoVal)
        {
            int _intAux;
            switch (strTipoVal)
            {
                case "Crear":
                case "Actualizar":
                    if (strCedula == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar un número de cédula";
                        return false;
                    }
                    if (!int.TryParse(this.strCedula, out _intAux))
                    {
                        strError = "Debes ingresar solo números";
                        return false;
                    }

                    if (_intAux <= 0)
                    {
                        strError = "La cedula debe ser números positivos";
                        return false;
                    }

                    if (strNombre == string.Empty)
                    {
                        strError = "El campo esta vacio, debed ingrsar un nombre";
                        return false;
                    }

                    if (strApellido == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar el apellido";
                        return false;
                    }

                    if (strEmail == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar el email";
                        return false;
                    }

                    if (strDireccion == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar la dirección";
                        return false;
                    }

                    if (strTelefono == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar el teléfono";
                        return false;
                    }

                    if (intTipoUsuario <= 0)
                    {
                        strError = "Tipo de usuario incalido";
                        return false;
                    }

                    if (strPassword == string.Empty)
                    {
                        strError = "debe ingresar contraseña";
                        return false;
                    }

                    if (intEstado <= 0)
                    {
                        strError = "Estado invalido";
                        return false;
                    }
                    break;

            }
            return true;
        }

        private SqlParameter[] AgregarParametros(string PstrTipoParametro)
        {
            try
            {
                switch (PstrTipoParametro)
                {
                    case "Crear O Modificar":
                        objParamSql = new SqlParameter[10];
                        objParamSql[0] = new SqlParameter("@opc", 1);
                        objParamSql[1] = new SqlParameter("@cedula", strCedula);
                        objParamSql[2] = new SqlParameter("@nombre", strNombre);
                        objParamSql[3] = new SqlParameter("@apellido", strApellido);
                        objParamSql[4] = new SqlParameter("@email", strEmail);
                        objParamSql[5] = new SqlParameter("@direccion", strDireccion);
                        objParamSql[6] = new SqlParameter("@telefono", strTelefono);
                        objParamSql[7] = new SqlParameter("@id_tipoUsuario", intTipoUsuario);
                        objParamSql[8] = new SqlParameter("@user_password", strPassword);
                        objParamSql[9] = new SqlParameter("@id_estado", intEstado);
                        break;

                    case "Buscar O Anular":
                        objParamSql = new SqlParameter[1];

                        objParamSql[0] = new SqlParameter("@cedula", strCedula);
                        break;
                }

                return objParamSql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region "Métodos Publicos"

        public bool ActualizarUsuario()
        {
            try
            {
                if (!ValidarUsuario("Crear O Modificar"))
                {
                    return false;
                }

                clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);
                objCnx.SQL = "UsuariosCRUD";
                objCnx.ParametrosSQL = objParamSql;

                if (!objCnx.EjecutarSentencia(true, true))
                {
                    strError = objCnx.Error;
                    objCnx.CerrarCnx();
                    objCnx = null;
                    return false;
                }

                objCnx.CerrarCnx();
                objCnx = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool CrearUsuario()
        {
            try
            {
                if (!ValidarUsuario("Crear O Modificar"))
                {
                    return false;
                }
                SqlParameter[] _objDatos;
                objConexion = new clsConexionBD(strNombreAplicacion);
                objConexion.SQL = "UsuariosCRUD";
                _objDatos = AgregarParametros("Insertar");
                objConexion.ParametrosSQL = _objDatos;

                if (!objConexion.EjecutarSentencia(true, true))
                {
                    strError = objConexion.Error;
                    objConexion.CerrarCnx();
                    objConexion = null;
                    return false;
                }

                objConexion.CerrarCnx();
                objConexion = null;
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool BuscarUsuario()
        {
            try
            {
                if (!ValidarUsuario("Buscar O Anular"))
                {
                    return false;
                }
                clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);

                objCnx.SQL = "UsuariosCRUD";
                objCnx.ParametrosSQL = objParamSql;

                if (!objCnx.Consultar(true, true))
                {
                    strError = objCnx.Error;
                    objCnx.CerrarCnx();
                    objCnx = null;
                    return false;
                }
                objReader = objCnx.DataReader_Lleno;

                if (!objReader.HasRows)
                {
                    strError = "El usuario con documento: " + strCedula + " no existe";
                    objReader.Close();
                    objCnx = null;
                    return false;
                }
                objReader.Read();
                strCedula = objReader.GetString(1);
                strNombre = objReader.GetString(2);
                strApellido = objReader.GetString(3);
                strDireccion = objReader.GetString(4);
                strTelefono = objReader.GetString(5);
                strEmail = objReader.GetString(6);
                intTipoUsuario = objReader.GetInt16(7);
                strPassword = objReader.GetString(8);
                intEstado = objReader.GetInt16(9);
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AnularUsuario()
        {
            if (!ValidarUsuario("Buscar O Anular"))
            {
                return false;
            }
            clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);
            objCnx.SQL = "UsuariosCRUD";
            objCnx.ParametrosSQL = objParamSql;

            if (!objCnx.EjecutarSentencia(true, true))
            {
                strError = objCnx.Error;
                objCnx.CerrarCnx();
                objCnx = null;
                return false;
            }

            objCnx.CerrarCnx();
            objCnx = null;
            return true;

        }


        #endregion
    }
}
