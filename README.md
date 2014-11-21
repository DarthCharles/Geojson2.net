Geojson.net
===========

Librería para transformar código de C# en formato Geojson.

Ejemplo: 

 ```
 public Geojson getGeofence(int geocercaiID)

        {

            Geojson Polygon = new Geojson();
 
            List<Feature> features = new List<Feature>();
            
            //PoligonContainer es una lista de listas de coordenadas,
            aquí coordenadasPoligono ya fué inicializado
            polygonContainer.Add(coordenadasPoligono);

            Feature polygon = new Feature();
            polygon.type = "Feature";
            polygon.geometry = new Geometry
            {
                type = "Polygon",
                coordinates = polygonContainer
            };
            polygon.properties = new PolygonProperties()
            {
            "FeatureType": Polygon,
            idGeocerca = 97,
            Nombre = "Casa de Miguelito",
            Color = "#fff"

            };

             features.Add(polygon);


            Polygon.type = "FeatureCollection";
            Polygon.features = features;

            return Polygon;
        }
```        
y el Resultado es:
```        
{
  "type": "FeatureCollection",
  "features": [
    {
      "type": "Feature",
      "geometry": {
        "type": "Polygon",
        "coordinates": [
          [
            [
              -110.997977200896,
              29.1092151815806
            ],
            [
              -110.99763924256,
              29.1092198684403
            ],
            [
              -110.997633878142,
              29.1087230601246
            ],
            [
              -110.997966472059,
              29.1087558682948
            ]
          ]
        ]
      },
      "properties": {
        "FeatureType": Polygon,
        "idGeocerca": "97",
        "Nombre": "Casa de Miguelito",
        "Color": "#fff"
      }
    }
  ]
}
```
