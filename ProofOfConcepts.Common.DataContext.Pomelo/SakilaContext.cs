using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConcept.Shared;

public partial class SakilaContext : DbContext
{
    public SakilaContext()
    {
    }

    public SakilaContext(DbContextOptions<SakilaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<ActorInfo> ActorInfos { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerList> CustomerLists { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<FilmActor> FilmActors { get; set; }

    public virtual DbSet<FilmCategory> FilmCategories { get; set; }

    public virtual DbSet<FilmList> FilmLists { get; set; }

    public virtual DbSet<FilmText> FilmTexts { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<NicerButSlowerFilmList> NicerButSlowerFilmLists { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<SalesByFilmCategory> SalesByFilmCategories { get; set; }

    public virtual DbSet<SalesByStore> SalesByStores { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffList> StaffLists { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=Gold$gym45;database=sakila", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PRIMARY");

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<ActorInfo>(entity =>
        {
            entity.ToView("actor_info");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_address_city");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_city_country");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PRIMARY");

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.Property(e => e.Active).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customer_address");

            entity.HasOne(d => d.Store).WithMany(p => p.Customers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customer_store");
        });

        modelBuilder.Entity<CustomerList>(entity =>
        {
            entity.ToView("customer_list");

            entity.Property(e => e.Notes).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.FilmId).HasName("PRIMARY");

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Rating).HasDefaultValueSql("'G'");
            entity.Property(e => e.RentalDuration).HasDefaultValueSql("'3'");
            entity.Property(e => e.RentalRate).HasDefaultValueSql("'4.99'");
            entity.Property(e => e.ReplacementCost).HasDefaultValueSql("'19.99'");

            entity.HasOne(d => d.Language).WithMany(p => p.FilmLanguages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_language");

            entity.HasOne(d => d.OriginalLanguage).WithMany(p => p.FilmOriginalLanguages).HasConstraintName("fk_film_language_original");
        });

        modelBuilder.Entity<FilmActor>(entity =>
        {
            entity.HasKey(e => new { e.ActorId, e.FilmId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Actor).WithMany(p => p.FilmActors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_actor_actor");

            entity.HasOne(d => d.Film).WithMany(p => p.FilmActors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_actor_film");
        });

        modelBuilder.Entity<FilmCategory>(entity =>
        {
            entity.HasKey(e => new { e.FilmId, e.CategoryId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Category).WithMany(p => p.FilmCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_category_category");

            entity.HasOne(d => d.Film).WithMany(p => p.FilmCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_film_category_film");
        });

        modelBuilder.Entity<FilmList>(entity =>
        {
            entity.ToView("film_list");

            entity.Property(e => e.Fid).HasDefaultValueSql("'0'");
            entity.Property(e => e.Price).HasDefaultValueSql("'4.99'");
            entity.Property(e => e.Rating).HasDefaultValueSql("'G'");
        });

        modelBuilder.Entity<FilmText>(entity =>
        {
            entity.HasKey(e => e.FilmId).HasName("PRIMARY");

            entity.HasIndex(e => new { e.Title, e.Description }, "idx_title_description").HasAnnotation("MySql:FullTextIndex", true);

            entity.Property(e => e.FilmId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PRIMARY");

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Film).WithMany(p => p.Inventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inventory_film");

            entity.HasOne(d => d.Store).WithMany(p => p.Inventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inventory_store");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PRIMARY");

            entity.Property(e => e.LanguageId).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<NicerButSlowerFilmList>(entity =>
        {
            entity.ToView("nicer_but_slower_film_list");

            entity.Property(e => e.Fid).HasDefaultValueSql("'0'");
            entity.Property(e => e.Price).HasDefaultValueSql("'4.99'");
            entity.Property(e => e.Rating).HasDefaultValueSql("'G'");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_payment_customer");

            entity.HasOne(d => d.Rental).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_payment_rental");

            entity.HasOne(d => d.Staff).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_payment_staff");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PRIMARY");

            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Customer).WithMany(p => p.Rentals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rental_customer");

            entity.HasOne(d => d.Inventory).WithMany(p => p.Rentals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rental_inventory");

            entity.HasOne(d => d.Staff).WithMany(p => p.Rentals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rental_staff");
        });

        modelBuilder.Entity<SalesByFilmCategory>(entity =>
        {
            entity.ToView("sales_by_film_category");
        });

        modelBuilder.Entity<SalesByStore>(entity =>
        {
            entity.ToView("sales_by_store");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PRIMARY");

            entity.Property(e => e.StaffId).ValueGeneratedOnAdd();
            entity.Property(e => e.Active).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Address).WithMany(p => p.Staff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_staff_address");

            entity.HasOne(d => d.Store).WithMany(p => p.Staff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_staff_store");
        });

        modelBuilder.Entity<StaffList>(entity =>
        {
            entity.ToView("staff_list");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PRIMARY");

            entity.Property(e => e.StoreId).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Address).WithMany(p => p.Stores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_store_address");

            entity.HasOne(d => d.ManagerStaff).WithOne(p => p.StoreNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_store_staff");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
