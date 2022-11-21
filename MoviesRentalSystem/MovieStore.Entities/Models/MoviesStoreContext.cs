using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieStore.Main.Models
{
    public partial class MoviesStoreContext : DbContext
    {
        public MoviesStoreContext()
        {
        }

        public MoviesStoreContext(DbContextOptions<MoviesStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;
        public virtual DbSet<ReleaseYear> ReleaseYears { get; set; } = null!;
        public virtual DbSet<Rental> Rentals { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<TransactionType> TransactionTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3DC7SVB;Database=MoviesStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.TransactionId, "UQ__account__9B57CF7350FE98B9")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerId, "UQ__account__B611CB7CEE307B28")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountDetails)
                    .HasMaxLength(255)
                    .HasColumnName("account_details");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(255)
                    .HasColumnName("accountName");

                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .HasColumnName("bankName");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("lastUpdated");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.Account)
                    .HasPrincipalKey<Rental>(p => p.CustomerId)
                    .HasForeignKey<Account>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Rental");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_account_customer");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.HasIndex(e => e.CityId, "UQ__address__B4BEB95F2417D377")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerId, "UQ__address__B611CB7C7D984D81")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.Landline)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("landline");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("lastUpdated");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .HasColumnName("postalCode");

                entity.HasOne(d => d.City)
                    .WithOne(p => p.Address)
                    .HasForeignKey<Address>(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_address_city");

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.Address)
                    .HasForeignKey<Address>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_address_customer");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Admin");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lastupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdated");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FistName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RentalCosts)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("rentalCosts");

                entity.Property(e => e.RentalId).HasColumnName("rentalId");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Account");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CustomerNavigation)
                    .HasPrincipalKey<Address>(p => p.CustomerId)
                    .HasForeignKey<Customer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Address");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.Customer)
                    .HasPrincipalKey<Rental>(p => p.CustomerId)
                    .HasForeignKey<Customer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Rental");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Transactions");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("Director");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lastupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdated");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lastupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdated");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("lastUpdated");

                entity.Property(e => e.NumberofDvd).HasColumnName("numberofDvd");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lastupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdated");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DirectorId).HasColumnName("directorId");

                entity.Property(e => e.GenreId).HasColumnName("genreId");

                entity.Property(e => e.LanguageId).HasColumnName("languageId");

                entity.Property(e => e.MovieName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("movieName")
                    .IsFixedLength();

                entity.Property(e => e.ProducerId).HasColumnName("producerId");

                entity.Property(e => e.ReleaseYearId).HasColumnName("releaseYearId");

                entity.Property(e => e.RentalCost).HasColumnName("rentalCost");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK_Movies_Director");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Movies_genre");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Movies_language");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ProducerId)
                    .HasConstraintName("FK_Movies_Producer");

                entity.HasOne(d => d.ReleaseYear)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ReleaseYearId)
                    .HasConstraintName("FK_Movies_ReleaseYear");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.ToTable("Producer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lastupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdated");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ReleaseYear>(entity =>
            {
                entity.ToTable("ReleaseYear");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lastupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdated");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("Rental");

                entity.HasIndex(e => e.MovieId, "UQ__rental__42EB374FE2588BBB")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerId, "UQ__rental__B611CB7C7F747655")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasColumnName("customerId");

                entity.Property(e => e.MovieId).HasColumnName("movieId");

                entity.Property(e => e.RentalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("rentalDate");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("datetime")
                    .HasColumnName("returnDate");

                entity.Property(e => e.TotalMoviesRented).HasColumnName("totalMoviesRented");

                entity.Property(e => e.Totalcost).HasColumnName("totalcost");

                entity.HasOne(d => d.Movie)
                    .WithOne(p => p.Rental)
                    .HasForeignKey<Rental>(d => d.MovieId)
                    .HasConstraintName("FK_Rental_Movies");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasIndex(e => e.RentalId, "UQ__transact__0164732FC61F5EE8")
                    .IsUnique();

                entity.HasIndex(e => e.TransactionTypeId, "UQ__transact__483B179BEC34DA6D")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerId, "UQ__transact__B611CB7C45E1F597")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.RentalId).HasColumnName("rentalId");

                entity.Property(e => e.TransactionAmount).HasColumnName("transactionAmount");

                entity.Property(e => e.TransactionComment)
                    .HasMaxLength(255)
                    .HasColumnName("transactionComment");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("transactionDate");

                entity.Property(e => e.TransactionTypeId).HasColumnName("transactionTypeId");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Transaction)
                    .HasPrincipalKey<Account>(p => p.TransactionId)
                    .HasForeignKey<Transaction>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Account");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionType");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.TransactipnTypeDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("transactipnTypeDescription");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TransactionType)
                    .HasPrincipalKey<Transaction>(p => p.TransactionTypeId)
                    .HasForeignKey<TransactionType>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionType_Transactions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
