using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace libLogin
{
    public class clsLogin
    {
        #region "Constructo"
        public  clsLogin ()
        {
            strUsuario = string.Empty;
            strPassword = string.Empty;
        }
        #endregion

        #region "Atributos"
        private string strUsuario;
        private string strPassword;
        private string strError;

        #endregion

        #region "Propiedades"
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

        #endregion

        #region "Métodos Privados"

        private bool Validar()
        {
            try
            {
                if(strUsuario==null)
                {
                    strError = "Ingrese Usuario";
                }
                if(strPassword == null)
                {
                    strError = "Ingrese contraseña";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }

        #endregion

    }
}
