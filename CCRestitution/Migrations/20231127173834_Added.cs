using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCRestitution.Migrations
{
    /// <inheritdoc />
    public partial class Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropIndex(
                name: "IX_Crimes_AccountId",
                table: "Crimes");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Crimes");


            migrationBuilder.CreateTable(
                name: "AccountCrime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AccountCrimeId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CrimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCrime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountCrime_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AccountCrime_Crimes_CrimeId",
                        column: x => x.CrimeId,
                        principalTable: "Crimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AccountCrime_Crimes_Id",
                        column: x => x.Id,
                        principalTable: "Crimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);

                });

            migrationBuilder.CreateTable(
                name: "Attorneys",
                columns: table => new
                {
                    AttorneyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attorneys", x => x.AttorneyId);
                });

            migrationBuilder.CreateTable(
                name: "DefendantPriorResidences",
                columns: table => new
                {
                    DefendantPriorResidenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefendantId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonLeft = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefendantPriorResidences", x => x.DefendantPriorResidenceId);
                    table.ForeignKey(
                        name: "FK_DefendantPriorResidences_Defendants_DefendantId",
                        column: x => x.DefendantId,
                        principalTable: "Defendants",
                        principalColumn: "DefendantId");
                });

            migrationBuilder.CreateTable(
                name: "DetentionFacilities",
                columns: table => new
                {
                    DetentionFacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetentionFacilities", x => x.DetentionFacilityId);
                });

            migrationBuilder.CreateTable(
                name: "ProbationDepartments",
                columns: table => new
                {
                    ProbationDepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbationDepartments", x => x.ProbationDepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentAgencies",
                columns: table => new
                {
                    TreatmentAgencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentAgencies", x => x.TreatmentAgencyId);
                });

            migrationBuilder.CreateTable(
                name: "VictimPriorResidence",
                columns: table => new
                {
                    VictimPriorResidenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VictimId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonLeft = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VictimPriorResidence", x => x.VictimPriorResidenceId);
                    table.ForeignKey(
                        name: "FK_VictimPriorResidence_Victims_VictimId",
                        column: x => x.VictimId,
                        principalTable: "Victims",
                        principalColumn: "VictimId");
                });

            migrationBuilder.CreateTable(
                name: "ProbationOfficers",
                columns: table => new
                {
                    ProbationOfficerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProbationDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbationOfficers", x => x.ProbationOfficerId);
                    table.ForeignKey(
                        name: "FK_ProbationOfficers_ProbationDepartments_ProbationDepartmentId",
                        column: x => x.ProbationDepartmentId,
                        principalTable: "ProbationDepartments",
                        principalColumn: "ProbationDepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCrime_AccountId",
                table: "AccountCrime",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCrime_CrimeId",
                table: "AccountCrime",
                column: "CrimeId");

            migrationBuilder.CreateIndex(
                name: "IX_DefendantPriorResidences_DefendantId",
                table: "DefendantPriorResidences",
                column: "DefendantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProbationOfficers_ProbationDepartmentId",
                table: "ProbationOfficers",
                column: "ProbationDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_VictimPriorResidence_VictimId",
                table: "VictimPriorResidence",
                column: "VictimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCrime");

            migrationBuilder.DropTable(
                name: "Attorneys");

            migrationBuilder.DropTable(
                name: "DefendantPriorResidences");

            migrationBuilder.DropTable(
                name: "DetentionFacilities");

            migrationBuilder.DropTable(
                name: "ProbationOfficers");

            migrationBuilder.DropTable(
                name: "TreatmentAgencies");

            migrationBuilder.DropTable(
                name: "VictimPriorResidence");

            migrationBuilder.DropTable(
                name: "ProbationDepartments");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Judges");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Crimes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crimes_AccountId",
                table: "Crimes",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crimes_Accounts_AccountId",
                table: "Crimes",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId");
        }
    }
}
