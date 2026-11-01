var root = HtmlParser.Parse(await HtmlParser.Load("https://pypi.org"));
Print(root, 0);

void Print(HtmlElement element, int depth)
{
    Console.WriteLine(new string(' ', depth * 2) + element + (element.InnerHtml == "" ? "" : $"  \"{element.InnerHtml}\""));
    element.Children.ForEach(c => Print(c, depth + 1));
}
