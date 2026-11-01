using System.Text.RegularExpressions;

public static class HtmlParser
{
    public static async Task<string> Load(string url) => await new HttpClient().GetStringAsync(url);

    public static List<string> Split(string html) =>
        Regex.Split(Regex.Replace(html, "<!--.*?-->", "", RegexOptions.Singleline), "(<[^>]*>)")
            .Select(s => Regex.Replace(s, @"\s+", " ").Trim())
            .Where(s => s != "")
            .ToList();
}
