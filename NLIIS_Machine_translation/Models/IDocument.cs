using MongoDB.Bson;

namespace NLIIS_Machine_translation.Models
{
    public interface IDocument
    {
        ObjectId Id { get; }
    }
}