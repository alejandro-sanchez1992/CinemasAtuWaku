using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConexionBD;
using System.Data.SqlClient;

namespace libCinemaAtuWaku
{
    class clsSucursalRN
    {
        #region "Constructor"
        public clsSucursalRN()
        {
            int intIdSucursa = 0;
            string strNombreSucursal = string.Empty;
            int intIdCiudad = 0;
            string strDirSucursal = string.Empty;
            string strTelefono = string.Empty;
            string strEmail = string.Empty;
            string strNombreAplicacion = string.Empty;
            string strError = string.Empty;

        }

        #endregion

        #region "Atributos"


        private int intIdSucursal;
        private string strNombreSucursal;
        private int intIdCiudad;
        private string strDirSucursal;
        private string strTelefonoSucursal;
        private string strEmailSucursal;
        private string strError;
        private string strNombreAplicacion = string.Empty;
        SqlParameter[] objParamSql;
        clsConexionBD objConexion;
        SqlDataReader objReader;

        #endregion

        #region "Propiedades"

        public int IdSucursal
        {
            get
            {
                return intIdSucursal;
            }

            set
            {
                intIdSucursal = value;
            }
        }

        public string NombreSucursal
        {
            get
            {
                return strNombreSucursal;
            }

            set
            {
                strNombreSucursal = value;
            }
        }

        public int IdCiudad
        {
            get
            {
                return intIdCiudad;
            }

            set
            {
                intIdCiudad = value;
            }
        }

        public string DirSucursal
        {
            get
            {
                return strDirSucursal;
            }

            set
            {
                strDirSucursal = value;
            }
        }

        public string TelefonoSucursal
        {
            get
            {
                return strTelefonoSucursal;
            }

            set
            {
                strTelefonoSucursal = value;
            }
        }

        public string Email
        {
            get
            {
                return strEmailSucursal;
            }

            set
            {
                strEmailSucursal = value;
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

        public string StrEmailSucursal
        {
            get
            {
                return strEmailSucursal;
            }

            set
            {
                strEmailSucursal = value;
            }
        }

        public string StrTelefonoSucursal
        {
            get
            {
                return strTelefonoSucursal;
            }

            set
            {
                strTelefonoSucursal = value;
            }
        }

        #endregion

        #region "Métodos Privados"
        private bool ValidarSucursal(string strTipoVal)
        {
            switch (strTipoVal)
            {
                case "Crear":
                case "Actualizar":
                    if (strNombreSucursal == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar nombre de la sucursal";
                        return false;
                    }

                    if (intIdCiudad <= 0)
                    {
                        strError = "Ciudad no es valida o no existe";
                        return false;
                    }

                    if (strDirSucursal == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar la dirección de la sucursal";
                        return false;
                    }

                    if (strTelefonoSucursal == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar el teléfono de la sucursal";
                        return false;
                    }

                    if (strEmailSucursal == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar el email";
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
                        objParamSql = new SqlParameter[4];

                        objParamSql[0] = new SqlParameter("@opc", 1);
                        objParamSql[1] = new SqlParameter("@nombre_sucursal", strNombreSucursal);
                        objParamSql[2] = new SqlParameter("@id_ciudad", intIdCiudad);
                        objParamSql[3] = new SqlParameter("@direccion_sucursal", strDirSucursal);
                        objParamSql[4] = new SqlParameter("@telefono_sucursal", strTelefonoSucursal);
                        objParamSql[5] = new SqlParameter("@email_sucursal", strEmailSucursal);
                        break;

                    case "Buscar O Anular":
                        objParamSql = new SqlParameter[1];

                        objParamSql[0] = new SqlParameter("@id_sucursal", intIdSucursal);
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

        public bool ActualizarSucursal()
        {
            try
            {
                if (!ValidarSucursal("Crear O Modificar"))
                {
                    return false;
                }
                clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);
                objCnx.SQL = "SucursalCRUD";
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
        public bool CrearCiudad()
        {
            try
            {
                if (!ValidarSucursal("Crear O Modificar"))
                {
                    return false;
                }
                clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);
                objCnx.SQL = "SucursalCRUD";
                objCnx.ParametrosSQL = objParamSql;

                if (!objCnx.ConsultarValorUnico(true, true))
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

        public bool BuscarSucursal()
        {
            try
            {
                if (!ValidarSucursal("Buscar O Anular"))
                {
                    return false;
                }
                clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);

                objCnx.SQL = "SucursalCRUD";
                objCnx.ParametrosSQL = objParamSql;

                if (!objCnx.Consultar(true, true))
                {
                    strError = objCnx.Error;
                    objCnx.CerrarCnx();
                    objCnx = null;
                    return false;
                }
                objReader = objCnx.DataReader_Lleno;

                objReader.Read();
                intIdSucursal = objReader.GetInt16(1);
                strNombreSucursal = objReader.GetString(2);
                intIdCiudad = objReader.GetInt16(3);
                strDirSucursal = objReader.GetString(4);
                strTelefonoSucursal = objReader.GetString(5);
                strEmailSucursal = objReader.GetString(6);

                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AnularSucursal()
        {
            if (!ValidarSucursal("Buscar O Anular"))
            {
                return false;
            }
            clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);
            objCnx.SQL = "SucursalCRUD";
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
