using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodBanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Governrate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHealthy = table.Column<bool>(type: "bit", nullable: false),
                    LastDonationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donors_BloodBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "BloodBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventorySummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComponentType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentCount = table.Column<int>(type: "int", nullable: false),
                    AlertThreshold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventorySummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventorySummaries_BloodBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "BloodBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PatientBloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientVisits_BloodBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "BloodBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationRequests_BloodBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "BloodBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonationRequests_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BloodBags",
                columns: table => new
                {
                    BagSerial = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientVisitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBags", x => x.BagSerial);
                    table.ForeignKey(
                        name: "FK_BloodBags_BloodBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "BloodBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BloodBags_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BloodBags_PatientVisits_PatientVisitId",
                        column: x => x.PatientVisitId,
                        principalTable: "PatientVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodBags_BankId",
                table: "BloodBags",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodBags_DonorId",
                table: "BloodBags",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodBags_PatientVisitId",
                table: "BloodBags",
                column: "PatientVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodBanks_Email",
                table: "BloodBanks",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodBanks_Phone",
                table: "BloodBanks",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonationRequests_BankId",
                table: "DonationRequests",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationRequests_DonorId",
                table: "DonationRequests",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BankId",
                table: "Donors",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_NationalId",
                table: "Donors",
                column: "NationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donors_Phone",
                table: "Donors",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventorySummaries_BankId_BloodGroup_ComponentType",
                table: "InventorySummaries",
                columns: new[] { "BankId", "BloodGroup", "ComponentType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisits_BankId",
                table: "PatientVisits",
                column: "BankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodBags");

            migrationBuilder.DropTable(
                name: "DonationRequests");

            migrationBuilder.DropTable(
                name: "InventorySummaries");

            migrationBuilder.DropTable(
                name: "PatientVisits");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "BloodBanks");
        }
    }
}
