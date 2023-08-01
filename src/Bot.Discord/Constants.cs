using System.Drawing;

namespace Bot.Discord;

public class Constants
{
    // Todo: Replace the publicKey and the botId with yours. https://discord.com/developers/applications.
    public const string PublicKey = "e3bd2ee1b27eb22bd2bebdd00244e5d80149ac13f27095b7fb57579030c68036";
    public const long BotId = 1130228686973583541;

    public const string ArgsSeparator = ";";
    public const string SlashPrefix = "/";

    public static class Colors
    {
        public static readonly Color Error = Color.Red;
        public static readonly Color Successful = Color.LawnGreen;
        public static readonly Color Neutral = Color.White;
    }
}