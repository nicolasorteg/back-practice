using Microsoft.Extensions.DependencyInjection;
using RepositorioRemotoPrac.Dto;
using RepositorioRemotoPrac.Infraestructure;
using RepositorioRemotoPrac.Mappers;
using RepositorioRemotoPrac.Service;

// ID
var provider = DependenciesProvider.BuildServiceProvider();
var scope = provider.CreateScope();
var service = scope.ServiceProvider.GetRequiredService<PostService>();

var todos = await service.GetAllAsync();
if (todos.IsSuccess) {
    Console.WriteLine($"Total de posts: {todos.Value.Count}");
    foreach (var p in todos.Value.Take(5))
        Console.WriteLine($"[{p.Id}] (usuario {p.UserId}) {p.Title}");
}
else {
    Console.WriteLine($"Error: {todos.Error.Message}");
}

// GET por id existente
var uno = await service.GetByIdAsync(1);
Console.WriteLine(uno.IsSuccess ? $"\nPost 1: {uno.Value.Title}" : $"\nError: {uno.Error.Message}");

// GET por id inexistente
var noExiste = await service.GetByIdAsync(9999);
Console.WriteLine(noExiste.IsSuccess ? "\nEncontrado" : $"\nError: {noExiste.Error.Message}");

// POST válido
var creado = await service.CreateAsync(new CreatePostRequest("Mi título", "Mi contenido", 1));
Console.WriteLine(creado.IsSuccess ? $"\nCreado con Id: {creado.Value.Id}" : $"\nError: {creado.Error.Message}");

// PUT
var original = await service.GetByIdAsync(1);
if (original.IsSuccess) {
    
    var editado = original.Value with { Title = "Título editado con mapper" };

    var resultado = await service.UpdateAsync(editado.Id, editado.ToUpdateRequest());
    Console.WriteLine(resultado.IsSuccess
        ? $"\nActualizado: {resultado.Value.Title}"
        : $"\nError: {resultado.Error.Message}");
}

// DELETE
var borrado = await service.DeleteAsync(1);
Console.WriteLine(borrado.IsSuccess ? "\nPost 1 eliminado (simulado)" : $"\nError: {borrado.Error.Message}");