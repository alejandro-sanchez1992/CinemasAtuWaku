using libParametrosCnx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libConexionBD
{
    public class clsConexionBD
    {
        #region Constructor
        public clsConexionBD(string PstrNombreAplicacion)
        {
            strNombreAPP = PstrNombreAplicacion;
            blnHayCnx = false;
            objCnxBD = new SqlConnection();
            objCmd = new SqlCommand();
            objAdapter = new SqlDataAdapter();
            dsDatos = new DataSet();
        }
        #endregion

        #region Atributos
        string strNombreAPP;
        string strCadenacnx;
        object objVrUnico;
        string strSql;
        string strError;
        bool blnHayCnx;
        SqlConnection objCnxBD;
        SqlCommand objCmd;
        SqlDataReader objReader;
        SqlDataAdapter objAdapter;
        DataSet dsDatos;
        SqlParameter[] objSqlParam;
        #endregion

        #region Metodos Get - Set
        public object Valor_Unico
        {
            get
            {
                return objVrUnico;
            }
        }

        public string SQL
        {
            set
            {
                strSql = value;
            }
        }

        public string Error
        {
            get
            {
                return strError;
            }
        }

        public SqlDataReader DataReader_Lleno
        {
            get
            {
                return objReader;
            }
        }

        public DataSet DataSet_Lleno
        {
            get
            {
                return dsDatos;
            }
        }

        public SqlParameter[] ParametrosSQL
        {
            set
            {
                objSqlParam = value;
            }
        }
        #endregion
        
        #region Metodos Privados
        private bool GenerarCadenaCnx()
        {
            try
            {
                clsParametros _objParam = new clsParametros();
                if (string.IsNullOrEmpty(strNombreAPP))
                {
                    strError = "Debe enviar el nombre de la aplicación para generar la cadena de conexión";
                    return false;
                }

                if (!_objParam.GenerarCadenaCnx(strNombreAPP))
                {
                    strError = _objParam.Error;
                    _objParam = null;
                    return false;
                }
                strCadenacnx = _objParam.CadenaCnx;
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool AbrirCnx()
        {
            try
            {
                if (!GenerarCadenaCnx())
                {
                    return false;
                }
                objCnxBD.ConnectionString = strCadenacnx;
                objCnxBD.Open();
                blnHayCnx = true;
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool AgregarParametros(SqlParameter[] PobjSqlParametros)
        {
            try
            {
                foreach (SqlParameter objParam in PobjSqlParametros)
                {
                    objCmd.Parameters.AddWithValue(objParam.ParameterName, objParam.Value);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Metodos publicos
        public bool CerrarCnx()
        {
            try
            {
                objCnxBD.Close();
                blnHayCnx = false;
                objCnxBD = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Consultar(bool PblnParametros, bool PblnProcAlmacenado)
        {
            try
            {
                if (string.IsNullOrEmpty(strSql))
                {
                    strError = "No se envió el nombre del procedimiento almacenado para ejecutar el método consultar";
                    return false;
                }

                if (!blnHayCnx)
                {
                    if (!AbrirCnx())
                    {
                        return false;
                    }
                }
                objCmd.Connection = objCnxBD;
                objCmd.CommandText = strSql;

                if (PblnProcAlmacenado)
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    if (PblnParametros)
                    {
                        if (!AgregarParametros(objSqlParam))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    objCmd.CommandType = CommandType.Text;
                }
                objReader = objCmd.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ConsultarValorUnico(bool PblnParametros, bool PblnProcAlmacenado)
        {
            try
            {
                if (string.IsNullOrEmpty(strSql))
                {
                    strError = "No se envió el nombre del procedimiento almacenado para ejecutar el método consultarValorUnico";
                    return false;
                }

                if (!blnHayCnx)
                {
                    if (!AbrirCnx())
                    {
                        return false;
                    }
                }
                objCmd.Connection = objCnxBD;
                objCmd.CommandText = strSql;

                if (PblnProcAlmacenado)
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    if (PblnParametros)
                    {
                        if (!AgregarParametros(objSqlParam))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    objCmd.CommandType = CommandType.Text;
                }
                objVrUnico = objCmd.ExecuteScalar();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EjecutarSentencia(bool PblnParametros, bool PblnProcAlmacenado)
        {
            try
            {
                if (string.IsNullOrEmpty(strSql))
                {
                    strError = "No se envió el nombre del procedimiento almacenado para ejecutar el método EjecutarSentencia";
                    return false;
                }

                if (!blnHayCnx)
                {
                    if (!AbrirCnx())
                    {
                        return false;
                    }
                }
                objCmd.Connection = objCnxBD;
                objCmd.CommandText = strSql;

                if (PblnProcAlmacenado)
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    if (PblnParametros)
                    {
                        if (!AgregarParametros(objSqlParam))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    objCmd.CommandType = CommandType.Text;
                }
                objCmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool LlenarDataSet(bool PblnParametros, bool PblnProcAlmacenado)
        {
            try
            {
                if (string.IsNullOrEmpty(strSql))
                {
                    strError = "No se envió el nombre del procedimiento almacenado para ejecutar el método LlenarDataSet";
                    return false;
                }

                if (!blnHayCnx)
                {
                    if (!AbrirCnx())
                    {
                        return false;
                    }
                }
                objCmd.Connection = objCnxBD;
                objCmd.CommandText = strSql;

                if (PblnProcAlmacenado)
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    if (PblnParametros)
                    {
                        if (!AgregarParametros(objSqlParam))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    objCmd.CommandType = CommandType.Text;
                }
                objAdapter.SelectCommand = objCmd;
                objAdapter.Fill(dsDatos);
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
