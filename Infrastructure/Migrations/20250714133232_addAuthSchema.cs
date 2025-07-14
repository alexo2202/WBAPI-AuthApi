using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAuthSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.CreateTable(
                name: "TblModules",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblRoles",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblRolesModules",
                schema: "Auth",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRolesModules", x => new { x.RoleId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_TblRolesModules_TblModules_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "Auth",
                        principalTable: "TblModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblRolesModules_TblRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Auth",
                        principalTable: "TblRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblUsers",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblUsers_TblRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Auth",
                        principalTable: "TblRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "TblModules",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vehículos" },
                    { 2, "Reservas" }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "TblRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Asesor" }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "TblRolesModules",
                columns: new[] { "ModuleId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "TblUsers",
                columns: new[] { "Id", "Email", "EmployeeId", "Password", "PasswordKey", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, "pedroperez@reservation.com", 1, new byte[] { 161, 118, 217, 111, 167, 156, 25, 14, 239, 16, 230, 181, 142, 149, 34, 213, 237, 106, 251, 70, 232, 110, 102, 66, 4, 203, 69, 192, 83, 159, 45, 213, 29, 92, 189, 8, 67, 61, 20, 175, 172, 70, 70, 35, 38, 247, 196, 33, 203, 208, 122, 98, 183, 231, 253, 108, 100, 149, 195, 157, 215, 19, 182, 143 }, new byte[] { 7, 90, 116, 245, 64, 154, 217, 179, 9, 218, 99, 68, 95, 58, 43, 27, 98, 230, 19, 130, 122, 0, 125, 154, 209, 126, 87, 252, 60, 200, 67, 219, 177, 229, 158, 40, 25, 36, 223, 154, 79, 81, 135, 243, 60, 207, 71, 102, 96, 78, 192, 255, 122, 178, 184, 68, 52, 136, 48, 87, 68, 57, 4, 205, 231, 158, 131, 1, 136, 149, 238, 70, 132, 97, 42, 231, 89, 96, 67, 137, 80, 239, 7, 205, 201, 111, 150, 130, 95, 12, 172, 239, 163, 50, 234, 99, 97, 97, 69, 166, 218, 203, 155, 133, 184, 118, 183, 164, 42, 218, 101, 127, 201, 233, 96, 203, 60, 5, 118, 75, 226, 120, 75, 57, 118, 114, 131, 10 }, 1, "pedroperez" },
                    { 2, "grabrielgomez@bookingcar.com", 2, new byte[] { 186, 29, 179, 108, 173, 93, 137, 117, 80, 79, 230, 163, 57, 71, 144, 221, 24, 153, 47, 84, 9, 177, 236, 118, 82, 61, 32, 97, 124, 99, 24, 243, 232, 126, 12, 163, 217, 242, 139, 77, 213, 113, 58, 151, 80, 247, 185, 200, 214, 88, 54, 3, 138, 108, 114, 19, 198, 52, 80, 211, 165, 51, 223, 170 }, new byte[] { 70, 112, 6, 203, 47, 38, 19, 198, 226, 122, 44, 13, 18, 85, 101, 245, 173, 53, 184, 104, 204, 148, 86, 192, 132, 76, 240, 104, 48, 144, 176, 11, 169, 47, 184, 77, 2, 167, 209, 33, 223, 64, 38, 150, 200, 197, 172, 193, 180, 135, 236, 185, 123, 162, 161, 81, 184, 247, 105, 123, 51, 12, 47, 225, 74, 28, 28, 183, 135, 199, 251, 47, 95, 153, 96, 204, 78, 243, 165, 114, 209, 200, 103, 44, 89, 193, 209, 226, 22, 228, 61, 20, 14, 185, 155, 75, 17, 151, 219, 18, 53, 64, 34, 119, 248, 34, 152, 41, 150, 81, 51, 127, 163, 199, 211, 113, 51, 17, 40, 53, 235, 193, 247, 188, 66, 109, 68, 118 }, 2, "grabrielgomez" },
                    { 3, "rodolforuiz@bookingcar.com", 3, new byte[] { 12, 34, 72, 77, 214, 100, 88, 65, 240, 13, 220, 221, 88, 96, 15, 163, 201, 97, 185, 79, 32, 254, 238, 17, 121, 28, 234, 237, 110, 244, 107, 252, 181, 158, 240, 176, 103, 95, 32, 108, 206, 88, 123, 38, 83, 131, 223, 163, 226, 232, 45, 32, 199, 87, 80, 233, 128, 133, 11, 154, 51, 45, 45, 102 }, new byte[] { 176, 99, 116, 190, 219, 136, 250, 242, 233, 0, 133, 65, 130, 206, 33, 166, 179, 227, 210, 115, 254, 16, 196, 90, 238, 234, 43, 223, 39, 72, 253, 173, 128, 255, 76, 237, 124, 233, 111, 12, 61, 145, 100, 129, 238, 2, 82, 167, 130, 181, 87, 108, 244, 77, 203, 253, 178, 200, 108, 183, 6, 10, 103, 96, 240, 235, 187, 20, 49, 91, 212, 18, 17, 145, 240, 5, 96, 11, 5, 75, 187, 130, 141, 122, 46, 186, 62, 45, 40, 6, 243, 136, 58, 201, 11, 37, 206, 190, 151, 102, 244, 91, 150, 23, 23, 159, 5, 161, 234, 27, 234, 23, 2, 87, 160, 93, 232, 0, 218, 184, 123, 36, 70, 224, 171, 147, 54, 30 }, 2, "rodolforuiz" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblRolesModules_ModuleId",
                schema: "Auth",
                table: "TblRolesModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUsers_RoleId",
                schema: "Auth",
                table: "TblUsers",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblRolesModules",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "TblUsers",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "TblModules",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "TblRoles",
                schema: "Auth");
        }
    }
}
