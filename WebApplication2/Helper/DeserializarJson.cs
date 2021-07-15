using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication2.BD;

namespace WebApplication2.Helper
{
    public class DeserializarJson
    {
        public void RecibirDocumentoJson1()
        {
            FacturacionJson facturacionJson;
            string token = "d46d1a004ce915a690b2b7a3899a3ed546d33310482a121246ab9e58de4510d9";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.esios.ree.es/indicators/1001?start_date=2016-03-29T00:00:00&end_date=2016-03-29T23:50:00");
            HttpWebRequest request = crearRequestHttp(token);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                facturacionJson = JsonConvert.DeserializeObject<FacturacionJson>(json);
            }
            Console.WriteLine("El precio a las 00:00 era de: " + facturacionJson.ToString());
        }

        private static HttpWebRequest crearRequestHttp(string accessToken)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            HttpWebRequest request;

            request = WebRequest.Create(
                    "https://api.esios.ree.es/indicators/1001?start_date=2016-03-29T00:00:00&end_date=2016-03-29T23:50:00")
                as HttpWebRequest;
            request.Timeout = 10 * 1000;
            request.Method = "GET";
            request.Accept = "application/json; application/vnd.esios-api-v1+json";
            request.ContentType = "application/json; charset=utf-8";
            request.Host = "api.esios.ree.es";


            request.Headers.Add("Authorization", "Token token=" + accessToken);


           /* HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string resp = reader.ReadToEnd();

            Console.WriteLine(resp);*/
           return request;
        }
    }

    
}
