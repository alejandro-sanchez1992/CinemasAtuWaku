using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;

namespace libParametrosCnx
{
    public class clsParametros
    {
        #region "Constructor"
        public clsParametros()
        {
            strServidor = string.Empty;
            strBaseDatos = string.Empty;
            strUsuario = string.Empty;
            strClave = string.Empty;
            strSegInt = string.Empty;
            strArchivoXML = string.Empty;
            strCadenaCnx = string.Empty;
            strError = string.Empty;
            objDoc = new XmlDocument();
            objNodo = null;
        }
        #endregion

        #region "Atributos"
        string strServidor;
        string strBaseDatos;
        string strUsuario;
        string strClave;
        string strSegInt;
        string strArchivoXML;
        string strCadenaCnx;
        string strError;
        XmlDocument objDoc;
        XmlNode objNodo;
        #endregion

        #region "Propiedades"
        public string CadenaCnx
        {
            get
            {
                return strCadenaCnx;
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

        #region "Métodos Privados"
        public bool GenerarCadenaCnx(string PstrNombreAplicacion)
        {
            try
            {
                if (string.IsNullOrEmpty(PstrNombreAplicacion.Trim()))//si nombreaplicacion es nulo o vacio muestra error y el .trim ()elimina espacios antes y despues
                {
                    strError = "Debe enviar el nombre de la aplicación desde la cual va a realizar la conexión";
                    return false;
                }
                //si no esta vacio o nulo hace instancia al archivo y que lo cargue

                strArchivoXML = AppDomain.CurrentDomain.BaseDirectory + "\\ParametrosConexion.xml";
                objDoc.Load(strArchivoXML);

                objNodo = objDoc.SelectSingleNode("//Servidor");//selecciona lo que esta dentro del nodo servidor hace referencia a la etiqueta servidos
                strServidor = objNodo.InnerText;//captura el dato que contenga el nodo servirdor

                objNodo = objDoc.SelectSingleNode("//BaseDatos");//etiqueta base de datos
                strBaseDatos = objNodo.InnerText;

                objNodo = objDoc.SelectSingleNode("//SeguridadIntegrada");//autenticarse con windows o lsa y la seguridad no integrada es autentificacionsql server es decir usuario y contraseña
                strSegInt = objNodo.InnerText;

                if (strSegInt.ToUpper() == "SI")//de minuscula pasa a mayuscula
                {
                    strCadenaCnx = "Data Source = " + strServidor + "; Initial Catalog = " + strBaseDatos +
                        "; Integrated Security = SSPI;";
                }
                else
                {
                    objNodo = objDoc.SelectSingleNode("//Usuario");
                    strUsuario = objNodo.InnerText;
                    objNodo = objDoc.SelectSingleNode("//clave");
                    strClave = objNodo.InnerText;

                    strCadenaCnx = "Data Source = " + strServidor + "; Initial Catalog = " + strBaseDatos +
                        "; User Id = " + strUsuario + "; password = " + strClave + ";";
                }

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
