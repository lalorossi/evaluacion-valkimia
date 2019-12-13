using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Factura :Entidad
    {
        private int _Id;
        private int _IdCliete;
        private DateTime _Fecha;
        private string _Detalle;
        private float _Importe;

        public int Id { get => _Id; set => _Id = value; }
        public int IdCliete { get => _IdCliete; set => _IdCliete = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Detalle { get => _Detalle; set => _Detalle = value; }
        public float Importe { get => _Importe; set => _Importe = value; }
    }
}
