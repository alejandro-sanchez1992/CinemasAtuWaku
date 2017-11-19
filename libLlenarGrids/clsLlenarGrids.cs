using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using libConexionBD;

namespace libLlenarGrids
{
    public class clsLlenarGrids
    {
        #region "Constructor"
        public clsLlenarGrids(string PstrNombreAplicacion)
        {
            strNombreApp = PstrNombreAplicacion;
            strSQL = string.Empty;
            strError = string.Empty;
            blnEjecParemtros = false;
        }
        #endregion

        #region "Atributos"
        string strNombreApp;
        string strSQL;
        string strError;
        bool blnEjecParemtros;
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
            if(string.IsNullOrEmpty(strSQL))
            {
                strError = "Debes enviar el nombre del procedimiento almacenado para consultar los datos y llenar la Grid";
                return false;
            }
            return true;
        }
        #endregion

        #region "Métodos Públicos"
        public bool LlenarGrid_Windows(DataGridView PdgvGenerico)
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
                    blnEjecParemtros = true;
                }
                if(!_objCnx.LlenarDataSet(blnEjecParemtros,true))
                {
                    strError = _objCnx.Error;
                    _objCnx.CerrarCnx();
                    _objCnx = null;
                    return false;
                }

                PdgvGenerico.DataSource = _objCnx.DataSet_Lleno.Tables[0];
                PdgvGenerico.Refresh();
                _objCnx.CerrarCnx();
                _objCnx = null;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool LlenarGrid_Web(GridView PgvGenerico)
        {
            try
            {
                if (!Validar())
                {
                    return false;
                }
                clsConexionBD _objCnx = new clsConexionBD(strNombreApp);
                _objCnx.SQL = strSQL;

                if (objParamSQL != null)
                {
                    blnEjecParemtros = true;
                }
                if (!_objCnx.LlenarDataSet(blnEjecParemtros, true))
                {
                    strError = _objCnx.Error;
                    _objCnx.CerrarCnx();
                    _objCnx = null;
                    return false;
                }

                PgvGenerico.DataSource = _objCnx.DataSet_Lleno.Tables[0];
                PgvGenerico.DataBind();
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
