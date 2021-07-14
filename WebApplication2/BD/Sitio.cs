using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.BD
{
    public class Sitio
    {
        public int IdSitio;
        public string Nombre;
        public string Tipo;
        public int RidElectrodomestico;
        public int RidTarifa;

        public Electrodomestico IdElectrodomestico;
        public Tarifa IdTarifa;
    }
}