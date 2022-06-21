using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopWebAPI.API.Persistence.Models;

namespace WorkshopWebAPI.API.Persistence
{
    public class AudiDbContext : DbContext
    {
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<ConfigurationsOrders> ConfigurationsOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<ExternalColor> ExternalColors { get; set; }
        public DbSet<InternalColor> InternalColors { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Order> Orders { get; set; }
        public AudiDbContext(DbContextOptions<AudiDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureConfigurations(modelBuilder.Entity<Configuration>());
            ConfigureConfigurationsOrders(modelBuilder.Entity<ConfigurationsOrders>());
            ConfigureCustomers(modelBuilder.Entity<Customer>());
            ConfigureEngine(modelBuilder.Entity<Engine>());
            ConfigureExternalColors(modelBuilder.Entity<ExternalColor>());
            ConfigureInternalColors(modelBuilder.Entity<InternalColor>());
            ConfigureModels(modelBuilder.Entity<Model>());
            ConfigureOrders(modelBuilder.Entity<Order>());

            //Seeds
            CustomerSeed(modelBuilder.Entity<Customer>());
        }

        #region Configurations
        private static void ConfigureConfigurations(EntityTypeBuilder<Configuration> builder)
        {
            builder
                .HasOne<Engine>()
                .WithMany()
                .HasForeignKey(fk => fk.EngineId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne<Model>()
                .WithMany()
                .HasForeignKey(fk => fk.ModelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        private static void ConfigureConfigurationsOrders(EntityTypeBuilder<ConfigurationsOrders> builder)
        {
            builder.HasKey(i => new { i.OrderId, i.ConfigurationId });
            builder
                .HasOne<Configuration>()
                .WithMany()
                .HasForeignKey(fk => fk.ConfigurationId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne<Order>()
                .WithMany()
                .HasForeignKey(fk => fk.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        private static void ConfigureCustomers(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(i => i.Id);
            builder
                .HasIndex(i => i.Email).IsUnique();
            builder.Property(i => i.Firstname).HasMaxLength(40);
            builder.Property(i => i.Lastname).HasMaxLength(40);
            builder.Property(i => i.Email).HasMaxLength(100);
        }
        private static void ConfigureEngine(EntityTypeBuilder<Engine> builder)
        {
            builder
                .HasIndex(i => i.Name).IsUnique();
            builder.Property(i => i.Name).HasMaxLength(50);
            builder.Property(i => i.Trasmission).HasMaxLength(50);
        }
        private static void ConfigureExternalColors(EntityTypeBuilder<ExternalColor> builder)
        {
            builder
                .HasIndex(i => i.Name).IsUnique();
            builder.Property(i => i.Name).HasMaxLength(50);
        }
        private static void ConfigureInternalColors(EntityTypeBuilder<InternalColor> builder)
        {
            builder
                .HasIndex(i => i.Name).IsUnique();
            builder.Property(i => i.Name).HasMaxLength(50);
        }
        private static void ConfigureModels(EntityTypeBuilder<Model> builder)
        {
            builder
                .HasIndex(i => i.FullName).IsUnique();
            builder.Property(i => i.FullName).HasMaxLength(100);
        }
        private static void ConfigureOrders(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(fk => fk.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        #endregion

        #region Data
        private static void ConfigurationSeed(EntityTypeBuilder<Configuration> builder)
        {
            builder.HasData(
                    new Configuration() { }
                );
        }

        private static void CustomerSeed(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                    new Customer() { Id = Guid.Parse("b9e30ed2-16d2-4d80-8823-3af375945ce1"), Email = "stefano.tomba@nttdata.com", Birthdate = new DateTime(1995, 2, 20), Firstname = "Stefano", Lastname = "Tomba", Phone = "0230303049" },
                    new Customer() { Id = Guid.Parse("ed92c708-f4c9-456c-9c5c-2b59ccbd219a"), Email = "mario.rossi@nttdata.com", Birthdate = new DateTime(1993, 5, 10), Firstname = "Mario", Lastname = "Rossi", Phone = "0230330219" },
                    new Customer() { Id = Guid.Parse("e1b327d5-471a-48ab-8c8d-04203808fcc7"), Email = "luca.bianchi@nttdata.com", Birthdate = new DateTime(1994, 3, 11), Firstname = "Luca", Lastname = "Bianchi", Phone = "0237853485" }
                );
        }
        #endregion
    }
}
