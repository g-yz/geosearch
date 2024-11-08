namespace GeoSearch.Models;

public class FoursquarePlaceImagesModel
{
    public List<PlaceImage> Images { get; set; } = new List<PlaceImage>();
}

public class PlaceImage
{
    public string Id { get; set; }
    public DateTime Created_At { get; set; }
    public string Prefix { get; set; }
    public string Suffix { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public List<string> Classifications { get; set; } = new List<string>();
    public Tip Tip { get; set; }
}

public class Tip
{
    public string Id { get; set; }
    public DateTime Created_At { get; set; }
    public string Text { get; set; }
    public string Url { get; set; }
    public string Lang { get; set; }
    public int Agree_Count { get; set; }
    public int Disagree_Count { get; set; }
}
