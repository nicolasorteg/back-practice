using Refit;
using RepositorioRemotoPrac.Models;

namespace RepositorioRemotoPrac.Api;

public interface IPostsApi {
    
    [Get("/posts")]
    Task<List<Post>> GetPostAsync();

    [Get("/posts/{id}")]
    Task<Post> GetPostByIdAsync(int id);
}