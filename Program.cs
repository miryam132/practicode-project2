foreach (var query in new[] { "div", "#main", ".big", "div#main.big.red", "div .x span" })
{
    var parts = new List<string>();
    for (var s = Selector.Parse(query); s != null; s = s.Child)
        parts.Add($"[Tag={s.TagName}, Id={s.Id}, Classes={string.Join(",", s.Classes)}, Parent={(s.Parent == null ? "-" : "yes")}]");
    Console.WriteLine($"{query,-18} => {string.Join(" -> ", parts)}");
}
