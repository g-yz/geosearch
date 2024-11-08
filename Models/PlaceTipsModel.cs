namespace GeoSearch.Models;

public class FoursquarePlaceTipsModel
{
    public List<FoursquareTip> Tips { get; set; }
}

public class FoursquareTip
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Text { get; set; }
    public string Url { get; set; }
    public FoursquarePhoto Photo { get; set; }
    public string Lang { get; set; }
    public int Agree_Count { get; set; }
    public int Disagree_Count { get; set; }
}

public class FoursquarePhoto
{
    public string Id { get; set; }
    public DateTime Created_At { get; set; }
    public string Prefix { get; set; }
    public string Suffix { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public List<string> Classifications { get; set; }
    public FoursquareTipDetails Tip { get; set; }
}

public class FoursquareTipDetails
{
    public string Id { get; set; }
    public DateTime Created_At { get; set; }
    public string Text { get; set; }
    public string Url { get; set; }
    public string Lang { get; set; }
    public int Agree_Count { get; set; }
    public int Disagree_Count { get; set; }
}