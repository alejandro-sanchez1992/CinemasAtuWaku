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
    class clsProductoRN
    {
        #region Contructor
        public clsProductoRN()
        {
            strNombreProducto = string.Empty;
            intIdProveedor = 0;
            strDescripcion = string.Empty;
            strValor = string.Empty;
            intCantidad = 0;
            intIdEstado = 0;
            strNombreAplicacion = string.Empty;
        }
        #endregion

        #region Atributos
        string strNombreAplicacion;
        int intIdProveedor;
        string strNombreProducto;
        string strDescripcion;
        string strValor;
        int intCantidad;
        int intIdEstado;
        string strError;
        SqlParameter[] objParamSQL;
        clsConexionBD objConexion;
        DropDownList ddlCombo;
        #endregion

        #region Propiedades
        public string NombreAplicacion
        {
            set
            {
                strNombreAplicacion = value;
            }
        }

        public int IdProveedor
        {
            get
            {
                return intIdProveedor;
            }

            set
            {
                intIdProveedor = value;
            }
        }

        public string NombreProducto
        {
            get
            {
                return strNombreProducto;
            }

            set
            {
                strNombreProducto = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return strDescripcion;
            }

            set
            {
                strDescripcion = value;
            }
        }

        public string Valor
        {
            get
            {
                return strValor;
            }

            set
            {
                strValor = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return intCantidad;
            }

            set
            {
                intCantidad = value;
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
            set
            {
                strError = value;
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
                    float _ftlNumAux;
                    if (this.strNombreAplicacion == string.Empty)
                    {
                        strError = "Olvidaste enviar el nombre de la aplicación, sin esto no se puede realizar la conexión a la base de datos";
                        return false;
                    }
                    if (this.intIdProveedor <= 0)
                    {
                        strError = "El proveedor seleccionado no es correcto, verifique la información";
                        return false;
                    }
                    if (this.strNombreProducto == string.Empty)
                    {
                        strError = "Debes de ingresar el Nombre del Producto";
                        return false;
                    }
                    if (this.strDescripcion == string.Empty)
                    {
                        strError = "Debes de ingresar una descripción del producto";
                        return false;
                    }
                    if (!float.TryParse(this.strValor, out _ftlNumAux))
                    {
                        strError = "Debes de ingresar solo numeros en campo de valor de producto";
                        return false;
                    }
                    if (_ftlNumAux <= 0)
                    {
                        strError = "Debes ingresar un valor mayor a cero";
                        return false;
                    }
                    if (this.intCantidad < 0)
                    {
                        strError = "La cantidad del proucto debe ser Mayor a cero";
                        return false;
                    }
                    if (this.intIdEstado < 0)
                    {
                        strError = "El estado ingresado es incorrecto, por favor verifique la información";
                        return false;
                    }
                    break;
                case "Validar Combo":
                    if (this.ddlCombo == null)
                    {
                        strError = "No hay información disponible";
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
                        objParamSQL = new SqlParameter[6];
                        objParamSQL[0] = new SqlParameter("@opc", 1);
                        objParamSQL[1] = new SqlParameter("@id_proveedor", intIdProveedor);
                        objParamSQL[2] = new SqlParameter("@nombre_prodct", strNombreProducto);
                        objParamSQL[3] = new SqlParameter("@valor_prodct", strValor);
                        objParamSQL[4] = new SqlParameter("@cantidad_product", intCantidad);
                        objParamSQL[5] = new SqlParameter("@id_estado", intIdEstado);
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

        #region Metodos Publico
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
                objConexion.SQL = "ProductoCRUD";
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
