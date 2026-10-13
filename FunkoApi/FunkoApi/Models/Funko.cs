namespace FunkoApi.Models;

public record Funko {
    
    public long Id { get; init; }

    public string Nombre { get; init; } = string.Empty;
    public decimal Precio { get; init; }
    public string Categoria { get; init; } = string.Empty;
    public string? Imagen { get; init; }
    
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public DateTime? DeletedAt { get; init; }
    public bool IsDeleted { get; init; }
}