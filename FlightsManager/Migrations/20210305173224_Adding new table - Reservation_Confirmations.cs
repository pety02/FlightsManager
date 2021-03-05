using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightsManager.Migrations
{
    public partial class AddingnewtableReservation_Confirmations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DestrictedAreas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestrictedAreas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LivingPlaces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingPlaces", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlaneTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ContinentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Countries_Continents",
                        column: x => x.ContinentID,
                        principalTable: "Continents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Family = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    EGN = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeRoles",
                        column: x => x.RoleID,
                        principalTable: "EmployeeRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country_LivingPlace",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    LivingPlaceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country_LivingPlace", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Country_LivingPlace_Country_LivingPlace",
                        column: x => x.CountryID,
                        principalTable: "Continents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_LivingPlace_LivingPlaces",
                        column: x => x.LivingPlaceID,
                        principalTable: "LivingPlaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LivingPlace_DestrictedAreaID",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    LivingPlaceID = table.Column<int>(type: "int", nullable: false),
                    DestrictedAreaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingPlace_DestrictedAreaID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LivingPlace_DestrictedAreaID_DestrictedAreas",
                        column: x => x.DestrictedAreaID,
                        principalTable: "DestrictedAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LivingPlace_DestrictedAreaID_LivingPlaces",
                        column: x => x.LivingPlaceID,
                        principalTable: "LivingPlaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passagers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    SecondName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    EGN = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NationalityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Passagers_Nationalities",
                        column: x => x.NationalityID,
                        principalTable: "Nationalities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DestrictedArea_Street",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    DestrictedAreaID = table.Column<int>(type: "int", nullable: false),
                    StreetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestrictedArea_Street", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DestrictedArea_Street_DestrictedAreas",
                        column: x => x.DestrictedAreaID,
                        principalTable: "DestrictedAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DestrictedArea_Street_Streets",
                        column: x => x.StreetID,
                        principalTable: "Streets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ContitnetID = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    LivingPlaceID = table.Column<int>(type: "int", nullable: false),
                    DestrictedAreaID = table.Column<int>(type: "int", nullable: false),
                    StreetID = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    Apartament = table.Column<int>(type: "int", nullable: true),
                    AddressTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Addresses",
                        column: x => x.ContitnetID,
                        principalTable: "Continents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressTypes",
                        column: x => x.AddressTypeID,
                        principalTable: "AddressTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_DestrictedAreas",
                        column: x => x.DestrictedAreaID,
                        principalTable: "DestrictedAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_LivingPlaces",
                        column: x => x.LivingPlaceID,
                        principalTable: "LivingPlaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Streets",
                        column: x => x.StreetID,
                        principalTable: "Streets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    UniquePlaneNumber = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PlaneTypeID = table.Column<int>(type: "int", nullable: false),
                    PilotID = table.Column<int>(type: "int", nullable: false),
                    PassagerCapacity = table.Column<int>(type: "int", nullable: false),
                    BussinessClassCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Planes_Employees",
                        column: x => x.PilotID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planes_PlaneTypes",
                        column: x => x.PlaneTypeID,
                        principalTable: "PlaneTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    LocationFromID = table.Column<int>(type: "int", nullable: false),
                    LocationToID = table.Column<int>(type: "int", nullable: false),
                    TakeOffDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LandingDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PlaneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flights_Addresses",
                        column: x => x.LocationFromID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Addresses1",
                        column: x => x.LocationToID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Planes",
                        column: x => x.PlaneID,
                        principalTable: "Planes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FlightID = table.Column<int>(type: "int", nullable: false),
                    TicketTypeID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tickets_Flights",
                        column: x => x.FlightID,
                        principalTable: "Flights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTypes",
                        column: x => x.TicketTypeID,
                        principalTable: "TicketTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TicketID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservations_Tickets",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation_Passager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    PassagerID = table.Column<int>(type: "int", nullable: false),
                    ResrvationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation_Passager", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservation_Passager_Passagers",
                        column: x => x.PassagerID,
                        principalTable: "Passagers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Passager_Reservations",
                        column: x => x.ResrvationID,
                        principalTable: "Reservations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressTypeID",
                table: "Addresses",
                column: "AddressTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContitnetID",
                table: "Addresses",
                column: "ContitnetID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryID",
                table: "Addresses",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DestrictedAreaID",
                table: "Addresses",
                column: "DestrictedAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_LivingPlaceID",
                table: "Addresses",
                column: "LivingPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetID",
                table: "Addresses",
                column: "StreetID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentID",
                table: "Countries",
                column: "ContinentID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_LivingPlace_CountryID",
                table: "Country_LivingPlace",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_LivingPlace_LivingPlaceID",
                table: "Country_LivingPlace",
                column: "LivingPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_DestrictedArea_Street_DestrictedAreaID",
                table: "DestrictedArea_Street",
                column: "DestrictedAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_DestrictedArea_Street_StreetID",
                table: "DestrictedArea_Street",
                column: "StreetID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID",
                table: "Employees",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_LocationFromID",
                table: "Flights",
                column: "LocationFromID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_LocationToID",
                table: "Flights",
                column: "LocationToID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneID",
                table: "Flights",
                column: "PlaneID");

            migrationBuilder.CreateIndex(
                name: "IX_LivingPlace_DestrictedAreaID_DestrictedAreaID",
                table: "LivingPlace_DestrictedAreaID",
                column: "DestrictedAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_LivingPlace_DestrictedAreaID_LivingPlaceID",
                table: "LivingPlace_DestrictedAreaID",
                column: "LivingPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Passagers_NationalityID",
                table: "Passagers",
                column: "NationalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_PilotID",
                table: "Planes",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_PlaneTypeID",
                table: "Planes",
                column: "PlaneTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Passager_PassagerID",
                table: "Reservation_Passager",
                column: "PassagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Passager_ResrvationID",
                table: "Reservation_Passager",
                column: "ResrvationID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TicketID",
                table: "Reservations",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightID",
                table: "Tickets",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeID",
                table: "Tickets",
                column: "TicketTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country_LivingPlace");

            migrationBuilder.DropTable(
                name: "DestrictedArea_Street");

            migrationBuilder.DropTable(
                name: "LivingPlace_DestrictedAreaID");

            migrationBuilder.DropTable(
                name: "Reservation_Passager");

            migrationBuilder.DropTable(
                name: "Passagers");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "DestrictedAreas");

            migrationBuilder.DropTable(
                name: "LivingPlaces");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PlaneTypes");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");
        }
    }
}
