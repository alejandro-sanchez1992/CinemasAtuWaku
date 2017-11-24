using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace frmCinemaAtuWaku
{
    public partial class mdiPrincipal : System.Web.UI.MasterPage
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Usuario"] != null)
                    {
                        object UserSession = Session["Usuario"];
                        this.lblSessionUser.Text = UserSession.ToString();
                    }
                    else
                    {
                        Session["Usuario"] = null;
                        Response.Redirect("~/login.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/login.aspx", false);
        }
        #endregion
    }
}