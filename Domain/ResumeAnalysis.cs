using System.Text.Json;

namespace Domain;

public class ResumeAnalysis
{
    public Guid Id { get; set; }
    public Guid ResumeDocumentId {get; set;}
    public float StructureScire { get; set; }
    public float AtsScore {get; set;}
    public float ReadAbilityScore { get; set; }
    public float OverallScore { get; set; }
    public JsonDocument Strengths { get; set; }
    public JsonDocument Weaknesses { get; set; }
    public JsonDocument Recommendations { get; set; }
    public DateTime CreateAt { get; set; }
}