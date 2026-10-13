using FunkoApi.Models;

namespace FunkoApi.Repositories;

public class FunkoRepository : IFunkoRepository {
    
    private static List<Funko> _funkos = [];
    private static long _nextId = 1;
    
    // seed inicial
    public FunkoRepository() {
        Add(new Funko { Nombre = "Batman", Precio = 15m, Categoria = "Superheroes", Imagen = ""});
        Add(new Funko { Nombre = "Monke D. Luffy", Precio = 12m, Categoria = "Anime", Imagen = ""});
        Add(new Funko { Nombre = "James Hetfield", Precio = 25m, Categoria = "Musica", Imagen = ""});
        Add(new Funko { Nombre = "Iron Man", Precio = 8m, Categoria = "Superheroes", Imagen = ""});
        Add(new Funko { Nombre = "Bombardera Brillante", Precio = 14.99m, Categoria = "Videojuegos", Imagen = ""});
    }


    public IReadOnlyList<Funko> GetAll() =>
        _funkos;

    public Funko? GetById(long id) {
        throw new NotImplementedException();
    }

    public Funko? GetByNombre(string nombre) {
        throw new NotImplementedException();
    }

    public Funko Add(Funko funko) {
        throw new NotImplementedException();
    }

    public Funko? Update(long id, Funko funko) {
        throw new NotImplementedException();
    }

    public Funko? PatchPrice(long id, decimal precio) {
        throw new NotImplementedException();
    }

    public bool Delete(long id) {
        throw new NotImplementedException();
    }
}