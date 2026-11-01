var root = HtmlParser.Parse(await HtmlParser.Load("https://pypi.org"));
foreach (var query in new[] { "div", "#content", ".dropdown__link", "div.site-menu", "div span", "footer a", "div div" })
{
    var found = root.FindElements(Selector.Parse(query));
    Console.WriteLine($"{query,-16} {found.Count,4}  {string.Join("  ", found.Take(3))}");
}
