﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetterBuiltWorkouts.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTypes",
                columns: table => new
                {
                    ExerciseTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypes", x => x.ExerciseTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseTypeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseTypes_ExerciseTypeID",
                        column: x => x.ExerciseTypeID,
                        principalTable: "ExerciseTypes",
                        principalColumn: "ExerciseTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c85e47b-2d6f-49dc-8f86-1d6dd77cf1af", "3c85e47b-2d6f-49dc-8f86-1d6dd77cf1af", "Admin", "ADMIN" },
                    { "d2172027-e924-4bbd-be5e-53db9e571f14", "d2172027-e924-4bbd-be5e-53db9e571f14", "Suspended", "SUSPENDED" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9f39f31d-16ad-49f3-942a-2a2909cd14aa", 0, "4a6334f8-5960-42d2-a1e6-84412d8efe16", "drewxcom@gmail.com", true, "Drew", "Crawford", false, null, "DREWXCOM@GMAIL.COM", "DREWXCOM", "AQAAAAEAACcQAAAAEF1X2bVQ0lIAQAA7wkQjGeJcfexP1XaALqFD0N9VlNTjJEZsmVeuWExe1gK43gyZ9g==", null, false, "c8da601d-21b4-4188-acc1-05b949aac5f5", false, "drewxcom" },
                    { "1720a676-602c-4083-bd1f-8813be8cfb7e", 0, "213f441a-a1d8-46c1-b6aa-71c08a930217", "hale.l.c91@gmail.com", true, "Cody", "Hale", false, null, "HALE.L.C91@GMAIL.COM", "CHALE", "AQAAAAEAACcQAAAAEBZVwKX2wGJE2Y+NfnrHdTT8r6w/6McTy9Z1krg9kUE+U6A6etPj3vkhJKexOfR9NQ==", null, false, "024ab306-93f2-46aa-b6cf-362b06e4b900", false, "chale" },
                    { "cde303cf-f9a0-4886-9a97-eda149f6aa69", 0, "54596207-9bfa-4317-b4f3-5a5690a37d60", "Karamuja.sabina@gmail.com", true, "Sabina", "Johnson", false, null, "KARAMUJA.SABINA@GMAIL.COM", "SKARAMUJA", "AQAAAAEAACcQAAAAEPu1/3Ic2eXTD6dlYfTz8NIT4dCULdANkT7GNxtJRcaPnOJxtNG8yrHri6I+VMX0Nw==", null, false, "92324e7c-ced5-44b5-9413-58cdf6376876", false, "skaramuja" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "ExerciseTypeID", "Name" },
                values: new object[,]
                {
                    { "aerobic", "Aerobic" },
                    { "strength_training", "Strength Training" },
                    { "streching", "Stretching" },
                    { "balance", "Balance" },
                    { "other", "Other" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3c85e47b-2d6f-49dc-8f86-1d6dd77cf1af", "cde303cf-f9a0-4886-9a97-eda149f6aa69" },
                    { "3c85e47b-2d6f-49dc-8f86-1d6dd77cf1af", "1720a676-602c-4083-bd1f-8813be8cfb7e" },
                    { "3c85e47b-2d6f-49dc-8f86-1d6dd77cf1af", "9f39f31d-16ad-49f3-942a-2a2909cd14aa" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "CreatedBy", "Distance", "ExerciseTypeID", "Image", "IsPublic", "Link", "Name", "Note", "Reps", "Time", "Weight" },
                values: new object[,]
                {
                    { 57, null, null, "balance", "BandedTriplanarToeTaps.png", true, null, "Banded Triplanar Toe Taps", null, null, null, null },
                    { 20, null, null, "strength_training", "LegExtension.png", true, null, "Leg Extension", null, null, null, null },
                    { 21, null, null, "strength_training", "LegPress.png", true, null, "Leg Press", null, null, null, null },
                    { 22, null, null, "strength_training", "Lunge.png", true, null, "Lunge", null, null, null, null },
                    { 25, null, null, "strength_training", "PullDown.png", true, null, "Pull-down", null, null, null, null },
                    { 26, null, null, "strength_training", "PullUp.png", true, null, "Pull-up", null, null, null, null },
                    { 27, null, null, "strength_training", "PushUps.png", true, null, "Push-ups", null, null, null, null },
                    { 30, null, null, "strength_training", "SeatedCalfRaise.png", true, null, "Seated Calf Raise", null, null, null, null },
                    { 31, null, null, "strength_training", "ShoulderPress.png", true, null, "Shoulder Press", null, null, null, null },
                    { 32, null, null, "strength_training", "ShoulderShrug.png", true, null, "Shoulder Shrug", null, null, null, null },
                    { 34, null, null, "strength_training", "Squat.png", true, null, "Squat", null, null, null, null },
                    { 36, null, null, "strength_training", "StandingCalfRaise.png", true, null, "Standing Calf Raise", null, null, null, null },
                    { 41, null, null, "strength_training", "TricepExtension.png", true, null, "Tricep Extension", null, null, null, null },
                    { 43, null, null, "strength_training", "UprightRow.png", true, null, "Upright Row", null, null, null, null },
                    { 48, null, null, "streching", "HamstringStretch.png", true, null, "Hamstring Stretch", null, null, null, null },
                    { 49, null, null, "streching", "QuadricepsStretch.png", true, null, "Quadriceps Stretch", null, null, null, null },
                    { 50, null, null, "streching", "HipFlexorsStretch.png", true, null, "Hip Flexors Stretch", null, null, null, null },
                    { 51, null, null, "streching", "KneeToChestStretch.png", true, null, "Knee-to-Chest Stretch", null, null, null, null },
                    { 52, null, null, "streching", "ShoulderStretch.png", true, null, "Shoulder Stretch", null, null, null, null },
                    { 53, null, null, "streching", "NeckStretch.png", true, null, "Neck Stretch", null, null, null, null },
                    { 24, null, null, "balance", "Pilates.png", true, null, "Pilates", null, null, null, null },
                    { 39, null, null, "balance", "TaiChi.png", true, null, "Tai Chi", null, null, null, null },
                    { 54, null, null, "balance", "TightropeWalk.png", true, null, "Tightrope Walk", null, null, null, null },
                    { 55, null, null, "balance", "FlamingoStand.png", true, null, "Flamingo Stand", null, null, null, null },
                    { 56, null, null, "balance", "HeelToToeWalk.png", true, null, "Heel-to-Toe Walk", null, null, null, null },
                    { 19, null, null, "strength_training", "LegCurl.png", true, null, "Leg Curl", null, null, null, null },
                    { 47, null, null, "streching", "CalfStretch.png", true, null, "Calf Stretch", null, null, null, null },
                    { 18, null, null, "strength_training", "LateralRaise.png", true, null, "Lateral Raise", null, null, null, null },
                    { 10, null, null, "strength_training", "Crunches.png", true, null, "Crunches", null, null, null, null },
                    { 5, null, null, "aerobic", "Biking.png", true, null, "Biking", null, null, null, null },
                    { 6, null, null, "aerobic", "BriskWalking.png", true, null, "Brisk Walking", null, null, null, null },
                    { 7, null, null, "aerobic", "CardioClass.png", true, null, "Cardio Class", null, null, null, null },
                    { 8, null, null, "aerobic", "CardioMachine.png", true, null, "Cardio Machine", null, null, null, null },
                    { 11, null, null, "aerobic", "Dancing.png", true, null, "Dancing", null, null, null, null },
                    { 13, null, null, "aerobic", "GardeningAndWeeding.png", true, null, "Gardening and Weeding", null, null, null, null },
                    { 14, null, null, "aerobic", "Golf.png", true, null, "Golf", null, null, null, null },
                    { 15, null, null, "aerobic", "HighIntensityIntervalTraining.png", true, null, "High-Intensity Interval Training", null, null, null, null },
                    { 16, null, null, "aerobic", "Hiking.png", true, null, "Hiking", null, null, null, null },
                    { 17, null, null, "aerobic", "JoggingOrRunning.png", true, null, "Jogging or Running", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "CreatedBy", "Distance", "ExerciseTypeID", "Image", "IsPublic", "Link", "Name", "Note", "Reps", "Time", "Weight" },
                values: new object[,]
                {
                    { 23, null, null, "aerobic", "LiftingWeights.png", true, null, "Lifting Weights", null, null, null, null },
                    { 28, null, null, "aerobic", "ResistanceExercise.png", true, null, "Resistance Exercise with Elastic Bands or Tubes", null, null, null, null },
                    { 12, null, null, "strength_training", "Deadlift.png", true, null, "Deadlift", null, null, null, null },
                    { 29, null, null, "aerobic", "Rowing.png", true, null, "Rowing", null, null, null, null },
                    { 35, null, null, "aerobic", "Stairs.png", true, null, "Stairs", null, null, null, null },
                    { 37, null, null, "aerobic", "StrengthClass.png", true, null, "Strength Class", null, null, null, null },
                    { 38, null, null, "aerobic", "Swimming.png", true, null, "Swimming", null, null, null, null },
                    { 40, null, null, "aerobic", "Tennis.png", true, null, "Tennis", null, null, null, null },
                    { 42, null, null, "aerobic", "UltimateFrisbee.png", true, null, "Ultimate Frisbee", null, null, null, null },
                    { 44, null, null, "aerobic", "Volleyball.png", true, null, "Volleyball", null, null, null, null },
                    { 45, null, null, "aerobic", "WalkingWithStroller.png", true, null, "Walking with a Stroller", null, null, null, null },
                    { 46, null, null, "aerobic", "Yoga.png", true, null, "Yoga", null, null, null, null },
                    { 1, null, null, "strength_training", "BackExtension.png", true, null, "Back Extension", null, null, null, null },
                    { 3, null, null, "strength_training", "BenchPress.png", true, null, "Bench Press", null, null, null, null },
                    { 4, null, null, "strength_training", "BicepCurl.png", true, null, "Bicep Curl", null, null, null, null },
                    { 9, null, null, "strength_training", "ChestFly.png", true, null, "Chest Fly", null, null, null, null },
                    { 33, null, null, "aerobic", "Soccer.png", true, null, "Soccer", null, null, null, null },
                    { 2, null, null, "aerobic", "Basketball.png", true, null, "Basketball", null, null, null, null }
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
                name: "IX_Exercises_ExerciseTypeID",
                table: "Exercises",
                column: "ExerciseTypeID");
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
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");
        }
    }
}