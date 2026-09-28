using Refit;
using RepositorioRemotoPrac.Api;

// refit crea la implementación de la interfaz con la URL base
var api = RestService.For<IPostsApi>("https://jsonplaceholder.typicode.com");

// cargar los datos
var posts = await api.GetPostAsync();
Console.WriteLine($"Total de posts: {posts.Count}");

foreach (var p in posts.Take(5)) {
    Console.WriteLine($"[{p.Id}] (usuario {p.UserId}) {p.Title}");
}

var uno = await api.GetPostByIdAsync(1);
Console.WriteLine($"\nPost 1: {uno.Title}");

// probar error
try {
    await api.GetPostByIdAsync(9999);
}
catch (ApiException ex) {
    Console.WriteLine($"\nError de la API: {(int)ex.StatusCode} {ex.StatusCode}");
}