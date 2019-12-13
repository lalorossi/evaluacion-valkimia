using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class FacturaAdapter:Adapter
    {
        public void Insert(Factura Factura)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO Facturas (Id, IdCliente, Fecha, Importe, Detalle) " +
                    "VALUES (@id, @idCliente, @fecha, @importe, @detalle) " +
                    "select @@identity", sqlConn // para recuperar el Id que se asigna en SQL automáticamente
                );

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = Factura.IdCliete;
                cmdSave.Parameters.Add("@idCliente", SqlDbType.Int).Value = Factura.Id;
                cmdSave.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Factura.Fecha;
                cmdSave.Parameters.Add("@importe", SqlDbType.Decimal).Value = Factura.Importe;
                cmdSave.Parameters.Add("@detalle", SqlDbType.VarChar).Value = Factura.Detalle;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar la Factura", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
    }
}
