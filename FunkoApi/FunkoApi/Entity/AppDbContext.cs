using FunkoApi.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace FunkoApi.Entity;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
    
    public DbSet<Funko> Funkos => Set<Funko>();
    public DbSet<Proveedor> Proveedores => Set<Proveedor>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Funko>().ToCollection("funkos");
        modelBuilder.Entity<Proveedor>().ToCollection("proveedores");
    }
}