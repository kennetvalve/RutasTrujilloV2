namespace RutasTrujilloV2.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using RutasTrujilloV2.Models;

    public class ModelContext : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Ruta> Ruta { get; set; }
        public DbSet<Tarifa> Tarifa { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Punto> Punto { get; set; }
        
        public ModelContext()
            : base("name=ModelContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    
}