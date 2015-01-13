Geojson.net
===========

##Summary
Geojson.net2 is an alternative library for transforming a C# object into a Geojson Object

##Installation
To start using this libraty all you have to do is install the [GeoJSON.Net2](https://www.nuget.org/packages/GeoJson.net2/) NuGet package:

`PM> Install-Package GeoJson.net2`



##How to use it
Example: Just create a geojson object (Point, Polygon or LineString) and pass a coordinates list as an argument. 

 ```
 public Geojson MyPolygon ()

        {

            List<LatLng> Coordinates = new List<LatLng>();
            Coordinates.Add(new LatLng(41.02135510866602, -471.06079101562506));
            Coordinates.Add(new LatLng(45.01141864227728, -471.06079101562506));
            Coordinates.Add(new LatLng(45.01141864227728, -464.08447265625));
            Coordinates.Add(new LatLng(41.02135510866602, -464.08447265625));
            Coordinates.Add(new LatLng(41.02135510866602, -471.06079101562506));

            return new Polygon(Coordinates);
        }
```        
you can send the geojson object as an ajax result and use it in your js code, or if you prefer it you can use [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) to serialize it and get this result:
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
              -471.06079101562506,
              41.021355108666022
            ],
            [
              -471.06079101562506,
              45.011418642277278
            ],
            [
              -464.08447265625,
              45.011418642277278
            ],
            [
              -464.08447265625,
              41.021355108666022
            ],
            [
              -471.06079101562506,
              41.021355108666022
            ]
          ]
        ]
      },
      "properties": {
        "FeatureType": "Polygon",
        "Color": "#3289c7"
      }
    }
  ]
}

```

##Thank you!
