namespace NLIIS_Machine_translation.Models
{
    public class PartOfSpeech
    {
        public static string Regex => 
            $"{Verb}|{Adjective}|{Noun}|{Pronoun}|{Adverb}|{Preposition}|{Conjunctions}|{Interjections}"
            .Replace(".", @"\.");
        
        public const string Verb = "v.";
        public const string Adjective = "adj.";
        public const string Noun = "n.";
        public const string Pronoun = "pron.";
        public const string Adverb = "adv.";
        public const string Preposition = "prep.";
        public const string Conjunctions = "c.";
        public const string Interjections = "i.";
    }
}