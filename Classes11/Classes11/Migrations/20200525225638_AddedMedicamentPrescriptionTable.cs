using Microsoft.EntityFrameworkCore.Migrations;

namespace Classes11.Migrations
{
    public partial class AddedMedicamentPrescriptionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrescriptionMedicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    Dose = table.Column<int>(nullable: true),
                    Details = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicament", x => new { x.IdPrescription, x.IdMedicament });
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicament_Medicaments_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicament_Prescriptions_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicament",
                columns: new[] { "IdPrescription", "IdMedicament", "Details", "Dose" },
                values: new object[] { 1, 1, "Po kolacji", 1 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicament",
                columns: new[] { "IdPrescription", "IdMedicament", "Details", "Dose" },
                values: new object[] { 2, 2, "Po śniadaniu i obiedzie", 2 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicament",
                columns: new[] { "IdPrescription", "IdMedicament", "Details", "Dose" },
                values: new object[] { 3, 3, "3 razy dziennie", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicament_IdMedicament",
                table: "PrescriptionMedicament",
                column: "IdMedicament");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionMedicament");
        }
    }
}
