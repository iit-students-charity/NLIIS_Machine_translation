namespace NLIIS_Machine_translation.Models
{
    public interface ITranslatable
    {
        string Original { get; set; }
        string Translated { get; set; }
        string PartOfSpeech { get; set; }
    }
}