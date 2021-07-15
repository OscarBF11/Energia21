using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.BD
{
    public class FacturacionJson
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Magnitud
        {
            public string name { get; set; }
            public int id { get; set; }
        }

        public class Tiempo
        {
            public string name { get; set; }
            public int id { get; set; }
        }

        public class Geo
        {
            public int geo_id { get; set; }
            public string geo_name { get; set; }
        }

        public class Value
        {
            public double value { get; set; }
            public DateTime datetime { get; set; }
            public DateTime datetime_utc { get; set; }
            public DateTime tz_time { get; set; }
            public int geo_id { get; set; }
            public string geo_name { get; set; }
        }

        public class Indicator
        {
            public string name { get; set; }
            public string short_name { get; set; }
            public int id { get; set; }
            public bool composited { get; set; }
            public string step_type { get; set; }
            public bool disaggregated { get; set; }
            public List<Magnitud> magnitud { get; set; }
            public List<Tiempo> tiempo { get; set; }
            public List<Geo> geos { get; set; }
            public DateTime values_updated_at { get; set; }
            public List<Value> values { get; set; }
        }

        public class Root
        {
            public Indicator indicator { get; set; }
        }


    }
}
