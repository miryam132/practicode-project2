using System.Text.Json;

public class HtmlHelper
{
    public static HtmlHelper Instance { get; } = new();

    public string[] Tags { get; }
    public string[] VoidTags { get; }

    private HtmlHelper()
    {
        Tags = Load("HtmlTags.json");
        VoidTags = Load("HtmlVoidTags.json");
    }

    private static string[] Load(string file) => JsonSerializer.Deserialize<string[]>(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, file)))!;
}
