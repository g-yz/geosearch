namespace GeoSearch.Models;

public class SearchModel
{
    public string Location { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Limit { get; set; }
    public FoursquareResponse Response { get; set; } = new FoursquareResponse();
}

public class FoursquareResponse
{
    public List<PlaceModel> Results { get; set; } = new List<PlaceModel>();
    public ContextModel Context { get; set; }
}

// Places

public class PlaceModel
{
    public string Fsq_id { get; set; }
    public string Name { get; set; }
    public Geocode Geocodes { get; set; }
    public List<Category> Categories { get; set; }
    public Location Location { get; set; }
}

public class Geocode
{
    public CoordinateModel Main { get; set; }
}


// Context

public class ContextModel
{
    public GeoBoundsModel Geo_bounds { get; set; }
}

public class GeoBoundsModel
{
    public CircleModel Circle { get; set; }
}

public class CircleModel
{
    public CoordinateModel Center { get; set; }
    public double Radius { get; set; }
}

public class CoordinateModel
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
