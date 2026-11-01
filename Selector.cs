using System.Text.RegularExpressions;

public class Selector
{
    public string? TagName { get; set; }
    public string? Id { get; set; }
    public List<string> Classes { get; } = new();
    public Selector? Parent { get; set; }
    public Selector? Child { get; set; }

    public static Selector Parse(string query)
    {
        Selector? first = null, current = null;
        foreach (var part in query.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            var selector = new Selector { Parent = current };
            foreach (var token in Regex.Matches(part, @"[#.]?[^#.]+").Select(m => m.Value))
            {
                if (token[0] == '#') selector.Id = token[1..];
                else if (token[0] == '.') selector.Classes.Add(token[1..]);
                else if (HtmlHelper.Instance.Tags.Contains(token)) selector.TagName = token;
            }
            if (current != null) current.Child = selector;
            first ??= selector;
            current = selector;
        }
        return first!;
    }
}
