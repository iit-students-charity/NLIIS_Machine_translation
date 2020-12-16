using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NLIIS_Machine_translation.Models
{
    public class Translatable : ITranslatable, IDocument
    {
        public ObjectId Id { get; set; }
        public string Original { get; set; }
        public string Translated { get; set; }
        
        // Cos phrases can be translated too
        [BsonIgnoreIfNull]
        public string PartOfSpeech { get; set; }
    }
}