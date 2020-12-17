using System.Collections.Generic;
using System.Linq;
using Google.Cloud.Translation.V2;
using NLIIS_Machine_translation.Models;

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

        public static IEnumerable<Translatable> TranslateWords(IEnumerable<string> words)
        {
            return words.Select(word => new Translatable 
            {
                Original = word,
                Translated = _translateService.TranslateText(word, "de", "en").TranslatedText,
                PartOfSpeech = null
            });
        }

        public static IEnumerable<Translatable> TranslateItemsFromDB(string text)
        {
            var dbTranslatables = MongoDBConnector.GetAll<Translatable>().AsEnumerable();
            var translatedItems = dbTranslatables
                .Where(dbTranslatable => text.Contains(dbTranslatable.Original));

            return translatedItems;
        }
    }
}
