using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasExpired",
                table: "Bans");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43a08cc4-76ae-46d8-9e2c-cde7b0479146"),
                column: "ConcurrencyStamp",
                value: "db13bde7-6ba5-4d88-9524-20aac5332cbb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cdde12b9-e61a-4748-a239-c7331b4fb6a8"),
                column: "ConcurrencyStamp",
                value: "c6790b11-9de0-4a98-bf97-ddba044e7183");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aea4f481-df4b-4272-9d12-022293d98e48"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "DeletedOn", "ModifiedOn", "PasswordHash" },
                values: new object[] { "efa1be26-1603-461f-b6e0-065bbfbcb344", new DateTime(2020, 5, 4, 22, 41, 7, 634, DateTimeKind.Utc).AddTicks(8798), new DateTime(2020, 5, 4, 22, 41, 7, 634, DateTimeKind.Utc).AddTicks(1390), new DateTime(2020, 5, 4, 22, 41, 7, 634, DateTimeKind.Utc).AddTicks(1245), "AQAAAAEAACcQAAAAEJJzHWrZZ7vn/m8VbNOxX17DPYUkcHKiFfHv98OBqwIvpKkmCYg/O9P+K4ou+lkLXA==" });

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("1f6a31a3-b955-4190-b961-bd2b105e5103"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 633, DateTimeKind.Utc).AddTicks(1136));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("3efd593f-c900-4b05-80dc-e580a07bb7d2"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 633, DateTimeKind.Utc).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("55742482-9d52-4272-92b6-60b5c417b924"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 633, DateTimeKind.Utc).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("6b99474b-00bd-42ed-8a46-48dc16f94ff8"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 633, DateTimeKind.Utc).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("6f6bd8b0-a68e-4409-bcda-15dbe334a26d"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 633, DateTimeKind.Utc).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("72bb2fe8-9b56-4bef-8941-e986b806ce98"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 633, DateTimeKind.Utc).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("bdbfa744-0f6c-4fd2-99cf-8867fb4b4b92"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 633, DateTimeKind.Utc).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("db092ea6-2f6e-4c14-96f2-29cff514029b"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 633, DateTimeKind.Utc).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("e23347c0-3a21-4f50-9d5c-c46253ee0715"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 633, DateTimeKind.Utc).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("16e01b0a-827e-45af-bcc8-ccf753f4d462"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 631, DateTimeKind.Utc).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("18112ada-2fc5-41e1-8917-6ebfd4c4a0b7"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 631, DateTimeKind.Utc).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("1aee9ea3-390a-4582-ac37-7a6020ec1553"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 631, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("4a3757a9-41bc-4f3c-a5b4-7765aa38fac4"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 631, DateTimeKind.Utc).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("52547555-abb7-425a-9818-7eadf0d90e8b"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 631, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("551e3fa1-4d24-420d-8058-d3dd4118f500"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 631, DateTimeKind.Utc).AddTicks(7592));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("66dae4ad-753d-4170-90a7-5d58756b757f"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 631, DateTimeKind.Utc).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("e77ba42b-d8b0-41d9-ba13-98cba75ce8bc"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 631, DateTimeKind.Utc).AddTicks(7600));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("f5da3b48-59d6-46d9-b407-5f7d376285e2"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 631, DateTimeKind.Utc).AddTicks(7622));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0bab8f8f-0400-4573-9ddc-35850d47cb94"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 629, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e03d656-60cc-476b-9c4a-e12d771dbd62"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 629, DateTimeKind.Utc).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("177cb837-9acd-4adc-85e7-983156b77189"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 629, DateTimeKind.Utc).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("217193b7-0dc9-4ffa-a161-9cba9c8fbccb"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 629, DateTimeKind.Utc).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("29473585-5e82-4cfc-844e-0c371a6690d6"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 629, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("70a47634-234c-4105-b464-9cf3d7043b44"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 629, DateTimeKind.Utc).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7d4928db-2eb4-4cb9-9372-2a8cb8871615"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 629, DateTimeKind.Utc).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("917bf455-9b03-41f3-923b-65b65983f916"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 629, DateTimeKind.Utc).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("940ce711-c272-46bd-9aa4-9cf64cfd7d3a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 629, DateTimeKind.Utc).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("0db937ea-3513-4ce7-b3f6-80ae7474bef2"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 632, DateTimeKind.Utc).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("0e679a3c-5555-4a27-b0fa-594fba01ed68"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 632, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("20d79115-03e0-4123-8994-b0f2ceb45ca8"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 632, DateTimeKind.Utc).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("32bd8b79-eac4-456c-b87d-0bed55087031"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 632, DateTimeKind.Utc).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("44fdbf01-64b7-4869-ba2f-84290f10bc1f"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 632, DateTimeKind.Utc).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("4ae1546e-9cc2-4f52-88f8-86077ae4bd36"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 632, DateTimeKind.Utc).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("72e7e09e-2640-4db2-910a-84c1401f4c26"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 632, DateTimeKind.Utc).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("953d28bf-c7f4-4824-ada9-b67d4256c28c"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 632, DateTimeKind.Utc).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("e589fadb-0cda-4397-9301-f14e0fb7832b"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 41, 7, 632, DateTimeKind.Utc).AddTicks(1414));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasExpired",
                table: "Bans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43a08cc4-76ae-46d8-9e2c-cde7b0479146"),
                column: "ConcurrencyStamp",
                value: "54b1e5d2-97fa-4f10-8ed5-73512efd35ee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cdde12b9-e61a-4748-a239-c7331b4fb6a8"),
                column: "ConcurrencyStamp",
                value: "b3ce00d8-e7ea-4450-aa70-4e1e5e23c7d6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aea4f481-df4b-4272-9d12-022293d98e48"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "DeletedOn", "ModifiedOn", "PasswordHash" },
                values: new object[] { "0bdefc90-8ae3-4e72-a612-ac57046e82f8", new DateTime(2020, 5, 4, 22, 26, 45, 988, DateTimeKind.Utc).AddTicks(4037), new DateTime(2020, 5, 4, 22, 26, 45, 987, DateTimeKind.Utc).AddTicks(8191), new DateTime(2020, 5, 4, 22, 26, 45, 987, DateTimeKind.Utc).AddTicks(8075), "AQAAAAEAACcQAAAAEAOOh2hKDbHYKvsjk9MbpditrGzAUdexFoA5qr0EqxuhLVp+nZ231cTsKuw8ypzGRQ==" });

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("1f6a31a3-b955-4190-b961-bd2b105e5103"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("3efd593f-c900-4b05-80dc-e580a07bb7d2"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("55742482-9d52-4272-92b6-60b5c417b924"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("6b99474b-00bd-42ed-8a46-48dc16f94ff8"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("6f6bd8b0-a68e-4409-bcda-15dbe334a26d"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("72bb2fe8-9b56-4bef-8941-e986b806ce98"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("bdbfa744-0f6c-4fd2-99cf-8867fb4b4b92"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("db092ea6-2f6e-4c14-96f2-29cff514029b"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("e23347c0-3a21-4f50-9d5c-c46253ee0715"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 986, DateTimeKind.Utc).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("16e01b0a-827e-45af-bcc8-ccf753f4d462"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("18112ada-2fc5-41e1-8917-6ebfd4c4a0b7"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("1aee9ea3-390a-4582-ac37-7a6020ec1553"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("4a3757a9-41bc-4f3c-a5b4-7765aa38fac4"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("52547555-abb7-425a-9818-7eadf0d90e8b"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("551e3fa1-4d24-420d-8058-d3dd4118f500"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("66dae4ad-753d-4170-90a7-5d58756b757f"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("e77ba42b-d8b0-41d9-ba13-98cba75ce8bc"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("f5da3b48-59d6-46d9-b407-5f7d376285e2"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0bab8f8f-0400-4573-9ddc-35850d47cb94"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e03d656-60cc-476b-9c4a-e12d771dbd62"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("177cb837-9acd-4adc-85e7-983156b77189"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("217193b7-0dc9-4ffa-a161-9cba9c8fbccb"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(7002));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("29473585-5e82-4cfc-844e-0c371a6690d6"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("70a47634-234c-4105-b464-9cf3d7043b44"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(7007));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7d4928db-2eb4-4cb9-9372-2a8cb8871615"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(6986));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("917bf455-9b03-41f3-923b-65b65983f916"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("940ce711-c272-46bd-9aa4-9cf64cfd7d3a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 982, DateTimeKind.Utc).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("0db937ea-3513-4ce7-b3f6-80ae7474bef2"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("0e679a3c-5555-4a27-b0fa-594fba01ed68"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("20d79115-03e0-4123-8994-b0f2ceb45ca8"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("32bd8b79-eac4-456c-b87d-0bed55087031"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("44fdbf01-64b7-4869-ba2f-84290f10bc1f"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("4ae1546e-9cc2-4f52-88f8-86077ae4bd36"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("72e7e09e-2640-4db2-910a-84c1401f4c26"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("953d28bf-c7f4-4824-ada9-b67d4256c28c"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: new Guid("e589fadb-0cda-4397-9301-f14e0fb7832b"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 22, 26, 45, 985, DateTimeKind.Utc).AddTicks(7046));
        }
    }
}
