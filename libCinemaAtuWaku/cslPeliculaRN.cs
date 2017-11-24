using libConexionBD;
using libLlenarCombos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace libCinemaAtuWaku
{
    class cslPeliculaRN
    {
        #region Constructor
        public cslPeliculaRN()
        {
            strNombreAplicacion = string.Empty;
            strTituloPelicula = string.Empty;
            strDescripcionPeli = string.Empty;
            strIdiomaPeli = string.Empty;
            strDirector = string.Empty;
            strDuracionPeli = string.Empty;
            intIdEstado = 0;
            strNombreAplicacion = string.Empty;
        }
        #endregion

        #region Atributos
        string strNombreAplicacion;
        string strTituloPelicula;
        string strDescripcionPeli;
        string strIdiomaPeli;
        string strDirector;
        string strDuracionPeli;
        int intIdEstado;
        string strError;
        DropDownList ddlCombo;
        SqlParameter[] objParamSQL;
        clsConexionBD objConexion;
        #endregion

        #region Propiedades
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

        public string TituloPelicula
        {
            get
            {
                return strTituloPelicula;
            }

            set
            {
                strTituloPelicula = value;
            }
        }

        public string DescripcionPeli
        {
            get
            {
                return strDescripcionPeli;
            }

            set
            {
                strDescripcionPeli = value;
            }
        }

        public string Director
        {
            get
            {
                return strDirector;
            }

            set
            {
                strDirector = value;
            }
        }

        public string DuracionPeli
        {
            get
            {
                return strDuracionPeli;
            }

            set
            {
                strDuracionPeli = value;
            }
        }

        public int IdEstado
        {
            get
            {
                return intIdEstado;
            }

            set
            {
                intIdEstado = value;
            }
        }

        public string Error
        {
            get
            {
                return strError;
            }
        }

        public string IdiomaPeli
        {
            get
            {
                return strIdiomaPeli;
            }

            set
            {
                strIdiomaPeli = value;
            }
        }
        #endregion

        #region Metodos Privados
        private bool ValidarDatos(string PstrTipoValidacion)
        {
            switch (PstrTipoValidacion)
            {
                case "Insertar":
                case "Actualizar":
                    if (this.strNombreAplicacion == string.Empty)
                    {
                        strError = "Olvidaste enviar el nombre de la aplicación, sin esto no se puede realizar la conexión a la base de datos";
                        return false;
                    }
                    if (this.strTituloPelicula == string.Empty)
                    {
                        strError = "Debes de ingresar el nombre de la Pelicula";
                        return false;
                    }
                    if (this.strDescripcionPeli == string.Empty)
                    {
                        strError = "Debes de Ingresar una descripción para la pelicula";
                        return false;
                    }
                    if (this.strDuracionPeli == string.Empty)
                    {
                        strError = "Debes ingresar la Duración de la Pelicula";
                        return false;
                    }
                    if (this.strDirector == string.Empty)
                    {
                        strError = "Debes de ingresar el Director de la pelicula";
                        return false;
                    }
                    if (this.intIdEstado < 0)
                    {
                        strError = "El Estado es incorrecto por favor verifique la información";
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
                    case "Insertar":
                        objParamSQL = new SqlParameter[8];
                        objParamSQL[0] = new SqlParameter("@opc", 1);
                        objParamSQL[1] = new SqlParameter("@id_pelicula", 1);
                        objParamSQL[2] = new SqlParameter("@tituloPeli", strTituloPelicula);
                        objParamSQL[3] = new SqlParameter("@descripcion_pelicula", strDescripcionPeli);
                        objParamSQL[4] = new SqlParameter("@idioma_pelicula", strIdiomaPeli);
                        objParamSQL[5] = new SqlParameter("@director_pelicula", strDirector);
                        objParamSQL[6] = new SqlParameter("@duracion_pelicula", strDuracionPeli);
                        objParamSQL[7] = new SqlParameter("@id_estado", intIdEstado);
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

        #region Metodos publicos
        public bool InsertarProducto()
        {
            try
            {
                if (!ValidarDatos("Insertar") || !ValidarDatos("Actualizar"))
                {
                    return false;
                }
                SqlParameter[] _objDatos;
                objConexion = new clsConexionBD(strNombreAplicacion);
                objConexion.SQL = "PeliculasCRUD";
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
        public bool LlenarCombo()
        {
            try
            {
                if (!ValidarDatos("Validar Combo"))
                {
                    return false;
                }
                clsLlenarCombos _objLlenar = new clsLlenarCombos(strNombreAplicacion);
                _objLlenar.SQL = "Combo";
                _objLlenar.CampoID = "intCodigo";
                _objLlenar.CampoTexto = "varNombre";

                if (!_objLlenar.LlenarCombo_Web(ddlCombo))
                {
                    strError = _objLlenar.Error;
                    _objLlenar = null;
                    return false;
                }
                _objLlenar = null;
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