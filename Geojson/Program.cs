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
     class Program
    {

        static void Main(string[] args)
        {


            List<LatLng> Coordinates = new List<LatLng>();
            Coordinates.Add(new LatLng(41.02135510866602, -471.06079101562506));
            Coordinates.Add(new LatLng(45.01141864227728, -471.06079101562506));
            Coordinates.Add(new LatLng(45.01141864227728, -464.08447265625));
            Coordinates.Add(new LatLng(41.02135510866602, -464.08447265625));
            Coordinates.Add(new LatLng(41.02135510866602, -471.06079101562506));

            Geojson MyPolygon = new LineString(Coordinates);

            string json = JsonConvert.SerializeObject(MyPolygon, Formatting.Indented);
            Debug.WriteLine(json);
            using (StreamWriter writer = new StreamWriter("C:\\Carlos\\important.json"))
            {
                writer.Write(json);

            }
        }
    }
}
