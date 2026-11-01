var root = HtmlParser.Parse(await HtmlParser.Load("https://pypi.org"));
string[] queries = ["div", "a", "li", "#content", "#search", ".dropdown__link", ".sr-only", "div.site-menu", "form#search-form.search-form",
                    "nav.horizontal-menu", "div span", "footer a", "div div", "ul li a", "header .site-container", "main .container p"];
foreach (var query in queries)
    Console.WriteLine($"{query} = {root.FindElements(Selector.Parse(query)).Count}");
