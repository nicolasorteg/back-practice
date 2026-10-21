using FunkoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FunkoApi.Entity;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
    
    public DbSet<Funko> Funkos => Set<Funko>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        
        modelBuilder.Entity<Funko>(entity => {
            
        });
        
    }
}