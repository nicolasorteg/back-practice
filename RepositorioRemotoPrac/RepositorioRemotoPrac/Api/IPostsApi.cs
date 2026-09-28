using Refit;
using RepositorioRemotoPrac.Dto;
using RepositorioRemotoPrac.Models;

namespace RepositorioRemotoPrac.Api;

public interface IPostsApi {
    
    [Get("/posts")]
    Task<List<Post>> GetPostAsync();

    [Get("/posts/{id}")]
    Task<Post> GetPostByIdAsync(int id);
    
    [Post("/posts")]
    Task<Post> CreatePostAsync([Body] CreatePostRequest request);
    
    [Put("/posts/{id}")]
    Task<Post> UpdatePostAsync(int id, [Body] UpdatePostRequest request);

    [Delete("/posts/{id}")]
    Task DeletePostAsync(int id);
}