using System.Linq;
using System.Text.RegularExpressions;
using NLIIS_Machine_translation.Models;

namespace NLIIS_Machine_translation.Services
{
    public static class DictionaryService
    {
        public static void AddFromFile(string path)
        {
            var text = DocumentService.FromFile(path);

            var rows = text.Split("\n")
                .Where(pair => !pair.Equals("\r"))
                .Where(pair => !pair.Equals(string.Empty));
            var originals = rows.Where((row, index) => index % 2 == 0);
            var translations = rows.Where((row, index) => index % 2 != 0);

            var translatables = originals.Select((original, index) =>
            {
                var partOfSpeech = Regex.Match(original, PartOfSpeech.Regex).Value;
                var originalAdjusted = original;
                
                if (!partOfSpeech.Equals(string.Empty))
                {
                    originalAdjusted = original.Replace(partOfSpeech, string.Empty).Trim();
                }
                else
                {
                    partOfSpeech = null;
                }
                
                var translatable = new Translatable
                {
                    Original = originalAdjusted.Replace("\r", string.Empty),
                    Translated = translations.ElementAt(index).Replace("\r", string.Empty),
                    PartOfSpeech = partOfSpeech
                };

                return translatable;
            });

            foreach (var translatable in translatables)
            {
                MongoDBConnector.Add(translatable);
            }
        }
    }
}
