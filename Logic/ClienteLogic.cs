using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Database;

namespace Logic
{
    public class ClienteLogic
    {
        public ClienteAdapter clienteData;
        public ClienteLogic()
        {
            clienteData = new ClienteAdapter();
        }
        public Cliente GetOne(int idCliente)
        {
            return clienteData.GetOne(idCliente);
        }
        public List<Cliente> GetAll()
        {
            return clienteData.GetAll();
        }
        public void Save(Cliente cliente)
        {
            clienteData.Save(cliente);
        }
        public void Delete(int idCliente)
        {
            clienteData.Delete(idCliente);
        }
        public Cliente GetOneByUserAndPassword(string username, string password)
        {
            return clienteData.GetOneByUserAndPassword(username, password);
        }
    }
}
