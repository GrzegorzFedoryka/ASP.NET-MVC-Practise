namespace CarWorkshop.MVC.Models;

public class AboutModel
{
    public AboutModel(string? title, string? description, string[] tags)
    {
        Title = title;
        Description = description;
        Tags = tags;
    }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public string[] Tags { get; set; }

    public override string ToString()
    {
        return Title + " " + Description + $" Tags: {string.Join(", ", Tags)}";
    }
}