public static class HtmlParser
{
    public static async Task<string> Load(string url) => await new HttpClient().GetStringAsync(url);
}
