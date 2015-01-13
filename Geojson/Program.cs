using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geojson
{
    class venus
    {
        public string MyProperty { get; set; }
        public string MyProperty1 { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {


            List<double> coordenadas = new List<double> {
              -110.96410274505615,
              29.077048924872127,
             -110.96410274505615,
              29.0780053385589,
              -110.96272945404053,
              29.0780053385589,
              -110.96272945404053,
              29.077048924872127,
              -110.96410274505615,
              29.077048924872127
        };




            List<LatLng> Coordinates = new List<LatLng>();

            for (int i = 0; i < coordenadas.Count - 1; i += 2)
            {
                Coordinates.Add(new LatLng(coordenadas[i + 1], coordenadas[i]));
            }

            Geojson a = new Point(Coordinates, "Point");

            string json = JsonConvert.SerializeObject(a, Formatting.Indented);
            Debug.WriteLine(json);
            using (StreamWriter writer = new StreamWriter("C:\\Carlos\\important.json"))
            {
                writer.Write(json);

            }
        }
    }
}
