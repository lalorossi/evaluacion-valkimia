using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Cliente:Entidad
    {
        private int _Id;
        private string _Nombre;
        private string _Apellido;
        private string _Domicilio;
        private string _Email;
        private string _Password;
        private int _IdCiudad;
        private bool _Habilitado;

        public int Id { get => _Id; set => _Id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Domicilio { get => _Domicilio; set => _Domicilio = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Password { get => _Password; set => _Password = value; }
        public int IdCiudad { get => _IdCiudad; set => _IdCiudad = value; }
        public bool Habilitado { get => _Habilitado; set => _Habilitado = value; }
    }
}
