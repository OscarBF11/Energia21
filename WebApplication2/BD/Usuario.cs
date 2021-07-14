using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.BD
{
    public class Usuario
    {
        public int idUsuario;
        public string Nombre;
        public string Correo;
        public string Contraseña;
        public int RIdSitio;

        //public Sitio si;
    }
}