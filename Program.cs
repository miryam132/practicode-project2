var root = HtmlParser.Parse(await HtmlParser.Load("https://pypi.org"));
var all = root.Descendants().ToList();
Console.WriteLine($"Descendants: {all.Count}");
var deepest = all.MaxBy(e => e.Ancestors().Count())!;
Console.WriteLine($"Deepest: {deepest}");
Console.WriteLine("Ancestors: " + string.Join(" <- ", deepest.Ancestors()));
