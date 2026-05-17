using System.Text.Json;

namespace Domain;

public class VacancyDocument
{
    public Guid Id { get; set; }
    public string SourceUrl {get; set;}
    public string RawText { get; set; }
    public JsonDocument StructuredData { get; set; }
    public DateTime CreateAt { get; set; }
}