public static class Extensions
{
    public static HashSet<HtmlElement> FindElements(this HtmlElement root, Selector selector)
    {
        var result = new HashSet<HtmlElement>();
        Find(root, selector, result);
        return result;
    }

    private static void Find(HtmlElement element, Selector selector, HashSet<HtmlElement> result)
    {
        foreach (var e in element.Descendants().Where(e => Matches(e, selector)))
            if (selector.Child == null) result.Add(e);
            else Find(e, selector.Child, result);
    }

    private static bool Matches(HtmlElement e, Selector s) =>
        (s.TagName == null || s.TagName == e.Name) &&
        (s.Id == null || s.Id == e.Id) &&
        s.Classes.All(e.Classes.Contains);
}
