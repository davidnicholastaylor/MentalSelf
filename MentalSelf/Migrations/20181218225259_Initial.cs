using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalSelf.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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
                    Id = table.Column<string>(nullable: false),
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
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    QuestionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.QuestionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "UserResponse",
                columns: table => new
                {
                    UserResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResponse", x => x.UserResponseId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionDesc = table.Column<string>(nullable: false),
                    QuestionTypeId = table.Column<int>(nullable: false),
                    TestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Question_QuestionType_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionType",
                        principalColumn: "QuestionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTest",
                columns: table => new
                {
                    UserTestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TestId = table.Column<int>(nullable: false),
                    DateTaken = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTest", x => x.UserTestId);
                    table.ForeignKey(
                        name: "FK_UserTest_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    ResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    UserTestId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    UserResponseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Response_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Response_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Response_UserResponse_UserResponseId",
                        column: x => x.UserResponseId,
                        principalTable: "UserResponse",
                        principalColumn: "UserResponseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Response_UserTest_UserTestId",
                        column: x => x.UserTestId,
                        principalTable: "UserTest",
                        principalColumn: "UserTestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "QuestionType",
                columns: new[] { "QuestionTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Depression" },
                    { 13, "Substance Use" },
                    { 12, "Personality Functioning" },
                    { 11, "Dissociation" },
                    { 9, "Memory" },
                    { 8, "Sleep Problems" },
                    { 10, "Repetative Thoughts and Behaviors" },
                    { 6, "Suicidal Ideation" },
                    { 5, "Somatic Symptoms" },
                    { 4, "Anxiety" },
                    { 3, "Mania" },
                    { 2, "Anger" },
                    { 7, "Psychosis" }
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "TestId", "Title" },
                values: new object[] { 1, "Level 1 Cross-Cutting Symptom Measure—Adult" });

            migrationBuilder.InsertData(
                table: "UserResponse",
                columns: new[] { "UserResponseId", "Rating" },
                values: new object[,]
                {
                    { 4, "More than half the days" },
                    { 1, "Not at all" },
                    { 2, "Rare, less than a couple days" },
                    { 3, "Several days" },
                    { 5, "Nearly every day" }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "QuestionId", "QuestionDesc", "QuestionTypeId", "TestId" },
                values: new object[,]
                {
                    { 1, "1. Little interest or pleasure in doing things?", 1, 1 },
                    { 21, "21. Drinking at least 4 drinks of any kind of alcohol in a single day?", 13, 1 },
                    { 20, "20. Not feeling close to other people or enjoying your relationships with them?", 12, 1 },
                    { 19, "19. Not knowing who you really are or what you want out of life?", 12, 1 },
                    { 18, "18. Feeling detached or distant from yourself, your body, your physical surroundings, or your memories?", 11, 1 },
                    { 17, "17. Feeling driven to perform certain behaviors or mental acts over and over again?", 10, 1 },
                    { 16, "16. Unpleasant thoughts, urges, or images that repeatedly enter your mind?", 10, 1 },
                    { 15, "15. Problems with memory (e.g., learning new information) or with location (e.g., finding your way home)? ", 9, 1 },
                    { 14, "14. Problems with sleep that affected your sleep quality over all?", 8, 1 },
                    { 13, "13. Feeling that someone could hear your thoughts, or that you could hear what another person was thinking?", 7, 1 },
                    { 22, "22. Smoking any cigarettes, a cigar, or pipe, or using snuff or chewing tobacco?", 13, 1 },
                    { 12, "12.Hearing things other people couldn’t hear, such as voices even when no one was around ?", 7, 1 },
                    { 10, "10. Feeling that your illnesses are not being taken seriously enough?", 5, 1 },
                    { 9, "9. Unexplained aches and pains (e.g., head, back, joints, abdomen, legs)?", 5, 1 },
                    { 8, "8. Avoiding situations that make you anxious?", 4, 1 },
                    { 7, "7. Feeling panic or being frightened?", 4, 1 },
                    { 6, "6. Feeling nervous, anxious, frightened, worried, or on edge?", 4, 1 },
                    { 5, "5. Starting lots more projects than usual or doing more risky things than usual?", 3, 1 },
                    { 4, "4. Sleeping less than usual, but still have a lot of energy?", 3, 1 },
                    { 3, "3. Feeling more irritated, grouchy, or angry than usual?", 2, 1 },
                    { 2, "2. Feeling down, depressed, or hopeless?", 1, 1 },
                    { 11, "11. Thoughts of actually hurting yourself?", 6, 1 },
                    { 23, "23. Using any of the following medicines ON YOUR OWN, that is, without a doctor’s prescription, in greater amounts or longer than prescribed [e.g., painkillers (like Vicodin), stimulants (like Ritalin or Adderall), sedatives or tranquilizers (like sleeping pills or Valium), or drugs like marijuana, cocaine or crack, club drugs (like ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)]?", 13, 1 }
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
                name: "IX_Question_QuestionTypeId",
                table: "Question",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_TestId",
                table: "Question",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_QuestionId",
                table: "Response",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_UserId",
                table: "Response",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_UserResponseId",
                table: "Response",
                column: "UserResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_UserTestId",
                table: "Response",
                column: "UserTestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_TestId",
                table: "UserTest",
                column: "TestId");
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
                name: "Response");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserResponse");

            migrationBuilder.DropTable(
                name: "UserTest");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
