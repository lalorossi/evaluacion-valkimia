using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logic;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {

        public int IdClienteActual
        {
            get
            {
                if (this.Session["IdClienteActual"] != null)
                {
                    return (int)this.Session["IdClienteActual"];
                }
                else
                {
                    return 0;
                }
            }
            set { this.Session["IdClienteActual"] = value; }
        }

        ClienteLogic _clienteLogic;
        private  ClienteLogic clienteLogic
        {
            get
            {
                if(_clienteLogic == null)
                {
                    _clienteLogic = new ClienteLogic();
                }
                return _clienteLogic;
            }
            set
            {
                _clienteLogic = value;
            }
        }

        private Cliente clienteActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Si hay un usuario logueado, lo manda a su main por tipo de usuario
            if (this.IdClienteActual != 0)
            {
                ClienteLogic clicli = new ClienteLogic();
                //Response.Redirect("Main.aspx");
                Notificar("Usuario ya loggeado. Cierre sesión para cambiar de usuario");
            }
            if (!this.IsPostBack)
            {
                this.txtCliente.Text = "";
                this.txtPassword.Text = "";
            }
            // this.txtCliente.Focus();
        }
        public bool LogTry()
        {
            this.clienteActual = clienteLogic.GetOneByUserAndPassword(this.txtCliente.Text, this.txtPassword.Text);
            if (this.clienteActual.Id > 0)
            {
                Session["IdClienteActual"] = this.clienteActual.Id;
                return true;
            }
            this.Notificar("Usuario y contraseña incorrectos");
            return false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.LogTry())
            {
                // Server.Transfer("MainAlumno.aspx");
                Notificar("Usuario loggeado");
            }
        }

        public void Notificar(string msj)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.Title, "alert('" + msj + "')", true);
        }
    }
}