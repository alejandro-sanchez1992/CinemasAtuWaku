using libConexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace libLlenarRBList
{
    public class clsLenarRBList
    {
        #region "Constructor"
        public clsLenarRBList(string PstrNombreAplicacion)
        {
            strNombreApp = PstrNombreAplicacion;
            strSQL = string.Empty;
            strCampoID = string.Empty;
            strCampoTexto = string.Empty;
            strError = string.Empty;
            blnEjecParametros = false;
        }
        #endregion

        #region "Atributos"
        string strNombreApp;
        string strSQL;
        string strCampoID;
        string strCampoTexto;
        string strError;
        bool blnEjecParametros;
        SqlParameter[] objParamSQL;
        #endregion

        #region "Propiedades"
        public string SQL
        {
            set
            {
                strSQL = value;
            }
        }

        public string CampoID
        {
            set
            {
                strCampoID = value;
            }
        }

        public string CampoTexto
        {
            set
            {
                strCampoTexto = value;
            }
        }

        public string Error
        {
            get
            {
                return strError;
            }
        }

        public SqlParameter[] ParametrosSQL
        {
            set
            {
                objParamSQL = value;
            }
        }

        #endregion

        #region "Métodos Privados"
        private bool Validar()
        {
            if (string.IsNullOrEmpty(strSQL))
            {
                strError = "Debe enviar el nombre del procedimiento almacenado para consultar la información que llenará el Combo";
                return false;
            }
            if (string.IsNullOrEmpty(strCampoID))
            {
                strError = "Debe enviar el nombre de la columna que será el Identificador para el Combo";
                return false;
            }
            if (string.IsNullOrEmpty(strCampoTexto))
            {
                strError = "Debe enviar el nombre de la columna que será el Texto para el Combo";
                return false;
            }
            return true;
        }
        #endregion

        #region "Métodos Públicos"
        public bool LlenarRadioBL_Web(RadioButtonList PrblGenerico)
        {
            try
            {
                if(!Validar())
                {
                    return false;
                }

                clsConexionBD _objCnx = new clsConexionBD(strNombreApp);
                _objCnx.SQL = strSQL;

                if(objParamSQL != null)
                {
                    blnEjecParametros = true;
                }
                if(!_objCnx.LlenarDataSet(blnEjecParametros,true))
                {
                    strError = _objCnx.Error;
                    _objCnx.CerrarCnx();
                    _objCnx = null;
                    return false;
                }
                PrblGenerico.DataSource = _objCnx.DataSet_Lleno.Tables[0];
                PrblGenerico.DataValueField = strCampoID;
                PrblGenerico.DataTextField = strCampoTexto;
                PrblGenerico.DataBind();
                _objCnx.CerrarCnx();
                _objCnx = null;
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
