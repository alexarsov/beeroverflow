using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ExpiresOn = table.Column<DateTime>(nullable: false),
                    HasExpired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bans_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breweries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    StyleId = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    BreweryId = table.Column<Guid>(nullable: false),
                    ABV = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beers_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrankLists",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    BeerId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrankLists", x => new { x.UserId, x.BeerId });
                    table.ForeignKey(
                        name: "FK_DrankLists_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrankLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BeerId = table.Column<Guid>(nullable: false),
                    Like = table.Column<bool>(nullable: true),
                    IsFlagged = table.Column<bool>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    BeerId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => new { x.UserId, x.BeerId });
                    table.ForeignKey(
                        name: "FK_WishLists_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    CommentReviewId = table.Column<Guid>(nullable: true),
                    CommentUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => new { x.UserId, x.ReviewId });
                    table.ForeignKey(
                        name: "FK_Comments_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentUserId_CommentReviewId",
                        columns: x => new { x.CommentUserId, x.CommentReviewId },
                        principalTable: "Comments",
                        principalColumns: new[] { "UserId", "ReviewId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ReviewId = table.Column<Guid>(nullable: false),
                    UpVote = table.Column<bool>(nullable: true),
                    CommentReviewId = table.Column<Guid>(nullable: true),
                    CommentUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vote_Comments_CommentUserId_CommentReviewId",
                        columns: x => new { x.CommentUserId, x.CommentReviewId },
                        principalTable: "Comments",
                        principalColumns: new[] { "UserId", "ReviewId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("43a08cc4-76ae-46d8-9e2c-cde7b0479146"), "54b1e5d2-97fa-4f10-8ed5-73512efd35ee", "Member", "MEMBER" },
                    { new Guid("cdde12b9-e61a-4748-a239-c7331b4fb6a8"), "b3ce00d8-e7ea-4450-aa70-4e1e5e23c7d6", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("aea4f481-df4b-4272-9d12-022293d98e48"), 0, "0bdefc90-8ae3-4e72-a612-ac57046e82f8", new DateTime(2020, 5, 4, 22, 26, 45, 988, DateTimeKind.Utc).AddTicks(4037), new DateTime(2020, 5, 4, 22, 26, 45, 987, DateTimeKind.Utc).AddTicks(8191), "stacktrace@bo.net", false, false, true, null, new DateTime(2020, 5, 4, 22, 26, 45, 987, DateTimeKind.Utc).AddTicks(8075), null, "STACKTRACE@BO.NET", "STACKTRACE@BO.NET", "AQAAAAEAACcQAAAAEAOOh2hKDbHYKvsjk9MbpditrGzAUdexFoA5qr0EqxuhLVp+nZ231cTsKuw8ypzGRQ==", null, false, "DC6E275DD1E24957A7781D42BB68293B", false, "stacktrace@bo.net" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("7d4928db-2eb4-4cb9-9372-2a8cb8871615"), new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(6986), null, false, null, "England" },
                    { new Guid("29473585-5e82-4cfc-844e-0c371a6690d6"), new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(6979), null, false, null, "Sweden" },
                    { new Guid("0e03d656-60cc-476b-9c4a-e12d771dbd62"), new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(6954), null, false, null, "Germany" },
                    { new Guid("177cb837-9acd-4adc-85e7-983156b77189"), new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(7013), null, false, null, "Cuba" },
                    { new Guid("0bab8f8f-0400-4573-9ddc-35850d47cb94"), new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(5796), null, false, null, "Bulgaria" },
                    { new Guid("217193b7-0dc9-4ffa-a161-9cba9c8fbccb"), new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(7002), null, false, null, "Finland" },
                    { new Guid("940ce711-c272-46bd-9aa4-9cf64cfd7d3a"), new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(6996), null, false, null, "France" },
                    { new Guid("917bf455-9b03-41f3-923b-65b65983f916"), new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(6991), null, false, null, "Italy" },
                    { new Guid("70a47634-234c-4105-b464-9cf3d7043b44"), new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(7007), null, false, null, "Denmark" }
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("72e7e09e-2640-4db2-910a-84c1401f4c26"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7050), null, false, null, "Porter - Baltic" },
                    { new Guid("0e679a3c-5555-4a27-b0fa-594fba01ed68"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(6969), null, false, null, "Green" },
                    { new Guid("20d79115-03e0-4123-8994-b0f2ceb45ca8"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7020), null, false, null, "Lager" },
                    { new Guid("953d28bf-c7f4-4824-ada9-b67d4256c28c"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7025), null, false, null, "Traditional Ale" },
                    { new Guid("44fdbf01-64b7-4869-ba2f-84290f10bc1f"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7030), null, false, null, "Lager - Dark" },
                    { new Guid("4ae1546e-9cc2-4f52-88f8-86077ae4bd36"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7035), null, false, null, "Winter Warmer" },
                    { new Guid("32bd8b79-eac4-456c-b87d-0bed55087031"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7040), null, false, null, "Lager - Euro Dark" },
                    { new Guid("e589fadb-0cda-4397-9301-f14e0fb7832b"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7046), null, false, null, "Old Ale" },
                    { new Guid("0db937ea-3513-4ce7-b3f6-80ae7474bef2"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(6858), null, false, null, "Premium Light" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("aea4f481-df4b-4272-9d12-022293d98e48"), new Guid("cdde12b9-e61a-4748-a239-c7331b4fb6a8") });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("1aee9ea3-390a-4582-ac37-7a6020ec1553"), new Guid("0bab8f8f-0400-4573-9ddc-35850d47cb94"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1298), null, false, null, "Zagorka AD" },
                    { new Guid("66dae4ad-753d-4170-90a7-5d58756b757f"), new Guid("0e03d656-60cc-476b-9c4a-e12d771dbd62"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1455), null, false, null, "Karlsberg" },
                    { new Guid("52547555-abb7-425a-9818-7eadf0d90e8b"), new Guid("29473585-5e82-4cfc-844e-0c371a6690d6"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1479), null, false, null, "Klackabacken" },
                    { new Guid("4a3757a9-41bc-4f3c-a5b4-7765aa38fac4"), new Guid("7d4928db-2eb4-4cb9-9372-2a8cb8871615"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1493), null, false, null, "Mad Squirrel" },
                    { new Guid("551e3fa1-4d24-420d-8058-d3dd4118f500"), new Guid("917bf455-9b03-41f3-923b-65b65983f916"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1530), null, false, null, "Klanbarrique" },
                    { new Guid("e77ba42b-d8b0-41d9-ba13-98cba75ce8bc"), new Guid("940ce711-c272-46bd-9aa4-9cf64cfd7d3a"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1546), null, false, null, "Le Père Jules" },
                    { new Guid("18112ada-2fc5-41e1-8917-6ebfd4c4a0b7"), new Guid("217193b7-0dc9-4ffa-a161-9cba9c8fbccb"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1557), null, false, null, "CoolHead Brew" },
                    { new Guid("16e01b0a-827e-45af-bcc8-ccf753f4d462"), new Guid("70a47634-234c-4105-b464-9cf3d7043b44"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1569), null, false, null, "Masis Brewery" },
                    { new Guid("f5da3b48-59d6-46d9-b407-5f7d376285e2"), new Guid("177cb837-9acd-4adc-85e7-983156b77189"), new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1580), null, false, null, "Maistila" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "ABV", "BreweryId", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "StyleId" },
                values: new object[,]
                {
                    { new Guid("e23347c0-3a21-4f50-9d5c-c46253ee0715"), 5.2000000000000002, new Guid("1aee9ea3-390a-4582-ac37-7a6020ec1553"), new Guid("0bab8f8f-0400-4573-9ddc-35850d47cb94"), new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(7864), null, false, null, "Heineken", new Guid("0db937ea-3513-4ce7-b3f6-80ae7474bef2") },
                    { new Guid("6f6bd8b0-a68e-4409-bcda-15dbe334a26d"), 4.7999999999999998, new Guid("66dae4ad-753d-4170-90a7-5d58756b757f"), new Guid("0bab8f8f-0400-4573-9ddc-35850d47cb94"), new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8038), null, false, null, "Tuborg", new Guid("0e679a3c-5555-4a27-b0fa-594fba01ed68") },
                    { new Guid("3efd593f-c900-4b05-80dc-e580a07bb7d2"), 4.2999999999999998, new Guid("52547555-abb7-425a-9818-7eadf0d90e8b"), new Guid("29473585-5e82-4cfc-844e-0c371a6690d6"), new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8056), null, false, null, "Omnipollo Selassie", new Guid("20d79115-03e0-4123-8994-b0f2ceb45ca8") },
                    { new Guid("bdbfa744-0f6c-4fd2-99cf-8867fb4b4b92"), 7.7999999999999998, new Guid("4a3757a9-41bc-4f3c-a5b4-7765aa38fac4"), new Guid("7d4928db-2eb4-4cb9-9372-2a8cb8871615"), new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8070), null, false, null, "King Henry", new Guid("953d28bf-c7f4-4824-ada9-b67d4256c28c") },
                    { new Guid("1f6a31a3-b955-4190-b961-bd2b105e5103"), 5.5, new Guid("551e3fa1-4d24-420d-8058-d3dd4118f500"), new Guid("917bf455-9b03-41f3-923b-65b65983f916"), new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8081), null, false, null, "Hardcore Mælk", new Guid("44fdbf01-64b7-4869-ba2f-84290f10bc1f") },
                    { new Guid("6b99474b-00bd-42ed-8a46-48dc16f94ff8"), 6.5999999999999996, new Guid("e77ba42b-d8b0-41d9-ba13-98cba75ce8bc"), new Guid("940ce711-c272-46bd-9aa4-9cf64cfd7d3a"), new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8093), null, false, null, "Bière de Garde", new Guid("4ae1546e-9cc2-4f52-88f8-86077ae4bd36") },
                    { new Guid("55742482-9d52-4272-92b6-60b5c417b924"), 5.5999999999999996, new Guid("18112ada-2fc5-41e1-8917-6ebfd4c4a0b7"), new Guid("217193b7-0dc9-4ffa-a161-9cba9c8fbccb"), new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8104), null, false, null, "Rye Beer", new Guid("32bd8b79-eac4-456c-b87d-0bed55087031") },
                    { new Guid("72bb2fe8-9b56-4bef-8941-e986b806ce98"), 12.6, new Guid("16e01b0a-827e-45af-bcc8-ccf753f4d462"), new Guid("70a47634-234c-4105-b464-9cf3d7043b44"), new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8115), null, false, null, "Inverno", new Guid("e589fadb-0cda-4397-9301-f14e0fb7832b") },
                    { new Guid("db092ea6-2f6e-4c14-96f2-29cff514029b"), 7.0999999999999996, new Guid("f5da3b48-59d6-46d9-b407-5f7d376285e2"), new Guid("177cb837-9acd-4adc-85e7-983156b77189"), new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8125), null, false, null, "Quiet Riot", new Guid("72e7e09e-2640-4db2-910a-84c1401f4c26") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bans_UserId",
                table: "Bans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_CountryId",
                table: "Beers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_StyleId",
                table: "Beers",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Breweries_CountryId",
                table: "Breweries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReviewId",
                table: "Comments",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentUserId_CommentReviewId",
                table: "Comments",
                columns: new[] { "CommentUserId", "CommentReviewId" });

            migrationBuilder.CreateIndex(
                name: "IX_DrankLists_BeerId",
                table: "DrankLists",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BeerId",
                table: "Reviews",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_ReviewId",
                table: "Vote",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_UserId",
                table: "Vote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_CommentUserId_CommentReviewId",
                table: "Vote",
                columns: new[] { "CommentUserId", "CommentReviewId" });

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_BeerId",
                table: "WishLists",
                column: "BeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "DrankLists");

            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Breweries");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
