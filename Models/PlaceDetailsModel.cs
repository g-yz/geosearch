namespace GeoSearch.Models;

public class FoursquarePlaceDetailsModel
{
    public string Fsq_Id { get; set; }
    public List<Category> Categories { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string Fax { get; set; }
    public Geocodes Geocodes { get; set; }
    public Hours Hours { get; set; }
    public string Link { get; set; }
    public Location Location { get; set; }
    public string Menu { get; set; }
    public string Name { get; set; }
    public List<Photo> Photos { get; set; }
    public int Popularity { get; set; }
    public int Price { get; set; }
    public int Rating { get; set; }
    public SocialMedia Social_Media { get; set; }
    public Stats Stats { get; set; }
    public string Tel { get; set; }
    public string Timezone { get; set; }
    public bool Verified { get; set; }
    public string Website { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Short_Name { get; set; }
    public string Plural_Name { get; set; }
    public Icon Icon { get; set; }
}

public class Icon
{
    public string Id { get; set; }
    public DateTime Created_At { get; set; }
    public string Prefix { get; set; }
    public string Suffix { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public List<string> Classifications { get; set; }
    public Tip Tip { get; set; }
}

public class Geocodes
{
    public LocationCoordinates Main { get; set; }
}

public class LocationCoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class Hours
{
    public string Display { get; set; }
    public bool Is_Local_Holiday { get; set; }
    public bool Open_Now { get; set; }
    public List<Hour> Regular { get; set; }
}

public class Hour
{
    public string Close { get; set; }
    public int Day { get; set; }
    public string Open { get; set; }
}

public class Location
{
    public string Address { get; set; }
    public string Address_Extended { get; set; }
    public string Admin_Region { get; set; }
    public string Census_Block { get; set; }
    public string Country { get; set; }
    public string Cross_Street { get; set; }
    public string Dma { get; set; }
    public string Formatted_Address { get; set; }
    public string Locality { get; set; }
    public List<string> Neighborhood { get; set; }
    public string Po_Box { get; set; }
    public string Post_Town { get; set; }
    public string Postcode { get; set; }
    public string Region { get; set; }
}

public class Photo
{
    public string Id { get; set; }
    public DateTime Created_At { get; set; }
    public string Prefix { get; set; }
    public string Suffix { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public List<string> Classifications { get; set; }
    public Tip Tip { get; set; }
}

public class SocialMedia
{
    public string Facebook_Id { get; set; }
    public string Instagram { get; set; }
    public string Twitter { get; set; }
}

public class Stats
{
    public int Total_Photos { get; set; }
    public int Total_Ratings { get; set; }
    public int Total_Tips { get; set; }
}
