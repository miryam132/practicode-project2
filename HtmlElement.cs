public class HtmlElement
{
    public string Name { get; set; } = "";
    public Dictionary<string, string> Attributes { get; set; } = new();
    public string? Id => Attributes.GetValueOrDefault("id");
    public string[] Classes => Attributes.GetValueOrDefault("class", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
    public string InnerHtml { get; set; } = "";
    public HtmlElement? Parent { get; set; }
    public List<HtmlElement> Children { get; } = new();

    public IEnumerable<HtmlElement> Descendants()
    {
        var queue = new Queue<HtmlElement>(Children);
        while (queue.Count > 0)
        {
            var element = queue.Dequeue();
            yield return element;
            element.Children.ForEach(queue.Enqueue);
        }
    }

    public IEnumerable<HtmlElement> Ancestors()
    {
        for (var p = Parent; p != null; p = p.Parent) yield return p;
    }

    public override string ToString() => Name + (Id is null ? "" : "#" + Id) + string.Concat(Classes.Select(c => "." + c));
}
