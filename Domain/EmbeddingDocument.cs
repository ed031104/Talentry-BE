using System.Numerics;

namespace Domain;

public class EmbeddingDocument
{
    public Guid Id { get; set; }
    public Guid SourceId { get; set; }
    public string SourceType { get; set; }
    public string ChunkType { get; set; }
    public string Context {get; set;}
    public Vector<float> Embedding { get; set; }
    public DateTime CreateAt { get; set; }
}