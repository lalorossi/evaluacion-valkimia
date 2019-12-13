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
    public partial class WebForm1 : System.Web.UI.Page
    {

        FacturaLogic facturaLogic = new FacturaLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteLogic clientes = new ClienteLogic();
            this.dropClientes.DataSource = clientes.GetAll();
            this.dropClientes.DataTextField = "Nombre";
            this.dropClientes.DataValueField = "ID";
            this.dropClientes.DataBind();
            for(int i = 0; i<dropClientes.Items.Count; i++)
            {
                ClienteLogic clienteLogic = new ClienteLogic();
                Cliente cliente = clienteLogic.GetOne(int.Parse(dropClientes.Items[i].Value));
                string nombre = cliente.Nombre;
                string apellido = cliente.Apellido;
                dropClientes.Items[i].Text = nombre + " " + apellido;
            }

        }
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            Factura factura = new Factura();
            factura.Id = int.Parse(idTextBox.Text);
            factura.IdCliete = int.Parse(this.dropClientes.SelectedValue);
            factura.Fecha = DateTime.Parse(this.fechaTextBox.Text);
            factura.Importe = int.Parse(this.importeTextBox.Text);
            factura.Detalle = this.DetalleTextBox.Text;

            try
            {
                new FacturaLogic().Save(factura);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            Notificar("Factura guardada");
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.dropClientes.SelectedIndex = 0;
            this.fechaTextBox.Text = string.Empty;
            this.importeTextBox.Text = string.Empty;
            this.DetalleTextBox.Text = string.Empty;
        }

        public void Notificar(string msj)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.Title, "alert('" + msj + "')", true);
        }
    }
}