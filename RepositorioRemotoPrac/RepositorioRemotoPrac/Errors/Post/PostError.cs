using RepositorioRemotoPrac.Errors.Common;

namespace RepositorioRemotoPrac.Errors.Post;

public abstract record PostError(string Message) : DomainError(Message) {

    /// <summary>Post no encontrado (404)</summary>
    public sealed record NotFoundById(int Id)
        : PostError($"No se ha encontrado ningún Post con el identificador: {Id}");

    /// <summary>Datos no válidos (400)</summary>
    public sealed record Validation(IEnumerable<string> Errores)
        : PostError($"Errores de validación:{Environment.NewLine}• {string.Join($"{Environment.NewLine}• ", Errores)}");

    /// <summary>Fallo de comunicación con la API externa</summary>
    public sealed record ApiFailure(int StatusCode, string Detail)
        : PostError($"Error de la API ({StatusCode}): {Detail}");
}