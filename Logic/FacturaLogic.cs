using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Database;
namespace Logic
{
    public class FacturaLogic
    {
        public FacturaAdapter facturaData;
        public FacturaLogic()
        {
            facturaData = new FacturaAdapter();
        }

        public void Save(Factura factura)
        {
            facturaData.Insert(factura);
        }
    }
}
