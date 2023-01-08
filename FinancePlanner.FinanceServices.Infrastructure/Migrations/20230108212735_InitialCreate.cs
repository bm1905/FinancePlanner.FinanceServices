using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancePlanner.FinanceServices.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BiWeeklyHoursAndRates",
                columns: table => new
                {
                    BiWeeklyHoursAndRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Week1TotalHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Week1TimeOffHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Week2TotalHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Week2TimeOffHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiWeeklyHoursAndRates", x => x.BiWeeklyHoursAndRateId);
                });

            migrationBuilder.CreateTable(
                name: "PostTaxDeductions",
                columns: table => new
                {
                    PostTaxDeductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Roth401KPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeStockPlanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccidentInsuranceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LifeInsuranceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MiscellaneousAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTaxDeductions", x => x.PostTaxDeductionId);
                });

            migrationBuilder.CreateTable(
                name: "PreTaxDeductions",
                columns: table => new
                {
                    PreTaxDeductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medical = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dental = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vision = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Traditional401KPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HealthSavingAccountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MiscellaneousAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreTaxDeductions", x => x.PreTaxDeductionId);
                });

            migrationBuilder.CreateTable(
                name: "TaxableWageInformation",
                columns: table => new
                {
                    TaxableWageInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateAndFederalTaxableWages = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SocialAndMedicareTaxableWages = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxableWageInformation", x => x.TaxableWageInformationId);
                });

            migrationBuilder.CreateTable(
                name: "TaxInformation",
                columns: table => new
                {
                    TaxInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    W4Type = table.Column<int>(type: "int", nullable: false),
                    TaxFilingStatus = table.Column<int>(type: "int", nullable: false),
                    PayPeriodNumber = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMultipleJobsChecked = table.Column<bool>(type: "bit", nullable: false),
                    ExtraWithholdingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeductionsAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherIncomeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClaimDependentsAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AllowanceNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxInformation", x => x.TaxInformationId);
                });

            migrationBuilder.CreateTable(
                name: "TaxWithheldInformation",
                columns: table => new
                {
                    TaxWithheldInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FederalTaxWithheldAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicareWithheldAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SocialSecurityWithheldAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StateTaxWithheldAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTaxesWithheldAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxWithheldInformation", x => x.TaxWithheldInformationId);
                });

            migrationBuilder.CreateTable(
                name: "PayInformation",
                columns: table => new
                {
                    PayInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BiWeeklyHoursAndRateId = table.Column<int>(type: "int", nullable: false),
                    PostTaxDeductionId = table.Column<int>(type: "int", nullable: false),
                    PreTaxDeductionId = table.Column<int>(type: "int", nullable: false),
                    TaxInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayInformation", x => x.PayInformationId);
                    table.ForeignKey(
                        name: "FK_PayInformation_BiWeeklyHoursAndRates_BiWeeklyHoursAndRateId",
                        column: x => x.BiWeeklyHoursAndRateId,
                        principalTable: "BiWeeklyHoursAndRates",
                        principalColumn: "BiWeeklyHoursAndRateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayInformation_PostTaxDeductions_PostTaxDeductionId",
                        column: x => x.PostTaxDeductionId,
                        principalTable: "PostTaxDeductions",
                        principalColumn: "PostTaxDeductionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayInformation_PreTaxDeductions_PreTaxDeductionId",
                        column: x => x.PreTaxDeductionId,
                        principalTable: "PreTaxDeductions",
                        principalColumn: "PreTaxDeductionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayInformation_TaxInformation_TaxInformationId",
                        column: x => x.TaxInformationId,
                        principalTable: "TaxInformation",
                        principalColumn: "TaxInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeInformation",
                columns: table => new
                {
                    IncomeInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayInformationId = table.Column<int>(type: "int", nullable: false),
                    GrossPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPreTaxDeductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPostTaxDeductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxableWageInformationId = table.Column<int>(type: "int", nullable: false),
                    TaxWithheldInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeInformation", x => x.IncomeInformationId);
                    table.ForeignKey(
                        name: "FK_IncomeInformation_TaxableWageInformation_TaxableWageInformationId",
                        column: x => x.TaxableWageInformationId,
                        principalTable: "TaxableWageInformation",
                        principalColumn: "TaxableWageInformationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomeInformation_TaxWithheldInformation_TaxWithheldInformationId",
                        column: x => x.TaxWithheldInformationId,
                        principalTable: "TaxWithheldInformation",
                        principalColumn: "TaxWithheldInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeInformation_TaxableWageInformationId",
                table: "IncomeInformation",
                column: "TaxableWageInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeInformation_TaxWithheldInformationId",
                table: "IncomeInformation",
                column: "TaxWithheldInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PayInformation_BiWeeklyHoursAndRateId",
                table: "PayInformation",
                column: "BiWeeklyHoursAndRateId");

            migrationBuilder.CreateIndex(
                name: "IX_PayInformation_PostTaxDeductionId",
                table: "PayInformation",
                column: "PostTaxDeductionId");

            migrationBuilder.CreateIndex(
                name: "IX_PayInformation_PreTaxDeductionId",
                table: "PayInformation",
                column: "PreTaxDeductionId");

            migrationBuilder.CreateIndex(
                name: "IX_PayInformation_TaxInformationId",
                table: "PayInformation",
                column: "TaxInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeInformation");

            migrationBuilder.DropTable(
                name: "PayInformation");

            migrationBuilder.DropTable(
                name: "TaxableWageInformation");

            migrationBuilder.DropTable(
                name: "TaxWithheldInformation");

            migrationBuilder.DropTable(
                name: "BiWeeklyHoursAndRates");

            migrationBuilder.DropTable(
                name: "PostTaxDeductions");

            migrationBuilder.DropTable(
                name: "PreTaxDeductions");

            migrationBuilder.DropTable(
                name: "TaxInformation");
        }
    }
}
