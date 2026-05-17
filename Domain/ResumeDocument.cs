using System.Text.Json;

namespace Domain;

public class ResumeDocument
{
    public Guid  Id { get; set; }
    public string SourceType { get; set; }
    public string RawText { get; set; }
    public JsonDocument StructuredData  { get; set; }
    public string Language { get; set; }
    public string ProcesingStatus  { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
