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
                    Type = table.Column<string>(nullable: false),
                    Threshold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.QuestionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RatingAmount = table.Column<double>(nullable: false),
                    RatingDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTest",
                columns: table => new
                {
                    UserTestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TestId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTest_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    RatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Response_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Response_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Response_UserTest_UserTestId",
                        column: x => x.UserTestId,
                        principalTable: "UserTest",
                        principalColumn: "UserTestId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "QuestionType",
                columns: new[] { "QuestionTypeId", "Threshold", "Type" },
                values: new object[,]
                {
                    { 1, 2, "Depression" },
                    { 16, 2, "Anger and Irritability" },
                    { 15, 2, "Irritability" },
                    { 14, 1, "Inattention" },
                    { 13, 1, "Substance Use" },
                    { 11, 2, "Dissociation" },
                    { 10, 2, "Repetative Thoughts and Behaviors" },
                    { 9, 2, "Memory" },
                    { 12, 2, "Personality Functioning" },
                    { 7, 1, "Psychosis" },
                    { 6, 1, "Suicidal Ideation" },
                    { 5, 2, "Somatic Symptoms" },
                    { 4, 2, "Anxiety" },
                    { 3, 2, "Mania" },
                    { 2, 2, "Anger" },
                    { 8, 2, "Sleep Problems" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingId", "RatingAmount", "RatingDescription" },
                values: new object[,]
                {
                    { 1, 0.0, "Not at all" },
                    { 2, 1.0, "Rare, less than a couple days" },
                    { 3, 2.0, "Several days" },
                    { 4, 3.0, "More than half the days" },
                    { 5, 4.0, "Nearly every day" }
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "TestId", "Title" },
                values: new object[,]
                {
                    { 2, "Child Age 11-17 Level 1 Cross-Cutting Symptom Measure, Self-Rated" },
                    { 1, "Adult Level 1 Cross-Cutting Symptom Measure, Self-Rated" },
                    { 3, "Child Age 6-17 Level 1 Cross-Cutting Symptom Measure, Parent/Guardian-Rated" }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "QuestionId", "QuestionDesc", "QuestionTypeId", "TestId" },
                values: new object[,]
                {
                    { 1, "1. Little interest or pleasure in doing things?", 1, 1 },
                    { 52, "4. Had problems paying attention when they were in class or doing their homework or reading a book or playing a game?", 14, 3 },
                    { 51, "3. Had problems sleeping—that is, trouble falling asleep, staying asleep, or waking up too early?", 8, 3 },
                    { 50, "2. Said they were worried about their health or about getting sick?", 5, 3 },
                    { 49, "1. Complained of stomachaches, headaches, or other aches and pains?", 5, 3 },
                    { 48, "25. Have you EVER tried to kill yourself?", 6, 2 },
                    { 47, "24. In the last 2 weeks, have you thought about killing yourself or committing suicide?", 6, 2 },
                    { 53, "5. Had less fun doing things than they used to?", 1, 3 },
                    { 46, "23. Used any medicine without a doctor’s prescription to get high or change the way you feel (e.g., painkillers [like Vicodin], stimulants [like Ritalin or Adderall], sedatives or tranquilizers [like sleeping pills or Valium], or steroids)?", 13, 2 },
                    { 44, "21. Smoked a cigarette, a cigar, or pipe, or used snuff or chewing tobacco?", 13, 2 },
                    { 43, "20. Had an alcoholic beverage (beer, wine, liquor, etc.)?", 13, 2 },
                    { 42, "19. Felt you had to do things in a certain way, like counting or saying special things, to keep something bad from happening?", 10, 2 },
                    { 41, "18. Worried a lot about things you touched being dirty or having germs or being poisoned?", 10, 2 },
                    { 40, "17. Felt the need to check on certain things over and over again, like whether a door was locked or whether the stove was turned off?", 10, 2 },
                    { 39, "16. Had thoughts that kept coming into your mind that you would do something bad or that something bad would happen to you or to someone else?", 10, 2 },
                    { 45, "22. Used drugs like marijuana, cocaine or crack, club drugs (like Ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)?", 13, 2 },
                    { 54, "6. Seemed sad or depressed for several hours?", 1, 3 },
                    { 55, "7. Seemed more irritated or easily annoyed than usual?", 16, 3 },
                    { 56, "8. Seemed angry or lost their temper?", 16, 3 },
                    { 71, "23. Used any medicine without a doctor’s prescription (e.g., painkillers [like Vicodin], stimulants [like Ritalin or Adderall], sedatives or tranquilizers [like sleeping pills or Valium], or steroids)?", 13, 3 },
                    { 70, "22. Used drugs like marijuana, cocaine or crack, club drugs (like ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)?", 13, 3 },
                    { 69, "21. Smoked a cigarette, a cigar, or pipe, or used snuff or chewing tobacco?", 13, 3 },
                    { 68, "20. Had an alcoholic beverage (beer, wine, liquor, etc.)?", 13, 3 },
                    { 67, "19. Said that they had to do things in a certain way, like counting or saying special things out loud, in order to keep something bad from happening?", 10, 3 },
                    { 66, "18. Seemed to worry a lot about things they touched being dirty or having germs or being poisoned?", 10, 3 },
                    { 65, "17. Said they felt the need to check on certain things over and over again, like whether a door was locked or whether the stove was turned off?", 10, 3 },
                    { 64, "16. Said that they had thoughts that kept coming into their mind that they would do something bad or that something bad would happen to themself or to someone else?", 10, 3 },
                    { 63, "15. Said that they had a vision when they were completely awake—that is, saw something or someone that no one else could see?", 7, 3 },
                    { 62, "14. Said that they heard voices—when there was no one there—speaking about themself or telling them what to do or saying bad things to themself?", 7, 3 },
                    { 61, "13. Said they couldn’t do things they wanted to or should have done, because those things made them feel nervous?", 4, 3 },
                    { 60, "12. Not been able to stop worrying?", 4, 3 },
                    { 59, "11. Said they felt nervous, anxious, or scared?", 4, 3 },
                    { 58, "10. Slept less than usual for them, but still had lots of energy?", 3, 3 },
                    { 57, "9. Started lots more projects than usual or did more risky things than usual?", 3, 3 },
                    { 38, "15. Had visions when you were completely awake—that is, seen something or someone that no one else could see?", 7, 2 },
                    { 72, "24. In the past TWO (2) WEEKS, have they talked about wanting to kill themself or about wanting to commit suicide?", 6, 3 },
                    { 37, "14. Heard voices—when there was no one there—speaking about you or telling you what to do or saying bad things to you?", 7, 2 },
                    { 35, "12. Not been able to stop worrying?", 4, 2 },
                    { 15, "15. Problems with memory (e.g., learning new information) or with location (e.g., finding your way home)? ", 9, 1 },
                    { 14, "14. Problems with sleep that affected your sleep quality over all?", 8, 1 },
                    { 13, "13. Feeling that someone could hear your thoughts, or that you could hear what another person was thinking?", 7, 1 },
                    { 12, "12.Hearing things other people couldn’t hear, such as voices even when no one was around?", 7, 1 },
                    { 11, "11. Thoughts of actually hurting yourself?", 6, 1 },
                    { 10, "10. Feeling that your illnesses are not being taken seriously enough?", 5, 1 },
                    { 16, "16. Unpleasant thoughts, urges, or images that repeatedly enter your mind?", 10, 1 },
                    { 9, "9. Unexplained aches and pains (e.g., head, back, joints, abdomen, legs)?", 5, 1 },
                    { 7, "7. Feeling panic or being frightened?", 4, 1 },
                    { 6, "6. Feeling nervous, anxious, frightened, worried, or on edge?", 4, 1 },
                    { 5, "5. Starting lots more projects than usual or doing more risky things than usual?", 3, 1 },
                    { 4, "4. Sleeping less than usual, but still have a lot of energy?", 3, 1 },
                    { 3, "3. Feeling more irritated, grouchy, or angry than usual?", 2, 1 },
                    { 2, "2. Feeling down, depressed, or hopeless?", 1, 1 },
                    { 8, "8. Avoiding situations that make you anxious?", 4, 1 },
                    { 17, "17. Feeling driven to perform certain behaviors or mental acts over and over again?", 10, 1 },
                    { 18, "18. Feeling detached or distant from yourself, your body, your physical surroundings, or your memories?", 11, 1 },
                    { 19, "19. Not knowing who you really are or what you want out of life?", 12, 1 },
                    { 34, "11. Felt nervous, anxious, or scared?", 4, 2 },
                    { 33, "10. Slept less than usual but still had a lot of energy?", 3, 2 },
                    { 32, "9. Started lots more projects than usual or done more risky things than usual?", 3, 2 },
                    { 31, "8. Felt angry or lost your temper?", 16, 2 },
                    { 30, "7. Felt more irritated or easily annoyed than usual?", 16, 2 },
                    { 29, "6. Felt sad or depressed for several hours?", 1, 2 },
                    { 28, "5. Had less fun doing things than you used to?", 1, 2 },
                    { 27, "4. Been bothered by not being able to pay attention when you were in class or doing homework or reading a book or playing a game?", 14, 2 },
                    { 26, "3. Been bothered by not being able to fall asleep or stay asleep, or by waking up too early?", 8, 2 },
                    { 25, "2. Worried about your health or about getting sick?", 5, 2 },
                    { 24, "1. Been bothered by stomachaches, headaches, or other aches and pains?", 5, 2 },
                    { 23, "23. Using any of the following medicines ON YOUR OWN, that is, without a doctor’s prescription, in greater amounts or longer than prescribed [e.g., painkillers (like Vicodin), stimulants (like Ritalin or Adderall), sedatives or tranquilizers (like sleeping pills or Valium), or drugs like marijuana, cocaine or crack, club drugs (like ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)]?", 13, 1 },
                    { 22, "22. Smoking any cigarettes, a cigar, or pipe, or using snuff or chewing tobacco?", 13, 1 },
                    { 21, "21. Drinking at least 4 drinks of any kind of alcohol in a single day?", 13, 1 },
                    { 20, "20. Not feeling close to other people or enjoying your relationships with them?", 12, 1 },
                    { 36, "13. Not been able to do things you wanted to or should have done, because they made you feel nervous?", 4, 2 },
                    { 73, "25. Have they EVER tried to kill themself", 6, 3 }
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
                name: "IX_Response_RatingId",
                table: "Response",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_UserTestId",
                table: "Response",
                column: "UserTestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_TestId",
                table: "UserTest",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_UserId",
                table: "UserTest",
                column: "UserId");
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
                name: "Rating");

            migrationBuilder.DropTable(
                name: "UserTest");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
