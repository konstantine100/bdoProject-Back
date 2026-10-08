using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bdoProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DepartmentCode = table.Column<int>(type: "integer", nullable: false),
                    DepartmentName = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<string>(type: "text", nullable: false),
                    EmploymentType = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ProbationEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ManagerId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveEntitlements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    LeaveType = table.Column<int>(type: "integer", nullable: false),
                    EntitledDays = table.Column<int>(type: "integer", nullable: false),
                    CarriedOverDays = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveEntitlements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<string>(type: "text", nullable: false),
                    LeaveType = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Days = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedVia = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeaveTypes = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DayUnit = table.Column<int>(type: "integer", nullable: false),
                    AnnualLimitDays = table.Column<int>(type: "integer", nullable: true),
                    SelfService = table.Column<int>(type: "integer", nullable: false),
                    AssistantSupported = table.Column<int>(type: "integer", nullable: false),
                    PolicyReference = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "DepartmentCode", "DepartmentName", "Email", "EmployeeId", "EmploymentType", "FullName", "JobTitle", "ManagerId", "ProbationEndDate", "Role", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "აუდიტი და მარწმუნებელი მომსახურება", "nino.beridze@northstar.example", "E1001", 0, "ნინო ბერიძე", "უფროსი აუდიტორი", "E1010", new DateOnly(2019, 6, 3), 1, new DateOnly(2019, 3, 4), 0, null },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "საკონსულტაციო მომსახურება", "aleksandre.kapanadze@northstar.example", "E1002", 0, "ალექსანდრე კაპანაძე", "კონსულტანტი", "E1011", new DateOnly(2024, 9, 9), 1, new DateOnly(2024, 6, 10), 0, null },
                    { 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "საგადასახადო მომსახურება", "ketevan.lomidze@northstar.example", "E1003", 0, "ქეთევან ლომიძე", "საგადასახადო მენეჯერი", "E1012", new DateOnly(2014, 12, 14), 1, new DateOnly(2014, 9, 15), 0, null },
                    { 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "ტექნოლოგიები და ავტომატიზაცია", "luka.tsiklauri@northstar.example", "E1004", 0, "ლუკა წიკლაური", "ავტომატიზაციის უმცროსი დეველოპერი", "E1013", new DateOnly(2026, 11, 30), 1, new DateOnly(2026, 9, 1), 0, null },
                    { 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "აუდიტი და მარწმუნებელი მომსახურება", "ana.gelashvili@northstar.example", "E1005", 0, "ანა გელაშვილი", "აუდიტის ასოცირებული სპეციალისტი", "E1010", new DateOnly(2023, 4, 30), 1, new DateOnly(2023, 2, 1), 0, null },
                    { 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "საკონსულტაციო მომსახურება", "davit.maisuradze@northstar.example", "E1006", 0, "დავით მაისურაძე", "უფროსი კონსულტანტი", "E1011", new DateOnly(2021, 8, 16), 1, new DateOnly(2021, 5, 17), 0, null },
                    { 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, "ადამიანური რესურსების სამსახური", "tamar.jorjadze@northstar.example", "E1007", 0, "თამარ ჯორჯაძე", "HR ბიზნეს პარტნიორი", "E1014", new DateOnly(2020, 4, 12), 0, new DateOnly(2020, 1, 13), 0, null },
                    { 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, "ფინანსები და ადმინისტრირება", "levan.abashidze@northstar.example", "E1008", 0, "ლევან აბაშიძე", "ბუღალტერი", "E1014", new DateOnly(2022, 10, 31), 1, new DateOnly(2022, 8, 1), 0, null },
                    { 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "ტექნოლოგიები და ავტომატიზაცია", "salome.khutsishvili@northstar.example", "E1009", 0, "სალომე ხუციშვილი", "ავტომატიზაციის კონსულტანტი", "E1013", new DateOnly(2022, 4, 9), 1, new DateOnly(2022, 1, 10), 0, null },
                    { 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "აუდიტი და მარწმუნებელი მომსახურება", "irakli.nozadze@northstar.example", "E1010", 0, "ირაკლი ნოზაძე", "აუდიტის მენეჯერი", null, new DateOnly(2015, 6, 30), 1, new DateOnly(2015, 4, 1), 0, null },
                    { 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "საკონსულტაციო მომსახურება", "eka.chkheidze@northstar.example", "E1011", 0, "ეკა ჩხეიძე", "საკონსულტაციო მენეჯერი", null, new DateOnly(2018, 1, 1), 1, new DateOnly(2017, 10, 2), 0, null },
                    { 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "საგადასახადო მომსახურება", "beka.kavtaradze@northstar.example", "E1012", 0, "ბექა ქავთარაძე", "საგადასახადო დირექტორი", null, new DateOnly(2013, 6, 17), 1, new DateOnly(2013, 3, 18), 0, null },
                    { 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "ტექნოლოგიები და ავტომატიზაცია", "teona.gogoladze@northstar.example", "E1013", 0, "თეონა გოგოლაძე", "ავტომატიზაციის მენეჯერი", null, new DateOnly(2018, 5, 18), 1, new DateOnly(2018, 2, 19), 0, null },
                    { 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, "ფინანსები და ადმინისტრირება", "nika.shengelia@northstar.example", "E1014", 0, "ნიკა შენგელია", "ფინანსური დირექტორი", null, new DateOnly(2016, 9, 5), 1, new DateOnly(2016, 6, 6), 0, null }
                });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "CreatedAt", "Date", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 1, 1), "ახალი წელი", null },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 1, 2), "ახალი წელი", null },
                    { 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 1, 7), "შობა", null },
                    { 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 1, 19), "ნათლისღება", null },
                    { 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 3, 3), "დედის დღე", null },
                    { 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 3, 8), "ქალთა საერთაშორისო დღე", null },
                    { 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 4, 9), "ეროვნული ერთიანობის დღე", null },
                    { 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 4, 10), "დიდი პარასკევი", null },
                    { 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 4, 11), "დიდი შაბათი", null },
                    { 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 4, 12), "აღდგომა", null },
                    { 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 4, 13), "აღდგომის ორშაბათი", null },
                    { 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 5, 9), "ფაშიზმზე გამარჯვების დღე", null },
                    { 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 5, 12), "წმინდა ანდრია პირველწოდებულის დღე", null },
                    { 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 5, 26), "დამოუკიდებლობის დღე", null },
                    { 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 8, 28), "მარიამობა", null },
                    { 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 10, 14), "სვეტიცხოვლობა", null },
                    { 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2026, 11, 23), "გიორგობა", null },
                    { 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 1, 1), "ახალი წელი", null },
                    { 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 1, 2), "ახალი წელი", null },
                    { 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 1, 7), "შობა", null },
                    { 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 1, 19), "ნათლისღება", null },
                    { 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 3, 3), "დედის დღე", null },
                    { 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 3, 8), "ქალთა საერთაშორისო დღე", null },
                    { 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 4, 9), "ეროვნული ერთიანობის დღე", null },
                    { 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 4, 30), "დიდი პარასკევი", null },
                    { 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 5, 1), "დიდი შაბათი", null },
                    { 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 5, 2), "აღდგომა", null },
                    { 28, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 5, 3), "აღდგომის ორშაბათი", null },
                    { 29, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 5, 9), "ფაშიზმზე გამარჯვების დღე", null },
                    { 30, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 5, 12), "წმინდა ანდრია პირველწოდებულის დღე", null },
                    { 31, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 5, 26), "დამოუკიდებლობის დღე", null },
                    { 32, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 8, 28), "მარიამობა", null },
                    { 33, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 10, 14), "სვეტიცხოვლობა", null },
                    { 34, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2027, 11, 23), "გიორგობა", null }
                });

            migrationBuilder.InsertData(
                table: "LeaveEntitlements",
                columns: new[] { "Id", "CarriedOverDays", "CreatedAt", "EmployeeId", "EntitledDays", "LeaveType", "UpdatedAt", "Year" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1001", 25, 0, null, 2026 },
                    { 2, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1001", 10, 1, null, 2026 },
                    { 3, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1001", 5, 4, null, 2026 },
                    { 4, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1001", 30, 2, null, 2026 },
                    { 5, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1002", 24, 0, null, 2026 },
                    { 6, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1002", 10, 1, null, 2026 },
                    { 7, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1002", 5, 4, null, 2026 },
                    { 8, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1002", 30, 2, null, 2026 },
                    { 9, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1003", 26, 0, null, 2026 },
                    { 10, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1003", 10, 1, null, 2026 },
                    { 11, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1003", 5, 4, null, 2026 },
                    { 12, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1003", 30, 2, null, 2026 },
                    { 13, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1004", 8, 0, null, 2026 },
                    { 14, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1004", 10, 1, null, 2026 },
                    { 15, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1004", 5, 4, null, 2026 },
                    { 16, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1004", 30, 2, null, 2026 },
                    { 17, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1005", 24, 0, null, 2026 },
                    { 18, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1005", 10, 1, null, 2026 },
                    { 19, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1005", 5, 4, null, 2026 },
                    { 20, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1005", 30, 2, null, 2026 },
                    { 21, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1006", 25, 0, null, 2026 },
                    { 22, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1006", 10, 1, null, 2026 },
                    { 23, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1006", 5, 4, null, 2026 },
                    { 24, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1006", 30, 2, null, 2026 },
                    { 25, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1007", 25, 0, null, 2026 },
                    { 26, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1007", 10, 1, null, 2026 },
                    { 27, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1007", 5, 4, null, 2026 },
                    { 28, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1007", 30, 2, null, 2026 },
                    { 29, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1008", 24, 0, null, 2026 },
                    { 30, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1008", 10, 1, null, 2026 },
                    { 31, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1008", 5, 4, null, 2026 },
                    { 32, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1008", 30, 2, null, 2026 },
                    { 33, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1009", 24, 0, null, 2026 },
                    { 34, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1009", 10, 1, null, 2026 },
                    { 35, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1009", 5, 4, null, 2026 },
                    { 36, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1009", 30, 2, null, 2026 },
                    { 37, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1010", 26, 0, null, 2026 },
                    { 38, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1010", 10, 1, null, 2026 },
                    { 39, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1010", 5, 4, null, 2026 },
                    { 40, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1010", 30, 2, null, 2026 },
                    { 41, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1011", 25, 0, null, 2026 },
                    { 42, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1011", 10, 1, null, 2026 },
                    { 43, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1011", 5, 4, null, 2026 },
                    { 44, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1011", 30, 2, null, 2026 },
                    { 45, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1012", 26, 0, null, 2026 },
                    { 46, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1012", 10, 1, null, 2026 },
                    { 47, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1012", 5, 4, null, 2026 },
                    { 48, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1012", 30, 2, null, 2026 },
                    { 49, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1013", 25, 0, null, 2026 },
                    { 50, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1013", 10, 1, null, 2026 },
                    { 51, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1013", 5, 4, null, 2026 },
                    { 52, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1013", 30, 2, null, 2026 },
                    { 53, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1014", 26, 0, null, 2026 },
                    { 54, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1014", 10, 1, null, 2026 },
                    { 55, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1014", 5, 4, null, 2026 },
                    { 56, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "E1014", 30, 2, null, 2026 }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "Comment", "CreatedAt", "CreatedVia", "Days", "EmployeeId", "EndDate", "LeaveType", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "პროექტის პარტნიორის თანხმობით", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 5, "E1001", new DateOnly(2026, 2, 20), 0, new DateOnly(2026, 2, 16), 1, null },
                    { 2, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 2, "E1001", new DateOnly(2026, 3, 11), 1, new DateOnly(2026, 3, 10), 1, null },
                    { 3, "გაუქმებულია თანამშრომლის მიერ", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 2, "E1001", new DateOnly(2026, 5, 5), 0, new DateOnly(2026, 5, 4), 3, null },
                    { 4, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 10, "E1001", new DateOnly(2026, 7, 24), 0, new DateOnly(2026, 7, 13), 1, null },
                    { 5, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 3, "E1001", new DateOnly(2026, 11, 11), 0, new DateOnly(2026, 11, 9), 0, null },
                    { 6, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 5, "E1002", new DateOnly(2026, 5, 8), 0, new DateOnly(2026, 5, 4), 1, null },
                    { 7, "ხელმძღვანელის თანხმობით, 15 სამუშაო დღე", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 15, "E1002", new DateOnly(2026, 8, 21), 0, new DateOnly(2026, 8, 3), 1, null },
                    { 8, "უარყოფილია: კლიენტის პროექტის ვადა", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 5, "E1002", new DateOnly(2026, 10, 30), 0, new DateOnly(2026, 10, 26), 2, null },
                    { 9, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 3, "E1003", new DateOnly(2026, 4, 8), 0, new DateOnly(2026, 4, 6), 1, null },
                    { 10, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 5, "E1003", new DateOnly(2026, 6, 19), 0, new DateOnly(2026, 6, 15), 1, null },
                    { 11, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 3, "E1003", new DateOnly(2026, 8, 12), 0, new DateOnly(2026, 8, 10), 1, null },
                    { 12, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 5, "E1005", new DateOnly(2026, 3, 27), 0, new DateOnly(2026, 3, 23), 1, null },
                    { 13, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 4, "E1005", new DateOnly(2026, 8, 28), 0, new DateOnly(2026, 8, 24), 1, null },
                    { 14, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 10, "E1006", new DateOnly(2026, 7, 17), 0, new DateOnly(2026, 7, 6), 1, null },
                    { 15, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 3, "E1006", new DateOnly(2026, 11, 18), 0, new DateOnly(2026, 11, 16), 0, null },
                    { 16, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 10, "E1007", new DateOnly(2026, 6, 12), 0, new DateOnly(2026, 6, 1), 1, null },
                    { 17, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 10, "E1008", new DateOnly(2026, 7, 31), 0, new DateOnly(2026, 7, 20), 1, null },
                    { 18, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 2, "E1008", new DateOnly(2026, 9, 15), 0, new DateOnly(2026, 9, 14), 1, null },
                    { 19, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 2, "E1009", new DateOnly(2026, 1, 21), 1, new DateOnly(2026, 1, 20), 1, null },
                    { 20, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 4, "E1009", new DateOnly(2026, 4, 17), 0, new DateOnly(2026, 4, 14), 1, null },
                    { 21, "AZ-900 გამოცდა", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 1, "E1009", new DateOnly(2026, 6, 5), 4, new DateOnly(2026, 6, 5), 1, null },
                    { 22, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 8, "E1009", new DateOnly(2026, 8, 26), 0, new DateOnly(2026, 8, 17), 1, null },
                    { 23, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 9, "E1010", new DateOnly(2026, 4, 30), 0, new DateOnly(2026, 4, 20), 1, null },
                    { 24, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 10, "E1011", new DateOnly(2026, 8, 21), 0, new DateOnly(2026, 8, 10), 1, null },
                    { 25, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 10, "E1012", new DateOnly(2026, 8, 7), 0, new DateOnly(2026, 7, 27), 1, null },
                    { 26, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 5, "E1013", new DateOnly(2026, 9, 25), 0, new DateOnly(2026, 9, 21), 1, null },
                    { 27, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 10, "E1014", new DateOnly(2026, 7, 3), 0, new DateOnly(2026, 6, 22), 1, null }
                });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "AnnualLimitDays", "AssistantSupported", "CreatedAt", "DayUnit", "LeaveTypes", "Name", "PolicyReference", "SelfService", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 0, "ყოველწლიური ანაზღაურებადი შვებულება", "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 4", 1, null },
                    { 2, 10, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 1, "ავადმყოფობის შვებულება", "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 6", 1, null },
                    { 3, 30, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, "უხელფასო შვებულება", "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 7", 1, null },
                    { 4, null, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 3, "გლოვის შვებულება", "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 8", 1, null },
                    { 5, 5, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 4, "სასწავლო და საგამოცდო შვებულება", "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 9", 1, null },
                    { 6, null, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, 5, "მშობლის შვებულება", "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 10", 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "LeaveEntitlements");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "LeaveTypes");
        }
    }
}
