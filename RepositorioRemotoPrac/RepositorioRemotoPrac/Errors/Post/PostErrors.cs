using RepositorioRemotoPrac.Errors.Common;

namespace RepositorioRemotoPrac.Errors.Post;

public static class PostErrors {
    
    public static DomainError NotFoundById(int id) =>
        new PostError.NotFoundById(id);

    public static DomainError Validation(IEnumerable<string> errors) =>
        new PostError.Validation(errors);

    public static DomainError ApiFailure(int statusCode, string detail) =>
        new PostError.ApiFailure(statusCode, detail);
}