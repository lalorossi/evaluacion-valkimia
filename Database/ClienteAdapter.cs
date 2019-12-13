using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class ClienteAdapter:Adapter
    {
        public List<Cliente> GetAll()
        {
            List<Cliente> Clientes = new List<Cliente>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdClientes = new SqlCommand("select * from Clientes", sqlConn);

                SqlDataReader drClientes = cmdClientes.ExecuteReader();

                while (drClientes.Read())
                {
                    Cliente cl = new Cliente();
                    cl.Id = (int)drClientes["Id"];
                    cl.Nombre = (string)drClientes["Nombre"];
                    cl.Apellido = (string)drClientes["Apellido"];
                    cl.Email = (string)drClientes["Email"];
                    cl.Habilitado = (bool)drClientes["Habilitado"];
                    cl.Password = (string)drClientes["Password"];
                    cl.IdCiudad = (int)drClientes["IdCiudad"];
                    cl.Domicilio = (string)drClientes["Domicilio"];

                    Clientes.Add(cl);
                }

                drClientes.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Clientes", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
            return Clientes;
        }

        public Entidades.Cliente GetOne(int Id)
        {
            Cliente cl = new Cliente();
            try
            {
                this.OpenConnection();

                SqlCommand cmdClientes = new SqlCommand("select * from Clientes where Id = @id", sqlConn);
                cmdClientes.Parameters.Add("@id", SqlDbType.Int).Value = Id;

                SqlDataReader drClientes = cmdClientes.ExecuteReader();

                if (drClientes.Read())
                {
                    cl.Id = (int)drClientes["Id"];
                    cl.Nombre = (string)drClientes["Nombre"];
                    cl.Apellido = (string)drClientes["Apellido"];
                    cl.Email = (string)drClientes["Email"];
                    cl.Habilitado = (bool)drClientes["Habilitado"];
                    cl.Password = (string)drClientes["Password"];
                    cl.IdCiudad = (int)drClientes["IdCiudad"];
                    cl.Domicilio = (string)drClientes["Domicilio"];
                }

                drClientes.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Cliente", ex);
                throw ExcepcionManejada;
            }

            this.CloseConnection();
            return cl;
        }

        public void Delete(int Id)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete from Clientes where Id = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = Id;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el Cliente", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Update(Cliente Cliente)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE Clientes SET nombre = @nombre, Apellido = @apellido, Email = @email,"+
                    " Domicilio = @domicilio, Password = @password, Habilitado = @habilitado + IdCiudad = @idCiudad" +
                    "WHERE Id = @id", sqlConn
                );

                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Cliente.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar).Value = Cliente.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar).Value = Cliente.Email;
                cmdSave.Parameters.Add("@domicilio", SqlDbType.VarChar).Value = Cliente.Domicilio;
                cmdSave.Parameters.Add("@password", SqlDbType.VarChar).Value = Cliente.Password;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = Cliente.Habilitado;
                cmdSave.Parameters.Add("@idCiudad", SqlDbType.Int).Value = Cliente.IdCiudad;
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = Cliente.Id;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el Cliente", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Insert(Cliente Cliente)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO Clientes (Nombre, Apellido, Email, Domicilio, Habilitado, IdCiudad, Password) " +
                    "VALUES (@nombre, @apellido, @email, @domicilio, @habilitado, @idCiudad, @password) " +
                    "select @@identity", sqlConn // para recuperar el Id que se asigna en SQL automáticamente
                );

                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Cliente.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar).Value = Cliente.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar).Value = Cliente.Email;
                cmdSave.Parameters.Add("@domicilio", SqlDbType.VarChar).Value = Cliente.Domicilio;
                cmdSave.Parameters.Add("@password", SqlDbType.VarChar).Value = Cliente.Password;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = Cliente.Habilitado;
                cmdSave.Parameters.Add("@idCiudad", SqlDbType.Int).Value = Cliente.IdCiudad;
                Cliente.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar el Cliente", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }

        public void Save(Cliente Cliente)
        {
            if (Cliente.State == Entidad.States.New)
            {
                this.Insert(Cliente);
            }
            else if (Cliente.State == Entidad.States.Deleted)
            {
                this.Delete(Cliente.Id);
            }
            else if (Cliente.State == Entidad.States.Modified)
            {
                this.Update(Cliente);
            }
            Cliente.State = Entidad.States.Unmodified;
        }
        public Entidades.Cliente GetOneByUserAndPassword(string username, string pass)
        {
            Cliente cl = new Cliente();
            try
            {
                this.OpenConnection();

                SqlCommand cmdClientes = new SqlCommand("select * from Clientes where Email = @email and Password = @pass", sqlConn);
                cmdClientes.Parameters.Add("@email", SqlDbType.VarChar).Value = username;
                cmdClientes.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;

                SqlDataReader drClientes = cmdClientes.ExecuteReader();

                if (drClientes.Read())
                {
                    cl.Id = (int)drClientes["Id"];
                    cl.Nombre = (string)drClientes["Nombre"];
                    cl.Apellido = (string)drClientes["Apellido"];
                    cl.Email = (string)drClientes["Email"];
                    cl.Domicilio = (string)drClientes["Domicilio"];
                    cl.Habilitado = (bool)drClientes["Habilitado"];
                    cl.Password = (string)drClientes["Password"];
                    cl.IdCiudad = (int)drClientes["IdCiudad"];
                }

                drClientes.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Cliente", ex);
                throw ExcepcionManejada;
            }

            this.CloseConnection();
            return cl;
        }
    }
}
