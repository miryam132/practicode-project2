using System.Text.RegularExpressions;

public static class HtmlParser
{
    public static async Task<string> Load(string url) => await new HttpClient().GetStringAsync(url);

    public static List<string> Split(string html)
    {
        html = Regex.Replace(html, "<!--.*?-->", "", RegexOptions.Singleline);
        html = Regex.Replace(html, @"(<(script|style)[^>]*>).*?(</\2>)", "$1$3", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        return Regex.Split(html, "(<[^>]*>)")
            .Select(s => Regex.Replace(s, @"\s+", " ").Trim())
            .Where(s => s != "")
            .ToList();
    }

    public static HtmlElement Parse(string html)
    {
        var root = new HtmlElement { Name = "document" };
        var current = root;
        foreach (var s in Split(html))
        {
            var m = Regex.Match(s, @"^<(/?)([\w-]+)(.*?)(/?)>$");
            var name = m.Groups[2].Value.ToLower();
            if (!m.Success || !HtmlHelper.Instance.Tags.Contains(name)) { current.InnerHtml = s; continue; }

            if (m.Groups[1].Value == "/")
            {
                if (name == "html") break;
                current = current.Parent ?? root;
                continue;
            }

            var element = new HtmlElement
            {
                Name = name,
                Parent = current,
                Attributes = Regex.Matches(m.Groups[3].Value, @"([^\s=""]+)=""([^""]*)""")
                    .DistinctBy(a => a.Groups[1].Value)
                    .ToDictionary(a => a.Groups[1].Value, a => a.Groups[2].Value)
            };
            current.Children.Add(element);
            if (m.Groups[4].Value != "/" && !HtmlHelper.Instance.VoidTags.Contains(name)) current = element;
        }
        return root;
    }
}
