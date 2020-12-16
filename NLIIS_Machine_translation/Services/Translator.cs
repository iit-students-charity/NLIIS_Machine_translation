using Google.Cloud.Translation.V2;

namespace NLIIS_Machine_translation.Services
{
    public static class Translator
    {
        private static TranslationClient _translateService;

        static Translator()
        {
            _translateService = TranslationClient.Create();
        }

        public static string TranslateText(string text)
        {
            var response = _translateService.TranslateText(text, "de", "en");
            return response.TranslatedText;
        }
    }
}
