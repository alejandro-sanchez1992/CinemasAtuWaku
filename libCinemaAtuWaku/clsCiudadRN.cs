using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libConexionBD;

namespace libCinemaAtuWaku
{
    class clsCiudadRN
    {
        #region "Constructor"
        public clsCiudadRN()
        {
            int intIdCiudad = 0;
            string strNombre_Ciudad = string.Empty;
            string strUbicacion = string.Empty;
            int intEstado = 0;
            string strNombreAplicacion = string.Empty;
            string strError = string.Empty;

        }

        #endregion

        #region "Atributos"

        private int intIdCiudad;
        private string strNombre_Ciudad;
        private string strUbicacion;
        private int intEstado;
        private string strError;
        private string strNombreAplicacion = string.Empty;
        SqlParameter[] objParamSql;
        clsConexionBD objConexion;
        SqlDataReader objReader;

        #endregion

        #region "Propiedades"

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

        public string Nombre_Ciudad
        {
            get
            {
                return strNombre_Ciudad;
            }

            set
            {
                strNombre_Ciudad = value;
            }
        }

        public string Ubicacion
        {
            get
            {
                return strUbicacion;
            }

            set
            {
                strUbicacion = value;
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


        #endregion

        #region "Métodos Privados"
        private bool ValidarCiudad(string strTipoVal)
        {
            switch (strTipoVal)
            {
                case "Crear":
                case "Actualizar":
                    if (strNombre_Ciudad == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar nombre de la ciudad";
                        return false;
                    }

                    if (strUbicacion == string.Empty)
                    {
                        strError = "El campo esta vacio, debe ingresar la ubicación de la ciudad";
                        return false;
                    }

                    if (intEstado <= 0)
                    {
                        strError = "El estado seleccionado no es válido";
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
                        objParamSql[1] = new SqlParameter("@nombre_ciudad", strNombre_Ciudad);
                        objParamSql[2] = new SqlParameter("@ubicacion", strUbicacion);
                        objParamSql[3] = new SqlParameter("@id_estado", intEstado);
                        break;

                    case "Buscar O Anular":
                        objParamSql = new SqlParameter[1];

                        objParamSql[0] = new SqlParameter("@id_ciudad", intIdCiudad);
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

        public bool ActualizarCiudad()
        {
            try
            {
                if (!ValidarCiudad("Crear O Modificar"))
                {
                    return false;
                }
                clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);
                objCnx.SQL = "CiudadCRUD";
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
                if (!ValidarCiudad("Crear O Modificar"))
                {
                    return false;
                }
                clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);
                objCnx.SQL = "CiudadCRUD";
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

        public bool BuscarCiudad()
        {
            try
            {
                if (!ValidarCiudad("Buscar O Anular"))
                {
                    return false;
                }
                clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);

                objCnx.SQL = "sCiudadCRUD";
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
                intIdCiudad = objReader.GetInt16(1);
                strNombre_Ciudad = objReader.GetString(2);
                strUbicacion = objReader.GetString(3);
                intEstado = objReader.GetInt16(4);

                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AnularCliente()
        {
            if (!ValidarCiudad("Buscar O Anular"))
            {
                return false;
            }
            clsConexionBD objCnx = new clsConexionBD(strNombreAplicacion);
            objCnx.SQL = "CiudadCRUD";
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
