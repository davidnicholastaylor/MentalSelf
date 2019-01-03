using Microsoft.EntityFrameworkCore.Migrations;

namespace MentalSelf.Migrations
{
    public partial class ChildTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuestionType",
                columns: new[] { "QuestionTypeId", "Type" },
                values: new object[,]
                {
                    { 14, "Inattention" },
                    { 15, "Irritability" },
                    { 16, "Anger and Irritability" }
                });

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "TestId",
                keyValue: 1,
                column: "Title",
                value: "Adult Level 1 Cross-Cutting Symptom Measure, Self-Rated");

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "TestId", "Title" },
                values: new object[,]
                {
                    { 2, "Child Age 11-17 Level 1 Cross-Cutting Symptom Measure, Self-Rated" },
                    { 3, "Child Age 6-17 Level 1 Cross-Cutting Symptom Measure, Parent/Guardian-Rated" }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "QuestionId", "QuestionDesc", "QuestionTypeId", "TestId" },
                values: new object[,]
                {
                    { 24, "1. Been bothered by stomachaches, headaches, or other aches and pains?", 5, 2 },
                    { 51, "3. Had problems sleeping—that is, trouble falling asleep, staying asleep, or waking up too early?", 8, 3 },
                    { 52, "4. Had problems paying attention when they were in class or doing their homework or reading a book or playing a game?", 14, 3 },
                    { 53, "5. Had less fun doing things than they used to?", 1, 3 },
                    { 54, "6. Seemed sad or depressed for several hours?", 1, 3 },
                    { 55, "7. Seemed more irritated or easily annoyed than usual?", 16, 3 },
                    { 56, "8. Seemed angry or lost their temper?", 16, 3 },
                    { 57, "9. Started lots more projects than usual or did more risky things than usual?", 3, 3 },
                    { 58, "10. Slept less than usual for them, but still had lots of energy?", 3, 3 },
                    { 59, "11. Said they felt nervous, anxious, or scared?", 4, 3 },
                    { 60, "12. Not been able to stop worrying?", 4, 3 },
                    { 61, "13. Said they couldn’t do things they wanted to or should have done, because those things made them feel nervous?", 4, 3 },
                    { 62, "14. Said that they heard voices—when there was no one there—speaking about themself or telling them what to do or saying bad things to themself?", 7, 3 },
                    { 63, "15. Said that they had a vision when they were completely awake—that is, saw something or someone that no one else could see?", 7, 3 },
                    { 64, "16. Said that they had thoughts that kept coming into their mind that they would do something bad or that something bad would happen to themself or to someone else?", 10, 3 },
                    { 65, "17. Said they felt the need to check on certain things over and over again, like whether a door was locked or whether the stove was turned off?", 10, 3 },
                    { 66, "18. Seemed to worry a lot about things they touched being dirty or having germs or being poisoned?", 10, 3 },
                    { 67, "19. Said that they had to do things in a certain way, like counting or saying special things out loud, in order to keep something bad from happening?", 10, 3 },
                    { 68, "20. Had an alcoholic beverage (beer, wine, liquor, etc.)?", 13, 3 },
                    { 69, "21. Smoked a cigarette, a cigar, or pipe, or used snuff or chewing tobacco?", 13, 3 },
                    { 70, "22. Used drugs like marijuana, cocaine or crack, club drugs (like ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)?", 13, 3 },
                    { 71, "23. Used any medicine without a doctor’s prescription (e.g., painkillers [like Vicodin], stimulants [like Ritalin or Adderall], sedatives or tranquilizers [like sleeping pills or Valium], or steroids)?", 13, 3 },
                    { 50, "2. Said they were worried about their health or about getting sick?", 5, 3 },
                    { 49, "1. Complained of stomachaches, headaches, or other aches and pains?", 5, 3 },
                    { 48, "25. Have you EVER tried to kill yourself?", 6, 2 },
                    { 47, "24. In the last 2 weeks, have you thought about killing yourself or committing suicide?", 6, 2 },
                    { 25, "2. Worried about your health or about getting sick?", 5, 2 },
                    { 26, "3. Been bothered by not being able to fall asleep or stay asleep, or by waking up too early?", 8, 2 },
                    { 27, "4. Been bothered by not being able to pay attention when you were in class or doing homework or reading a book or playing a game?", 14, 2 },
                    { 28, "5. Had less fun doing things than you used to?", 1, 2 },
                    { 29, "6. Felt sad or depressed for several hours?", 1, 2 },
                    { 30, "7. Felt more irritated or easily annoyed than usual?", 16, 2 },
                    { 31, "8. Felt angry or lost your temper?", 16, 2 },
                    { 32, "9. Started lots more projects than usual or done more risky things than usual?", 3, 2 },
                    { 33, "10. Slept less than usual but still had a lot of energy?", 3, 2 },
                    { 34, "11. Felt nervous, anxious, or scared?", 4, 2 },
                    { 72, "24. In the past TWO (2) WEEKS, have they talked about wanting to kill themself or about wanting to commit suicide?", 6, 3 },
                    { 35, "12. Not been able to stop worrying?", 4, 2 },
                    { 37, "14. Heard voices—when there was no one there—speaking about you or telling you what to do or saying bad things to you?", 7, 2 },
                    { 38, "15. Had visions when you were completely awake—that is, seen something or someone that no one else could see?", 7, 2 },
                    { 39, "16. Had thoughts that kept coming into your mind that you would do something bad or that something bad would happen to you or to someone else?", 10, 2 },
                    { 40, "17. Felt the need to check on certain things over and over again, like whether a door was locked or whether the stove was turned off?", 10, 2 },
                    { 41, "18. Worried a lot about things you touched being dirty or having germs or being poisoned?", 10, 2 },
                    { 42, "19. Felt you had to do things in a certain way, like counting or saying special things, to keep something bad from happening?", 10, 2 },
                    { 43, "20. Had an alcoholic beverage (beer, wine, liquor, etc.)?", 13, 2 },
                    { 44, "21. Smoked a cigarette, a cigar, or pipe, or used snuff or chewing tobacco?", 13, 2 },
                    { 45, "22. Used drugs like marijuana, cocaine or crack, club drugs (like Ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)?", 13, 2 },
                    { 46, "23. Used any medicine without a doctor’s prescription to get high or change the way you feel (e.g., painkillers [like Vicodin], stimulants [like Ritalin or Adderall], sedatives or tranquilizers [like sleeping pills or Valium], or steroids)?", 13, 2 },
                    { 36, "13. Not been able to do things you wanted to or should have done, because they made you feel nervous?", 4, 2 },
                    { 73, "25. Have they EVER tried to kill themself", 6, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "QuestionType",
                keyColumn: "QuestionTypeId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "TestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Test",
                keyColumn: "TestId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Test",
                keyColumn: "TestId",
                keyValue: 1,
                column: "Title",
                value: "Level 1 Cross-Cutting Symptom Measure—Adult");
        }
    }
}
