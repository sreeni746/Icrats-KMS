using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Icrats.KMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustodianTypes",
                columns: table => new
                {
                    CustodianTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustodianTypeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CustodianTypeDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustodianTypes", x => x.CustodianTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DoorTypes",
                columns: table => new
                {
                    DoorTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoorTypeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DoorTypeDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorTypes", x => x.DoorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FacilityName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FacilityAddress = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    FacilityLocation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilityId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    DoorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoorCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DoorDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FacilityId = table.Column<int>(type: "integer", nullable: false),
                    DoorTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.DoorId);
                    table.ForeignKey(
                        name: "FK_Doors_DoorTypes_DoorTypeId",
                        column: x => x.DoorTypeId,
                        principalTable: "DoorTypes",
                        principalColumn: "DoorTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doors_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Custodians",
                columns: table => new
                {
                    CustodianId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CustodianTypeId = table.Column<int>(type: "integer", nullable: false),
                    AssignedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custodians", x => x.CustodianId);
                    table.ForeignKey(
                        name: "FK_Custodians_CustodianTypes_CustodianTypeId",
                        column: x => x.CustodianTypeId,
                        principalTable: "CustodianTypes",
                        principalColumn: "CustodianTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Custodians_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locks",
                columns: table => new
                {
                    LockId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LockCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DoorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locks", x => x.LockId);
                    table.ForeignKey(
                        name: "FK_Locks_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "DoorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    KeyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Stampings = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    KeyCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LockId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.KeyId);
                    table.ForeignKey(
                        name: "FK_Keys_Locks_LockId",
                        column: x => x.LockId,
                        principalTable: "Locks",
                        principalColumn: "LockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeySpareKeyMap",
                columns: table => new
                {
                    KeySpareKeyMapId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KeyId = table.Column<int>(type: "integer", nullable: false),
                    SpareKeyId = table.Column<int>(type: "integer", nullable: false),
                    AssignedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeySpareKeyMap", x => x.KeySpareKeyMapId);
                    table.ForeignKey(
                        name: "FK_KeySpareKeyMap_Keys_KeyId",
                        column: x => x.KeyId,
                        principalTable: "Keys",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeySpareKeyMap_Keys_SpareKeyId",
                        column: x => x.SpareKeyId,
                        principalTable: "Keys",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Custodians_CustodianTypeId",
                table: "Custodians",
                column: "CustodianTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Custodians_UserId",
                table: "Custodians",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustodianTypes_CustodianTypeName",
                table: "CustodianTypes",
                column: "CustodianTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doors_DoorTypeId",
                table: "Doors",
                column: "DoorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_FacilityId",
                table: "Doors",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorTypes_DoorTypeName",
                table: "DoorTypes",
                column: "DoorTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keys_LockId",
                table: "Keys",
                column: "LockId");

            migrationBuilder.CreateIndex(
                name: "IX_KeySpareKeyMap_KeyId",
                table: "KeySpareKeyMap",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_KeySpareKeyMap_SpareKeyId",
                table: "KeySpareKeyMap",
                column: "SpareKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Locks_DoorId",
                table: "Locks",
                column: "DoorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Custodians");

            migrationBuilder.DropTable(
                name: "KeySpareKeyMap");

            migrationBuilder.DropTable(
                name: "CustodianTypes");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "Locks");

            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropTable(
                name: "DoorTypes");

            migrationBuilder.DropTable(
                name: "Facilities");
        }
    }
}
