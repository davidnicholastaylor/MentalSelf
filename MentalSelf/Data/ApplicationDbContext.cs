using System;
using System.Collections.Generic;
using System.Text;
using MentalSelf.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MentalSelf.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionType> QuestionType { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<UserTest> UserTest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.UserTests)
                .WithOne(ut => ut.User)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserTest>()
               .Property(u => u.DateTaken)
               .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Test>().HasData(
            new Test() 
            {
                TestId = 1,
                Title = "Adult Level 1 Cross-Cutting Symptom Measure, Self-Rated"
            },
            new Test() 
            {
                TestId = 2,
                Title = "Child Age 11-17 Level 1 Cross-Cutting Symptom Measure, Self-Rated"
            },
            new Test()
            {
                TestId = 3,
                Title = "Child Age 6-17 Level 1 Cross-Cutting Symptom Measure, Parent/Guardian-Rated"
            }
            );

            modelBuilder.Entity<Rating>().HasData(
            new Rating() 
            {
                RatingId = 1,
                RatingAmount = 0,
                RatingDescription = "Not at all"
            },
            new Rating()
            {
                RatingId = 2,
                RatingAmount = 1,
                RatingDescription = "Rare, less than a couple days"
            },
            new Rating()
            {
                RatingId = 3,
                RatingAmount = 2,
                RatingDescription = "Several days"
            },
            new Rating()
            {
                RatingId = 4,
                RatingAmount = 3,
                RatingDescription = "More than half the days"
            },
            new Rating()
            {
                RatingId = 5,
                RatingAmount = 4,
                RatingDescription = "Nearly every day"
            }
            );

            modelBuilder.Entity<QuestionType>().HasData(
            new QuestionType()
            {
                QuestionTypeId = 1,
                Type = "Depression",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 2,
                Type = "Anger",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 3,
                Type = "Mania",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 4,
                Type = "Anxiety",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 5,
                Type = "Somatic Symptoms",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 6,
                Type = "Suicidal Ideation",
                Threshold = 1,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 7,
                Type = "Psychosis",
                Threshold = 1,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 8,
                Type = "Sleep Problems",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 9,
                Type = "Memory",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 10,
                Type = "Repetative Thoughts and Behaviors",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 11,
                Type = "Dissociation",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 12,
                Type = "Personality Functioning",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 13,
                Type = "Substance Use",
                Threshold = 1,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 14,
                Type = "Inattention",
                Threshold = 1,
                QTLink = ""
            },
            new QuestionType()
            { 
                QuestionTypeId = 15,
                Type = "Irritability",
                Threshold = 2,
                QTLink = ""
            },
            new QuestionType()
            {
                QuestionTypeId = 16,
                Type = "Anger and Irritability",
                Threshold = 2,
                QTLink = ""
            }
            );

            modelBuilder.Entity<Question>().HasData(
            new Question()
            {
                QuestionId = 1,
                QuestionDesc = "1. Little interest or pleasure in doing things?",
                QuestionTypeId = 1,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 2,
                QuestionDesc = "2. Feeling down, depressed, or hopeless?",
                QuestionTypeId = 1,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 3,
                QuestionDesc = "3. Feeling more irritated, grouchy, or angry than usual?",
                QuestionTypeId = 2,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 4,
                QuestionDesc = "4. Sleeping less than usual, but still have a lot of energy?",
                QuestionTypeId = 3,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 5,
                QuestionDesc = "5. Starting lots more projects than usual or doing more risky things than usual?",
                QuestionTypeId = 3,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 6,
                QuestionDesc = "6. Feeling nervous, anxious, frightened, worried, or on edge?",
                QuestionTypeId = 4,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 7,
                QuestionDesc = "7. Feeling panic or being frightened?",
                QuestionTypeId = 4,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 8,
                QuestionDesc = "8. Avoiding situations that make you anxious?",
                QuestionTypeId = 4,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 9,
                QuestionDesc = "9. Unexplained aches and pains (e.g., head, back, joints, abdomen, legs)?",
                QuestionTypeId = 5,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 10,
                QuestionDesc = "10. Feeling that your illnesses are not being taken seriously enough?",
                QuestionTypeId = 5,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 11,
                QuestionDesc = "11. Thoughts of actually hurting yourself?",
                QuestionTypeId = 6,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 12,
                QuestionDesc = "12.Hearing things other people couldn’t hear, such as voices even when no one was around?",
                QuestionTypeId = 7,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 13,
                QuestionDesc = "13. Feeling that someone could hear your thoughts, or that you could hear what another person was thinking?",
                QuestionTypeId = 7,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 14,
                QuestionDesc = "14. Problems with sleep that affected your sleep quality over all?",
                QuestionTypeId = 8,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 15,
                QuestionDesc = "15. Problems with memory (e.g., learning new information) or with location (e.g., finding your way home)? ",
                QuestionTypeId = 9,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 16,
                QuestionDesc = "16. Unpleasant thoughts, urges, or images that repeatedly enter your mind?",
                QuestionTypeId = 10,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 17,
                QuestionDesc = "17. Feeling driven to perform certain behaviors or mental acts over and over again?",
                QuestionTypeId = 10,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 18,
                QuestionDesc = "18. Feeling detached or distant from yourself, your body, your physical surroundings, or your memories?",
                QuestionTypeId = 11,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 19,
                QuestionDesc = "19. Not knowing who you really are or what you want out of life?",
                QuestionTypeId = 12,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 20,
                QuestionDesc = "20. Not feeling close to other people or enjoying your relationships with them?",
                QuestionTypeId = 12,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 21,
                QuestionDesc = "21. Drinking at least 4 drinks of any kind of alcohol in a single day?",
                QuestionTypeId = 13,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 22,
                QuestionDesc = "22. Smoking any cigarettes, a cigar, or pipe, or using snuff or chewing tobacco?",
                QuestionTypeId = 13,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 23,
                QuestionDesc = "23. Using any of the following medicines ON YOUR OWN, that is, without a doctor’s prescription, in greater amounts or longer than prescribed [e.g., painkillers (like Vicodin), stimulants (like Ritalin or Adderall), sedatives or tranquilizers (like sleeping pills or Valium), or drugs like marijuana, cocaine or crack, club drugs (like ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)]?",
                QuestionTypeId = 13,
                TestId = 1
            },
            new Question()
            {
                QuestionId = 24,
                QuestionDesc = "1. Been bothered by stomachaches, headaches, or other aches and pains?",
                QuestionTypeId = 5,
                TestId = 2
            },
            new Question()
            { 
                QuestionId = 25,
                QuestionDesc = "2. Worried about your health or about getting sick?",
                QuestionTypeId = 5,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 26,
                QuestionDesc = "3. Been bothered by not being able to fall asleep or stay asleep, or by waking up too early?",
                QuestionTypeId = 8,
                TestId = 2
            },
            new Question()
            { 
                QuestionId = 27,
                QuestionDesc = "4. Been bothered by not being able to pay attention when you were in class or doing homework or reading a book or playing a game?",
                QuestionTypeId =  14,
                TestId = 2
            },
            new Question() 
            { 
                QuestionId = 28,
                QuestionDesc = "5. Had less fun doing things than you used to?",
                QuestionTypeId = 1,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 29,
                QuestionDesc = "6. Felt sad or depressed for several hours?",
                QuestionTypeId = 1,
                TestId = 2
            },
            new Question()
            { 
                QuestionId = 30,
                QuestionDesc = "7. Felt more irritated or easily annoyed than usual?",
                QuestionTypeId = 16,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 31,
                QuestionDesc = "8. Felt angry or lost your temper?",
                QuestionTypeId = 16,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 32,
                QuestionDesc = "9. Started lots more projects than usual or done more risky things than usual?",
                QuestionTypeId = 3,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 33,
                QuestionDesc = "10. Slept less than usual but still had a lot of energy?",
                QuestionTypeId = 3,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 34,
                QuestionDesc = "11. Felt nervous, anxious, or scared?",
                QuestionTypeId = 4,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 35,
                QuestionDesc = "12. Not been able to stop worrying?",
                QuestionTypeId = 4,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 36,
                QuestionDesc = "13. Not been able to do things you wanted to or should have done, because they made you feel nervous?",
                QuestionTypeId = 4,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 37,
                QuestionDesc = "14. Heard voices—when there was no one there—speaking about you or telling you what to do or saying bad things to you?",
                QuestionTypeId = 7,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 38,
                QuestionDesc = "15. Had visions when you were completely awake—that is, seen something or someone that no one else could see?",
                QuestionTypeId = 7,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 39,
                QuestionDesc = "16. Had thoughts that kept coming into your mind that you would do something bad or that something bad would happen to you or to someone else?",
                QuestionTypeId = 10,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 40,
                QuestionDesc = "17. Felt the need to check on certain things over and over again, like whether a door was locked or whether the stove was turned off?",
                QuestionTypeId = 10,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 41,
                QuestionDesc = "18. Worried a lot about things you touched being dirty or having germs or being poisoned?",
                QuestionTypeId = 10,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 42,
                QuestionDesc = "19. Felt you had to do things in a certain way, like counting or saying special things, to keep something bad from happening?",
                QuestionTypeId = 10,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 43,
                QuestionDesc = "20. Had an alcoholic beverage (beer, wine, liquor, etc.)?",
                QuestionTypeId = 13,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 44,
                QuestionDesc = "21. Smoked a cigarette, a cigar, or pipe, or used snuff or chewing tobacco?",
                QuestionTypeId = 13,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 45,
                QuestionDesc = "22. Used drugs like marijuana, cocaine or crack, club drugs (like Ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)?",
                QuestionTypeId = 13,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 46,
                QuestionDesc = "23. Used any medicine without a doctor’s prescription to get high or change the way you feel (e.g., painkillers [like Vicodin], stimulants [like Ritalin or Adderall], sedatives or tranquilizers [like sleeping pills or Valium], or steroids)?",
                QuestionTypeId = 13,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 47,
                QuestionDesc = "24. In the last 2 weeks, have you thought about killing yourself or committing suicide?",
                QuestionTypeId = 6,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 48,
                QuestionDesc = "25. Have you EVER tried to kill yourself?",
                QuestionTypeId = 6,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 49,
                QuestionDesc = "1. Complained of stomachaches, headaches, or other aches and pains?",
                QuestionTypeId = 5,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 50,
                QuestionDesc = "2. Said they were worried about their health or about getting sick?",
                QuestionTypeId = 5,
                TestId = 3
            },
            new Question() 
            {
                QuestionId = 51,
                QuestionDesc = "3. Had problems sleeping—that is, trouble falling asleep, staying asleep, or waking up too early?",
                QuestionTypeId = 8,
                TestId = 3
            },
            new Question() 
            {
                QuestionId = 52,
                QuestionDesc = "4. Had problems paying attention when they were in class or doing their homework or reading a book or playing a game?",
                QuestionTypeId = 14,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 53,
                QuestionDesc = "5. Had less fun doing things than they used to?",
                QuestionTypeId = 1,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 54,
                QuestionDesc = "6. Seemed sad or depressed for several hours?",
                QuestionTypeId = 1,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 55,
                QuestionDesc = "7. Seemed more irritated or easily annoyed than usual?",
                QuestionTypeId = 16,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 56,
                QuestionDesc = "8. Seemed angry or lost their temper?",
                QuestionTypeId = 16,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 57,
                QuestionDesc = "9. Started lots more projects than usual or did more risky things than usual?",
                QuestionTypeId = 3,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 58,
                QuestionDesc = "10. Slept less than usual for them, but still had lots of energy?",
                QuestionTypeId = 3,
                TestId = 3
            },
            new Question() 
            {
                QuestionId = 59,
                QuestionDesc = "11. Said they felt nervous, anxious, or scared?",
                QuestionTypeId = 4,
                TestId = 3
            },
            new Question() 
            {
                QuestionId = 60,
                QuestionDesc = "12. Not been able to stop worrying?",
                QuestionTypeId = 4,
                TestId = 3
            },
            new Question() 
            {
                QuestionId = 61,
                QuestionDesc = "13. Said they couldn’t do things they wanted to or should have done, because those things made them feel nervous?",
                QuestionTypeId = 4,
                TestId = 3
            },
            new Question() 
            {
                QuestionId = 62,
                QuestionDesc = "14. Said that they heard voices—when there was no one there—speaking about themself or telling them what to do or saying bad things to themself?",
                QuestionTypeId = 7,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 63,
                QuestionDesc = "15. Said that they had a vision when they were completely awake—that is, saw something or someone that no one else could see?",
                QuestionTypeId = 7,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 64,
                QuestionDesc = "16. Said that they had thoughts that kept coming into their mind that they would do something bad or that something bad would happen to themself or to someone else?",
                QuestionTypeId = 10,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 65,
                QuestionDesc = "17. Said they felt the need to check on certain things over and over again, like whether a door was locked or whether the stove was turned off?",
                QuestionTypeId = 10,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 66,
                QuestionDesc = "18. Seemed to worry a lot about things they touched being dirty or having germs or being poisoned?",
                QuestionTypeId = 10,
                TestId = 3
            },
            new Question() 
            {
                QuestionId = 67,
                QuestionDesc = "19. Said that they had to do things in a certain way, like counting or saying special things out loud, in order to keep something bad from happening?",
                QuestionTypeId = 10,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 68,
                QuestionDesc = "20. Had an alcoholic beverage (beer, wine, liquor, etc.)?",
                QuestionTypeId = 13,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 69,
                QuestionDesc = "21. Smoked a cigarette, a cigar, or pipe, or used snuff or chewing tobacco?",
                QuestionTypeId = 13,
                TestId = 3
            },
            new Question() 
            {
                QuestionId = 70,
                QuestionDesc = "22. Used drugs like marijuana, cocaine or crack, club drugs (like ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)?",
                QuestionTypeId = 13,
                TestId = 3
            },
            new Question()
            {
                QuestionId = 71,
                QuestionDesc = "23. Used any medicine without a doctor’s prescription (e.g., painkillers [like Vicodin], stimulants [like Ritalin or Adderall], sedatives or tranquilizers [like sleeping pills or Valium], or steroids)?",
                QuestionTypeId = 13,
                TestId = 3
            },
            new Question() 
            {
                QuestionId = 72,
                QuestionDesc = "24. In the past TWO (2) WEEKS, have they talked about wanting to kill themself or about wanting to commit suicide?",
                QuestionTypeId = 6,
                TestId = 3
            },
            new Question() 
            {
                QuestionId = 73,
                QuestionDesc = "25. Have they EVER tried to kill themself",
                QuestionTypeId = 6,
                TestId = 3
            }
            );
        }
    }
}
