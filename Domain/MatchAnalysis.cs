using System.Text.Json;

namespace Domain;

public class MatchAnalysis
{
    public Guid id { get; set; }
    public Guid ResumeDocumentID { get; set; }
    public Guid VacancyDocumentId { get; set; }
    public float GlobalScore { get; set; }
    public float SemanticScore { get; set; }
    public float TechnicalScore { get; set; }
    public JsonDocument MissingSkills { get; set; }
    public JsonDocument MatchedSkills { get; set; }
    public JsonDocument AiFeedBack { get; set; }
    public DateTime CreateAt { get; set; } 
}