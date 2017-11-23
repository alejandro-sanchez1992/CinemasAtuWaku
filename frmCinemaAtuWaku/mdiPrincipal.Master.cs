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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Usuario"] != null)
                    {
                        //UserDTO User = ((UserDTO)Session["User"]);
                        //this.lblUser.Text = string.Format("{0} {1}", User.FirstName, User.LastName);
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
    }
}