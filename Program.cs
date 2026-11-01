Console.WriteLine($"Tags: {HtmlHelper.Instance.Tags.Length}, VoidTags: {string.Join(", ", HtmlHelper.Instance.VoidTags)}");
Console.WriteLine($"Same instance: {ReferenceEquals(HtmlHelper.Instance, HtmlHelper.Instance)}");
