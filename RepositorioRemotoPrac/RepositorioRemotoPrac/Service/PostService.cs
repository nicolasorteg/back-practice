using System.Net;
using CSharpFunctionalExtensions;
using Refit;
using RepositorioRemotoPrac.Api;
using RepositorioRemotoPrac.Dto;
using RepositorioRemotoPrac.Errors.Common;
using RepositorioRemotoPrac.Errors.Post;
using RepositorioRemotoPrac.Models;

namespace RepositorioRemotoPrac.Service;

public class PostService(IPostsApi api) {
    
    public async Task<Result<List<Post>, DomainError>> GetAllAsync() {
        try {
            return Result.Success<List<Post>, DomainError>(await api.GetPostAsync());
        }
        catch (ApiException ex) {
            return Result.Failure<List<Post>, DomainError>(
                PostErrors.ApiFailure((int)ex.StatusCode, ex.Message));
        }
    }

    public async Task<Result<Post, DomainError>> GetByIdAsync(int id) {
        try {
            return Result.Success<Post, DomainError>(await api.GetPostByIdAsync(id));
        }
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound) {
            return Result.Failure<Post, DomainError>(PostErrors.NotFoundById(id));
        }
        catch (ApiException ex) {
            return Result.Failure<Post, DomainError>(
                PostErrors.ApiFailure((int)ex.StatusCode, ex.Message));
        }
    }

    public async Task<Result<Post, DomainError>> CreateAsync(CreatePostRequest peticion) {
        try {
            return Result.Success<Post, DomainError>(await api.CreatePostAsync(peticion));
        }
        catch (ApiException ex) {
            return Result.Failure<Post, DomainError>(
                PostErrors.ApiFailure((int)ex.StatusCode, ex.Message));
        }
    }
    
    public async Task<Result<Post, DomainError>> UpdateAsync(int id, UpdatePostRequest peticion) {
        try {
            return Result.Success<Post, DomainError>(await api.UpdatePostAsync(id, peticion));
        }
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound) {
            return Result.Failure<Post, DomainError>(PostErrors.NotFoundById(id));
        }
        catch (ApiException ex) {
            return Result.Failure<Post, DomainError>(
                PostErrors.ApiFailure((int)ex.StatusCode, ex.Message));
        }
    }

    public async Task<Result<bool, DomainError>> DeleteAsync(int id) {
        try {
            await api.DeletePostAsync(id);
            return Result.Success<bool, DomainError>(true);
        }
        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound) {
            return Result.Failure<bool, DomainError>(PostErrors.NotFoundById(id));
        }
        catch (ApiException ex) {
            return Result.Failure<bool, DomainError>(
                PostErrors.ApiFailure((int)ex.StatusCode, ex.Message));
        }
    }
}