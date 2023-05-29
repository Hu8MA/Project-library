using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labrary2023.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    idAuthor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.idAuthor);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    idcat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.idcat);
                });

            migrationBuilder.CreateTable(
                name: "member_States",
                columns: table => new
                {
                    idmeb_sta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value_state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member_States", x => x.idmeb_sta);
                });

            migrationBuilder.CreateTable(
                name: "reservation_States",
                columns: table => new
                {
                    idres_sta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value_state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation_States", x => x.idres_sta);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    idbook = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    copies = table.Column<int>(type: "int", nullable: false),
                    idcat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.idbook);
                    table.ForeignKey(
                        name: "FK_book_category_idcat",
                        column: x => x.idcat,
                        principalTable: "category",
                        principalColumn: "idcat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    idmeb = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    joinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idmeb_sta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.idmeb);
                    table.ForeignKey(
                        name: "FK_members_member_States_idmeb_sta",
                        column: x => x.idmeb_sta,
                        principalTable: "member_States",
                        principalColumn: "idmeb_sta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_Authors",
                columns: table => new
                {
                    idBo_Au = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idbook = table.Column<int>(type: "int", nullable: false),
                    idAuthor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_Authors", x => x.idBo_Au);
                    table.ForeignKey(
                        name: "FK_book_Authors_authors_idAuthor",
                        column: x => x.idAuthor,
                        principalTable: "authors",
                        principalColumn: "idAuthor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_Authors_book_idbook",
                        column: x => x.idbook,
                        principalTable: "book",
                        principalColumn: "idbook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fine_Payments",
                columns: table => new
                {
                    idfi_pa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idmeb = table.Column<int>(type: "int", nullable: false),
                    DatePay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payamount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fine_Payments", x => x.idfi_pa);
                    table.ForeignKey(
                        name: "FK_fine_Payments_members_idmeb",
                        column: x => x.idmeb,
                        principalTable: "members",
                        principalColumn: "idmeb",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                columns: table => new
                {
                    idlo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idbook = table.Column<int>(type: "int", nullable: false),
                    idmeb = table.Column<int>(type: "int", nullable: false),
                    loan_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    return_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.idlo);
                    table.ForeignKey(
                        name: "FK_loans_book_idbook",
                        column: x => x.idbook,
                        principalTable: "book",
                        principalColumn: "idbook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_loans_members_idmeb",
                        column: x => x.idmeb,
                        principalTable: "members",
                        principalColumn: "idmeb",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    idres = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idbook = table.Column<int>(type: "int", nullable: false),
                    idmeb = table.Column<int>(type: "int", nullable: false),
                    reservation_states_id = table.Column<int>(type: "int", nullable: false),
                    reservation_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.idres);
                    table.ForeignKey(
                        name: "FK_reservations_book_idbook",
                        column: x => x.idbook,
                        principalTable: "book",
                        principalColumn: "idbook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_members_idmeb",
                        column: x => x.idmeb,
                        principalTable: "members",
                        principalColumn: "idmeb",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_reservation_States_reservation_states_id",
                        column: x => x.reservation_states_id,
                        principalTable: "reservation_States",
                        principalColumn: "idres_sta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fines",
                columns: table => new
                {
                    idfn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idlon = table.Column<int>(type: "int", nullable: false),
                    fine_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fine_amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fines", x => x.idfn);
                    table.ForeignKey(
                        name: "FK_fines_loans_idlon",
                        column: x => x.idlon,
                        principalTable: "loans",
                        principalColumn: "idlo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_idcat",
                table: "book",
                column: "idcat");

            migrationBuilder.CreateIndex(
                name: "IX_book_Authors_idAuthor",
                table: "book_Authors",
                column: "idAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_book_Authors_idbook",
                table: "book_Authors",
                column: "idbook");

            migrationBuilder.CreateIndex(
                name: "IX_fine_Payments_idmeb",
                table: "fine_Payments",
                column: "idmeb");

            migrationBuilder.CreateIndex(
                name: "IX_fines_idlon",
                table: "fines",
                column: "idlon");

            migrationBuilder.CreateIndex(
                name: "IX_loans_idbook",
                table: "loans",
                column: "idbook");

            migrationBuilder.CreateIndex(
                name: "IX_loans_idmeb",
                table: "loans",
                column: "idmeb");

            migrationBuilder.CreateIndex(
                name: "IX_members_idmeb_sta",
                table: "members",
                column: "idmeb_sta");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_idbook",
                table: "reservations",
                column: "idbook");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_idmeb",
                table: "reservations",
                column: "idmeb");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_reservation_states_id",
                table: "reservations",
                column: "reservation_states_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_Authors");

            migrationBuilder.DropTable(
                name: "fine_Payments");

            migrationBuilder.DropTable(
                name: "fines");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "loans");

            migrationBuilder.DropTable(
                name: "reservation_States");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "member_States");
        }
    }
}
