using FunkoApi.Models;

namespace FunkoApi.Repositories;

public interface IFunkoRepository {
    
    IReadOnlyList<Funko> GetAll();
    Funko? GetById(long id);
    Funko? GetByNombre(string nombre);
    
    Funko Add(Funko funko);
    Funko? Update(long id, Funko funko);
    Funko? PatchPrice(long id, decimal precio);
    bool Delete(long id);
}