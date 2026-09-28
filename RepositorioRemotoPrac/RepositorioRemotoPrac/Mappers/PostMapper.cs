using RepositorioRemotoPrac.Dto;
using RepositorioRemotoPrac.Models;

namespace RepositorioRemotoPrac.Mappers;

public static class PostMapper {
    
    extension(Post post) {
        
        public CreatePostRequest ToCreateRequest() => 
            new(post.Title, post.Body, post.UserId);
        
        public UpdatePostRequest ToUpdateRequest() => 
            new(post.Id, post.Title, post.Body, post.UserId);
    }
}