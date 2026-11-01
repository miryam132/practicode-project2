var parts = HtmlParser.Split(await HtmlParser.Load("https://pypi.org"));
Console.WriteLine($"Count: {parts.Count}");
parts.Take(25).ToList().ForEach(Console.WriteLine);
