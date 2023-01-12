namespace poc_blazor.Infrastructure
{
    public static class LocalizerSettings
    {
        public const string NeutralCulture = "nl-BE";
        public static readonly string[] SupportedCultures = { NeutralCulture, "en-UK" };
        public static readonly (string, string)[] SupportedCulturesWithNames = new[] { ("Nederlands", NeutralCulture), ("English", "en-UK") };
    }
}
