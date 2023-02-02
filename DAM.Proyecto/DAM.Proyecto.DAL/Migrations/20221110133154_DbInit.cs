using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAM.Proyecto.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventosEuskadiTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishmentEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishmentEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityLatitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityLongitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityNoraCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Online = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningHoursEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceNoraCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseUrlEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseUrlEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceNameEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceNameEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceUrlEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceUrlEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlEventEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlEventEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlNameEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlNameEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlOnline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlOnlineEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosEuskadiTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalItems = table.Column<long>(type: "bigint", nullable: false),
                    TotalPages = table.Column<long>(type: "bigint", nullable: false),
                    CurrentPage = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoActividadTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoActividadTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consumidor = table.Column<bool>(type: "bit", nullable: false),
                    Servuctor = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventoEuskadi",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    companyEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descriptionEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descriptionEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    establishmentEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    establishmentEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    municipalityEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    municipalityEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    municipalityLatitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    municipalityLongitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    municipalityNoraCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    online = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    openingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    openingHoursEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placeEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placeEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    priceEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    provinceNoraCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    publicationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    purchaseUrlEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    purchaseUrlEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sourceNameEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sourceNameEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sourceUrlEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sourceUrlEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urlEventEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urlEventEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urlNameEs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urlNameEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urlOnline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urlOnlineEu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventsTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoEuskadi", x => x.id);
                    table.ForeignKey(
                        name: "FK_EventoEuskadi_EventsTable_EventsTableId",
                        column: x => x.EventsTableId,
                        principalTable: "EventsTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EventoEuskadiTableId = table.Column<long>(type: "bigint", nullable: true),
                    EventoEuskadiid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_EventoEuskadi_EventoEuskadiid",
                        column: x => x.EventoEuskadiid,
                        principalTable: "EventoEuskadi",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Image_EventosEuskadiTable_EventoEuskadiTableId",
                        column: x => x.EventoEuskadiTableId,
                        principalTable: "EventosEuskadiTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventoEuskadi_EventsTableId",
                table: "EventoEuskadi",
                column: "EventsTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_EventoEuskadiid",
                table: "Image",
                column: "EventoEuskadiid");

            migrationBuilder.CreateIndex(
                name: "IX_Image_EventoEuskadiTableId",
                table: "Image",
                column: "EventoEuskadiTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "ImageTable");

            migrationBuilder.DropTable(
                name: "TipoActividadTable");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.DropTable(
                name: "EventoEuskadi");

            migrationBuilder.DropTable(
                name: "EventosEuskadiTable");

            migrationBuilder.DropTable(
                name: "EventsTable");
        }
    }
}
