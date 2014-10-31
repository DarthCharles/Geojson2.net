using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geojson
{
    class Program
    {

        private static string cadena_Conexion = "Data Source=java.isi.uson.mx;Initial Catalog=DIDCOMDDAY;User ID=Alien;Password=Pringles92";

        public Geojson obtener_DatosGPS()
        {

            Geojson a = new Geojson();


            DataTable dataT = new DataTable();
            using (SqlConnection conn = new SqlConnection(cadena_Conexion))
            {
                string query = "select  * from DatosGPS inner join RecorridoDatosGPS on DatosGPS.iID = RecorridoDatosGPS.DatosGPSId  where RecorridoDatosGPS.RecorridoId = 21586 order by iID asc ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataT);



                    List<List<double>> multiple = new List<List<double>>();
                    foreach (DataRow row in dataT.Rows)
                    {

                        List<double> lista = new List<double>();
                        lista.Add(Double.Parse(row["Longitud"].ToString()));
                        lista.Add(Double.Parse(row["Latitud"].ToString()));
                        multiple.Add(lista);

                    }


                    a.type = "FeatureCollection";
                    a.features = new List<Feature>()
                    {
                        new Feature(){
                        type = "Feature",
                        geometry = new Geometry{
                        type = "MultiPoint",
                        coordinates = multiple
                        },

                        properties = new Properties(){
                        
                            name = "Recorrido Mex-Toluca"
                        }

                        },

                        new Feature(){
                        type = "Feature",
                        geometry = new Geometry{
                        type = "LineString",
                        coordinates = multiple
                        },

                        properties = new Properties(){
                        
                            name = "Recorrido Mex-Toluca"
                        }

                        }


                    };



                    conn.Close();
                }
            }
            return a;
        }
        static void Main(string[] args)
        {
            Program jsona = new Program();

            //    List<List<double>> multiple = new List<List<double>>();
            //    List<double> coordenadas = new List<double> {
            //  -110.971301,   29.098372,
            //  -110.971145,  29.097343,
            // -110.970974,   29.096256, 
            //  -110.970809,   29.095217,
            //   -110.970620,  29.094172,
            //  -110.970447,   29.093150,
            //-110.970270,    29.092086, 
            //  -110.970099,   29.091031,
            //  -110.969927,   29.090140,
            //-110.968806,    29.089460, 
            // -110.967792,    29.089001,
            //   -110.966786,  29.088598,
            // -110.965806,    29.088233,
            //   -110.964837,  29.087841,
            //  -110.963951,  29.087124, 
            // -110.962905,   29.086130, 
            //    -110.961736, 29.085047,
            //  -110.960322,   29.084261,
            //  -110.959705 ,  29.083658
            //};


            //    for (int i = 0; i < coordenadas.Count - 1; i++)
            //    {
            //        List<double> lista = new List<double>();
            //        lista.Add(coordenadas[i]);
            //        lista.Add(coordenadas[i + 1]);
            //        multiple.Add(lista);
            //        i++;
            //    }
            //    Geojson a = new Geojson();
            //    a.type = "GeometryCollection";
            //    a.geometries = new List<geometry>
            //        {
            //            new geometry
            //            {
            //              type = "LineString",
            //              coordinates = multiple
            //            },

            //            new geometry
            //           {
            //              type = "MultiPoint",
            //             coordinates = multiple
            //            }
            //        };
            //    a.properties = new properties
            //    {
            //        name = "a que truena"
            //    };

            string json = JsonConvert.SerializeObject(jsona.obtener_DatosGPS(), Formatting.Indented);
            Debug.WriteLine(json);
            //Console.WriteLine(json);
            //Console.Read();
        }

        //        Product product = new Product();
        //product.Name = "Apple";
        //product.Expiry = new DateTime(2008, 12, 28);
        //product.Sizes = new string[] { "Small" };

        //string json = JsonConvert.SerializeObject(product);
        //{
        //  "Name": "Apple",
        //  "Expiry": "2008-12-28T00:00:00",
        //  "Sizes": [
        //    "Small"
        //  ]
        //}
        //{
        //  "type": "Feature",
        //  "geometry": {
        //    "type": "Point",
        //    "coordinates": [125.6, 10.1]
        //  },
        //  "properties": {
        //    "name": "Dinagat Islands"
        //  }
        //}

        //        {
        //    "type": "Feature",
        //    "geometry": {
        //        "type": "Point",
        //        "coordinates": ["125.6", "10.1"]
        //    },
        //    "properties": {
        //        "name": "a que truena"
        //    }
        //}
    }
}
