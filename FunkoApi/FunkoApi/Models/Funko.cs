using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FunkoApi.Models;

public record Funko {
    
    [BsonId]
    public ObjectId Id { get; init; }

    [BsonElement("nombre")]
    public string Nombre { get; init; } = string.Empty;
    
    [BsonElement("precio")]
    public decimal Precio { get; init; }

    [BsonElement("categoria")] 
    public Categoria Categoria { get; init; } = null!;
    
    [BsonElement("imagen")]
    public string? Imagen { get; init; }
    
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; init; }
    
    [BsonElement("updated_at")]
    public DateTime? UpdatedAt { get; init; }
    
    [BsonElement("deleted_at")]
    public DateTime? DeletedAt { get; init; }
    
    [BsonElement("is_deleted")]
    public bool IsDeleted { get; init; }
}

[Owned]
public class Categoria {
    
    [BsonElement("nombre")]
    public string Nombre { get; init; } = string.Empty;
    
    [BsonElement("descripcion")]
    public string? Descripcion { get; init; }
}