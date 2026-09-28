namespace RepositorioRemotoPrac.Dto;

public record UpdatePostRequest(int Id, string Title, string Body, int UserId);