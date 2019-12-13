using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            //Borra al usuario de la sesion y vuelve al login (igual con viewState y context, por si a caso)
            ViewState["IdClienteActual"] = null;
            Session["IdClienteActual"] = null;
            Context.Items["IdClienteActual"] = null;
            Response.Redirect("Login.aspx");
        }
        protected void btnFacturas_Click(Object sender, EventArgs e)
        {
            Response.Redirect("Facturas.aspx");
        }
    }
}