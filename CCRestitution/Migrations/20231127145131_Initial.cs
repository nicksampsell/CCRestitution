using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCRestitution.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    CourtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.CourtId);
                });

            migrationBuilder.CreateTable(
                name: "MoneyOrdered",
                columns: table => new
                {
                    MoneyOrderedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opened = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Closed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EHM = table.Column<bool>(type: "bit", nullable: false),
                    FineAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FineOpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinePayByDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FineCloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MandatorySurchargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MandatorySurchargeOpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MandatorySurchargePayByDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MandatorySurchargeCloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EHMAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RestitutionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RestitutionOpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestitutionPayByDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestitutionCloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OtherAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherOpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OtherPayByDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OtherCloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SurchargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SurchargeOpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SurchargePayByDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SurchargeCloseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupervisionFeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SupervisionFeeOpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupervisionFeeCloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    YO = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyOrdered", x => x.MoneyOrderedId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: true),
                    DatePaid = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FineAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MandatorySurchargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EHMAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RestitutionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SurchargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SupervisionFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Judges",
                columns: table => new
                {
                    JudgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourtId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judges", x => x.JudgeId);
                    table.ForeignKey(
                        name: "FK_Judges_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "CourtId");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<int>(type: "int", nullable: false),
                    Docket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgencyCode = table.Column<int>(type: "int", nullable: false),
                    CustodyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourtId = table.Column<int>(type: "int", nullable: false),
                    JudgeId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "CourtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Judges_JudgeId",
                        column: x => x.JudgeId,
                        principalTable: "Judges",
                        principalColumn: "JudgeId");
                });

            migrationBuilder.CreateTable(
                name: "Crimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Law_Ordinal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attempted_Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attempted_VF_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attempted_NYS_Law_Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bus_Driver_Charge_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex_Offender_Registry_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NCIC_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UCR_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAFIS_Crime_Cateory_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Offense_Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JO_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JD_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IBR_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maxi_Law_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Law_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mini_Law_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sub_Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sub_Section13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EFFECTIVE_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REPEAL_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FP_Offense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unconst_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weapon_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Armed_VFO_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minors_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Career_Criminal_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INS_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Non_Seal_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sub_Convict_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jail_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Post_Convict_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auto_Strip_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Full_Law_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NYS_Law_Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VF_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNA_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attempted_DNA_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Escape_Charge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hate_Crime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Invalidated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terrorism_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DMV_VTCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AO_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RTA_FP_Offense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODIFIED_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Civil_Confinement_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attempted_CCI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expanded_Law_Literal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexually_Motivated_Ind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MCDV_Charge_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RDLR_Indicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crimes_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Defendants",
                columns: table => new
                {
                    DefendantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defendants", x => x.DefendantId);
                    table.ForeignKey(
                        name: "FK_Defendants_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Victims",
                columns: table => new
                {
                    VictimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victims", x => x.VictimId);
                    table.ForeignKey(
                        name: "FK_Victims_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CourtId",
                table: "Accounts",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_JudgeId",
                table: "Accounts",
                column: "JudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Crimes_AccountId",
                table: "Crimes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Defendants_AccountId",
                table: "Defendants",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Judges_CourtId",
                table: "Judges",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Victims_AccountId",
                table: "Victims",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crimes");

            migrationBuilder.DropTable(
                name: "Defendants");

            migrationBuilder.DropTable(
                name: "MoneyOrdered");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Victims");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Judges");

            migrationBuilder.DropTable(
                name: "Courts");
        }
    }
}
