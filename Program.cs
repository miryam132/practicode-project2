var html = await HtmlParser.Load("https://pypi.org");
Console.WriteLine(html[..500]);
