using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalSelf.Migrations
{
    public partial class TestOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "QuestionTypeID", "Type" },
                values: new object[,]
                {
                    { 1, "Depression" },
                    { 2, "Anger" },
                    { 3, "Mania" },
                    { 4, "Anxiety" },
                    { 5, "Somatic Symptoms" },
                    { 6, "Suicidal Ideation" },
                    { 7, "Psychosis" },
                    { 8, "Sleep Problems" },
                    { 9, "Memory" },
                    { 10, "Repetative Thoughts and Behaviors" },
                    { 11, "Dissociation" },
                    { 12, "Personality Functioning" },
                    { 13, "Substance Use" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "TestID", "Title" },
                values: new object[] { 1, "Level 1 Cross-Cutting Symptom Measure—Adult" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "QuestionDesc", "QuestionTypeId", "TestId" },
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
                    { 10, "10. Feeling that your illnesses are not being taken seriously enough??", 5, 1 },
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "QuestionTypeID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "TestID",
                keyValue: 1);
        }
    }
}
