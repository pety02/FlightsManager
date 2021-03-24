using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FlightsManager.Models.Data
{
    public partial class FlightsManagerContext : DbContext
    {
        public FlightsManagerContext()
        {
        }

        public FlightsManagerContext(DbContextOptions<FlightsManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DestrictedAreaStreet> DestrictedAreaStreets { get; set; }
        public virtual DbSet<DestrictedArea> DestrictedAreas { get; set; }
        public virtual DbSet<CountryLivingPlace> CountryLivingPlaces { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<LivingPlace> LivingPlaces { get; set; }
        public virtual DbSet<LivingPlaceDestrictedArea> LivingPlaceDestrictedAreas { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Passager> Passagers { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<PlaneType> PlaneTypes { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ReservationPassager> ReservationPassagers { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketType> TicketTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CQJ61O4\\SQLEXPRESS02;Initial Catalog=FlightsManager;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.ContitnetId).HasColumnName("ContitnetID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DestrictedAreaId).HasColumnName("DestrictedAreaID");

                entity.Property(e => e.LivingPlaceId).HasColumnName("LivingPlaceID");

                entity.Property(e => e.StreetId).HasColumnName("StreetID");

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_AddressTypes");

                entity.HasOne(d => d.Contitnet)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.ContitnetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_Addresses");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_Countries");

                entity.HasOne(d => d.DestrictedArea)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.DestrictedAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_DestrictedAreas");

                entity.HasOne(d => d.LivingPlace)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.LivingPlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_LivingPlaces");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_Streets");
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ContinentId).HasColumnName("ContinentID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ContinentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Countries_Continents");
            });

            modelBuilder.Entity<CountryLivingPlace>(entity =>
            {
                entity.ToTable("Country_LivingPlace");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.LivingPlaceId).HasColumnName("LivingPlaceID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryLivingPlaces)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_LivingPlace_Country_LivingPlace");

                entity.HasOne(d => d.LivingPlace)
                    .WithMany(p => p.CountryLivingPlaces)
                    .HasForeignKey(d => d.LivingPlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_LivingPlace_LivingPlaces");
            });

            modelBuilder.Entity<DestrictedArea>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DestrictedAreaStreet>(entity =>
            {
                entity.ToTable("DestrictedArea_Street");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DestrictedAreaId).HasColumnName("DestrictedAreaID");

                entity.Property(e => e.StreetId).HasColumnName("StreetID");

                entity.HasOne(d => d.DestrictedArea)
                    .WithMany(p => p.DestrictedAreaStreets)
                    .HasForeignKey(d => d.DestrictedAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DestrictedArea_Street_DestrictedAreas");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.DestrictedAreaStreets)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DestrictedArea_Street_Streets");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Egn)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EGN");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_EmployeeRoles");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.LandingDateTime).HasColumnType("datetime");

                entity.Property(e => e.LocationFromId).HasColumnName("LocationFromID");

                entity.Property(e => e.LocationToId).HasColumnName("LocationToID");

                entity.Property(e => e.PlaneId).HasColumnName("PlaneID");

                entity.Property(e => e.TakeOffDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.LocationFrom)
                    .WithMany(p => p.FlightLocationFroms)
                    .HasForeignKey(d => d.LocationFromId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flights_Addresses");

                entity.HasOne(d => d.LocationTo)
                    .WithMany(p => p.FlightLocationTos)
                    .HasForeignKey(d => d.LocationToId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flights_Addresses1");

                entity.HasOne(d => d.Plane)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.PlaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flights_Planes");
            });

            modelBuilder.Entity<LivingPlace>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LivingPlaceDestrictedArea>(entity =>
            {
                entity.ToTable("LivingPlace_DestrictedAreaID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DestrictedAreaId).HasColumnName("DestrictedAreaID");

                entity.Property(e => e.LivingPlaceId).HasColumnName("LivingPlaceID");

                entity.HasOne(d => d.DestrictedArea)
                    .WithMany(p => p.LivingPlaceDestrictedAreaIds)
                    .HasForeignKey(d => d.DestrictedAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LivingPlace_DestrictedAreaID_DestrictedAreas");

                entity.HasOne(d => d.LivingPlace)
                    .WithMany(p => p.LivingPlaceDestrictedAreaIds)
                    .HasForeignKey(d => d.LivingPlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LivingPlace_DestrictedAreaID_LivingPlaces");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Passager>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Egn)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EGN");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NationalityId).HasColumnName("NationalityID");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.Passagers)
                    .HasForeignKey(d => d.NationalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Passagers_Nationalities");
            });

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.PilotId).HasColumnName("PilotID");

                entity.Property(e => e.PlaneTypeId).HasColumnName("PlaneTypeID");

                entity.Property(e => e.UniquePlaneNumber)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pilot)
                    .WithMany(p => p.Planes)
                    .HasForeignKey(d => d.PilotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Planes_Employees");

                entity.HasOne(d => d.PlaneType)
                    .WithMany(p => p.Planes)
                    .HasForeignKey(d => d.PlaneTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Planes_PlaneTypes");
            });

            modelBuilder.Entity<PlaneType>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ReservationDate).HasColumnType("datetime");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Tickets");
            });

            modelBuilder.Entity<ReservationPassager>(entity =>
            {
                entity.ToTable("Reservation_Passager");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.PassagerId).HasColumnName("PassagerID");

                entity.Property(e => e.ResrvationId).HasColumnName("ResrvationID");

                entity.HasOne(d => d.Passager)
                    .WithMany(p => p.ReservationPassagers)
                    .HasForeignKey(d => d.PassagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Passager_Passagers");

                entity.HasOne(d => d.Resrvation)
                    .WithMany(p => p.ReservationPassagers)
                    .HasForeignKey(d => d.ResrvationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Passager_Reservations");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TicketTypeId).HasColumnName("TicketTypeID");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Flights");

                entity.HasOne(d => d.TicketType)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TicketTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_TicketTypes");
            });

            modelBuilder.Entity<TicketType>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
