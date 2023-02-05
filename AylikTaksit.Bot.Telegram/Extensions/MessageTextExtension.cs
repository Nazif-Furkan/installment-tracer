namespace AylikTaksit.Bot.Telegram.Extensions;

public static class MessageTextExtension
{
    /// <summary>
    /// Uses String.StartWith command with invariantCultureIgnoreCase in default
    /// </summary>
    /// <param name="text"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static bool SW(this string text, string content) =>
        text.Trim().StartsWith(content, StringComparison.InvariantCultureIgnoreCase);
}