namespace WebApplication2.BD
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