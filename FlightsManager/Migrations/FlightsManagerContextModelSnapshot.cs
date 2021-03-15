﻿// <auto-generated />
using System;
using FlightsManager.Models;
using FlightsManager.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightsManager.Migrations
{
    [DbContext(typeof(FlightsManagerContext))]
    partial class FlightsManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightsManager.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("AddressTypeId")
                        .HasColumnType("int")
                        .HasColumnName("AddressTypeID");

                    b.Property<int?>("Apartament")
                        .HasColumnType("int");

                    b.Property<int>("ContitnetId")
                        .HasColumnType("int")
                        .HasColumnName("ContitnetID");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    b.Property<int>("DestrictedAreaId")
                        .HasColumnType("int")
                        .HasColumnName("DestrictedAreaID");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("LivingPlaceId")
                        .HasColumnType("int")
                        .HasColumnName("LivingPlaceID");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("StreetId")
                        .HasColumnType("int")
                        .HasColumnName("StreetID");

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.HasIndex("ContitnetId");

                    b.HasIndex("CountryId");

                    b.HasIndex("DestrictedAreaId");

                    b.HasIndex("LivingPlaceId");

                    b.HasIndex("StreetId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("FlightsManager.Models.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("AddressTypes");
                });

            modelBuilder.Entity("FlightsManager.Models.Continent", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Continents");
                });

            modelBuilder.Entity("FlightsManager.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("ContinentId")
                        .HasColumnType("int")
                        .HasColumnName("ContinentID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FlightsManager.Models.CountryLivingPlace", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    b.Property<int>("LivingPlaceId")
                        .HasColumnType("int")
                        .HasColumnName("LivingPlaceID");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("LivingPlaceId");

                    b.ToTable("Country_LivingPlace");
                });

            modelBuilder.Entity("FlightsManager.Models.DestrictedArea", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("DestrictedAreas");
                });

            modelBuilder.Entity("FlightsManager.Models.DestrictedAreaStreet", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("DestrictedAreaId")
                        .HasColumnType("int")
                        .HasColumnName("DestrictedAreaID");

                    b.Property<int>("StreetId")
                        .HasColumnType("int")
                        .HasColumnName("StreetID");

                    b.HasKey("Id");

                    b.HasIndex("DestrictedAreaId");

                    b.HasIndex("StreetId");

                    b.ToTable("DestrictedArea_Street");
                });

            modelBuilder.Entity("FlightsManager.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    b.Property<string>("Egn")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("EGN");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FlightsManager.Models.EmployeeRole", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("FlightsManager.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<DateTime>("LandingDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("LocationFromId")
                        .HasColumnType("int")
                        .HasColumnName("LocationFromID");

                    b.Property<int>("LocationToId")
                        .HasColumnType("int")
                        .HasColumnName("LocationToID");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int")
                        .HasColumnName("PlaneID");

                    b.Property<DateTime>("TakeOffDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("LocationFromId");

                    b.HasIndex("LocationToId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightsManager.Models.LivingPlace", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("LivingPlaces");
                });

            modelBuilder.Entity("FlightsManager.Models.LivingPlaceDestrictedAreaId", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("DestrictedAreaId")
                        .HasColumnType("int")
                        .HasColumnName("DestrictedAreaID");

                    b.Property<int>("LivingPlaceId")
                        .HasColumnType("int")
                        .HasColumnName("LivingPlaceID");

                    b.HasKey("Id");

                    b.HasIndex("DestrictedAreaId");

                    b.HasIndex("LivingPlaceId");

                    b.ToTable("LivingPlace_DestrictedAreaID");
                });

            modelBuilder.Entity("FlightsManager.Models.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("FlightsManager.Models.Passager", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Egn")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("EGN");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int")
                        .HasColumnName("NationalityID");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("NationalityId");

                    b.ToTable("Passagers");
                });

            modelBuilder.Entity("FlightsManager.Models.Plane", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("BussinessClassCapacity")
                        .HasColumnType("int");

                    b.Property<int>("PassagerCapacity")
                        .HasColumnType("int");

                    b.Property<int>("PilotId")
                        .HasColumnType("int")
                        .HasColumnName("PilotID");

                    b.Property<int>("PlaneTypeId")
                        .HasColumnType("int")
                        .HasColumnName("PlaneTypeID");

                    b.Property<string>("UniquePlaneNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("PilotId");

                    b.HasIndex("PlaneTypeId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("FlightsManager.Models.PlaneType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("PlaneTypes");
                });

            modelBuilder.Entity("FlightsManager.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("TicketId")
                        .HasColumnType("int")
                        .HasColumnName("TicketID");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("FlightsManager.Models.ReservationPassager", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("PassagerId")
                        .HasColumnType("int")
                        .HasColumnName("PassagerID");

                    b.Property<int>("ResrvationId")
                        .HasColumnType("int")
                        .HasColumnName("ResrvationID");

                    b.HasKey("Id");

                    b.HasIndex("PassagerId");

                    b.HasIndex("ResrvationId");

                    b.ToTable("Reservation_Passager");
                });

            modelBuilder.Entity("FlightsManager.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("FlightsManager.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("FlightId")
                        .HasColumnType("int")
                        .HasColumnName("FlightID");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("TicketTypeId")
                        .HasColumnType("int")
                        .HasColumnName("TicketTypeID");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("TicketTypeId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("FlightsManager.Models.TicketType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("FlightsManager.Models.Address", b =>
                {
                    b.HasOne("FlightsManager.Models.AddressType", "AddressType")
                        .WithMany("Addresses")
                        .HasForeignKey("AddressTypeId")
                        .HasConstraintName("FK_Addresses_AddressTypes")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.Continent", "Contitnet")
                        .WithMany("Addresses")
                        .HasForeignKey("ContitnetId")
                        .HasConstraintName("FK_Addresses_Addresses")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.Country", "Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Addresses_Countries")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.DestrictedArea", "DestrictedArea")
                        .WithMany("Addresses")
                        .HasForeignKey("DestrictedAreaId")
                        .HasConstraintName("FK_Addresses_DestrictedAreas")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.LivingPlace", "LivingPlace")
                        .WithMany("Addresses")
                        .HasForeignKey("LivingPlaceId")
                        .HasConstraintName("FK_Addresses_LivingPlaces")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.Street", "Street")
                        .WithMany("Addresses")
                        .HasForeignKey("StreetId")
                        .HasConstraintName("FK_Addresses_Streets")
                        .IsRequired();

                    b.Navigation("AddressType");

                    b.Navigation("Contitnet");

                    b.Navigation("Country");

                    b.Navigation("DestrictedArea");

                    b.Navigation("LivingPlace");

                    b.Navigation("Street");
                });

            modelBuilder.Entity("FlightsManager.Models.Country", b =>
                {
                    b.HasOne("FlightsManager.Models.Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId")
                        .HasConstraintName("FK_Countries_Continents")
                        .IsRequired();

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("FlightsManager.Models.CountryLivingPlace", b =>
                {
                    b.HasOne("FlightsManager.Models.Continent", "Country")
                        .WithMany("CountryLivingPlaces")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Country_LivingPlace_Country_LivingPlace")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.LivingPlace", "LivingPlace")
                        .WithMany("CountryLivingPlaces")
                        .HasForeignKey("LivingPlaceId")
                        .HasConstraintName("FK_Country_LivingPlace_LivingPlaces")
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("LivingPlace");
                });

            modelBuilder.Entity("FlightsManager.Models.DestrictedAreaStreet", b =>
                {
                    b.HasOne("FlightsManager.Models.DestrictedArea", "DestrictedArea")
                        .WithMany("DestrictedAreaStreets")
                        .HasForeignKey("DestrictedAreaId")
                        .HasConstraintName("FK_DestrictedArea_Street_DestrictedAreas")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.Street", "Street")
                        .WithMany("DestrictedAreaStreets")
                        .HasForeignKey("StreetId")
                        .HasConstraintName("FK_DestrictedArea_Street_Streets")
                        .IsRequired();

                    b.Navigation("DestrictedArea");

                    b.Navigation("Street");
                });

            modelBuilder.Entity("FlightsManager.Models.Employee", b =>
                {
                    b.HasOne("FlightsManager.Models.EmployeeRole", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Employees_EmployeeRoles")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FlightsManager.Models.Flight", b =>
                {
                    b.HasOne("FlightsManager.Models.Address", "LocationFrom")
                        .WithMany("FlightLocationFroms")
                        .HasForeignKey("LocationFromId")
                        .HasConstraintName("FK_Flights_Addresses")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.Address", "LocationTo")
                        .WithMany("FlightLocationTos")
                        .HasForeignKey("LocationToId")
                        .HasConstraintName("FK_Flights_Addresses1")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneId")
                        .HasConstraintName("FK_Flights_Planes")
                        .IsRequired();

                    b.Navigation("LocationFrom");

                    b.Navigation("LocationTo");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("FlightsManager.Models.LivingPlaceDestrictedAreaId", b =>
                {
                    b.HasOne("FlightsManager.Models.DestrictedArea", "DestrictedArea")
                        .WithMany("LivingPlaceDestrictedAreaIds")
                        .HasForeignKey("DestrictedAreaId")
                        .HasConstraintName("FK_LivingPlace_DestrictedAreaID_DestrictedAreas")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.LivingPlace", "LivingPlace")
                        .WithMany("LivingPlaceDestrictedAreaIds")
                        .HasForeignKey("LivingPlaceId")
                        .HasConstraintName("FK_LivingPlace_DestrictedAreaID_LivingPlaces")
                        .IsRequired();

                    b.Navigation("DestrictedArea");

                    b.Navigation("LivingPlace");
                });

            modelBuilder.Entity("FlightsManager.Models.Passager", b =>
                {
                    b.HasOne("FlightsManager.Models.Nationality", "Nationality")
                        .WithMany("Passagers")
                        .HasForeignKey("NationalityId")
                        .HasConstraintName("FK_Passagers_Nationalities")
                        .IsRequired();

                    b.Navigation("Nationality");
                });

            modelBuilder.Entity("FlightsManager.Models.Plane", b =>
                {
                    b.HasOne("FlightsManager.Models.Employee", "Pilot")
                        .WithMany("Planes")
                        .HasForeignKey("PilotId")
                        .HasConstraintName("FK_Planes_Employees")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.PlaneType", "PlaneType")
                        .WithMany("Planes")
                        .HasForeignKey("PlaneTypeId")
                        .HasConstraintName("FK_Planes_PlaneTypes")
                        .IsRequired();

                    b.Navigation("Pilot");

                    b.Navigation("PlaneType");
                });

            modelBuilder.Entity("FlightsManager.Models.Reservation", b =>
                {
                    b.HasOne("FlightsManager.Models.Ticket", "Ticket")
                        .WithMany("Reservations")
                        .HasForeignKey("TicketId")
                        .HasConstraintName("FK_Reservations_Tickets")
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("FlightsManager.Models.ReservationPassager", b =>
                {
                    b.HasOne("FlightsManager.Models.Passager", "Passager")
                        .WithMany("ReservationPassagers")
                        .HasForeignKey("PassagerId")
                        .HasConstraintName("FK_Reservation_Passager_Passagers")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.Reservation", "Resrvation")
                        .WithMany("ReservationPassagers")
                        .HasForeignKey("ResrvationId")
                        .HasConstraintName("FK_Reservation_Passager_Reservations")
                        .IsRequired();

                    b.Navigation("Passager");

                    b.Navigation("Resrvation");
                });

            modelBuilder.Entity("FlightsManager.Models.Ticket", b =>
                {
                    b.HasOne("FlightsManager.Models.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .HasConstraintName("FK_Tickets_Flights")
                        .IsRequired();

                    b.HasOne("FlightsManager.Models.TicketType", "TicketType")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketTypeId")
                        .HasConstraintName("FK_Tickets_TicketTypes")
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("TicketType");
                });

            modelBuilder.Entity("FlightsManager.Models.Address", b =>
                {
                    b.Navigation("FlightLocationFroms");

                    b.Navigation("FlightLocationTos");
                });

            modelBuilder.Entity("FlightsManager.Models.AddressType", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("FlightsManager.Models.Continent", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Countries");

                    b.Navigation("CountryLivingPlaces");
                });

            modelBuilder.Entity("FlightsManager.Models.Country", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("FlightsManager.Models.DestrictedArea", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("DestrictedAreaStreets");

                    b.Navigation("LivingPlaceDestrictedAreaIds");
                });

            modelBuilder.Entity("FlightsManager.Models.Employee", b =>
                {
                    b.Navigation("Planes");
                });

            modelBuilder.Entity("FlightsManager.Models.EmployeeRole", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("FlightsManager.Models.Flight", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("FlightsManager.Models.LivingPlace", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CountryLivingPlaces");

                    b.Navigation("LivingPlaceDestrictedAreaIds");
                });

            modelBuilder.Entity("FlightsManager.Models.Nationality", b =>
                {
                    b.Navigation("Passagers");
                });

            modelBuilder.Entity("FlightsManager.Models.Passager", b =>
                {
                    b.Navigation("ReservationPassagers");
                });

            modelBuilder.Entity("FlightsManager.Models.Plane", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("FlightsManager.Models.PlaneType", b =>
                {
                    b.Navigation("Planes");
                });

            modelBuilder.Entity("FlightsManager.Models.Reservation", b =>
                {
                    b.Navigation("ReservationPassagers");
                });

            modelBuilder.Entity("FlightsManager.Models.Street", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("DestrictedAreaStreets");
                });

            modelBuilder.Entity("FlightsManager.Models.Ticket", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("FlightsManager.Models.TicketType", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
