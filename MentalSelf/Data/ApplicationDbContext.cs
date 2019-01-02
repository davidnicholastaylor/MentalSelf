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
        public DbSet<Response> Response { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<UserTest> UserTest { get; set; }
        public DbSet<UserResponse> UserResponse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<UserResponse>().HasData(
            new UserResponse() 
            {
                UserResponseId = 1,
                Rating = "Not at all"
            }
            );

            modelBuilder.Entity<UserResponse>().HasData(
            new UserResponse()
            {
                UserResponseId = 2,
                Rating = "Rare, less than a couple days"
            }
            );

            modelBuilder.Entity<UserResponse>().HasData(
            new UserResponse()
            {
                UserResponseId = 3,
                Rating = "Several days"
            }
            );

            modelBuilder.Entity<UserResponse>().HasData(
            new UserResponse()
            {
                UserResponseId = 4,
                Rating = "More than half the days"
            }
            );

            modelBuilder.Entity<UserResponse>().HasData(
            new UserResponse()
            {
                UserResponseId = 5,
                Rating = "Nearly every day"
            }
            );

            modelBuilder.Entity<QuestionType>().HasData(
            new QuestionType()
            {
                QuestionTypeId = 1,
                Type = "Depression"
            },
            new QuestionType()
            {
                QuestionTypeId = 2,
                Type = "Anger"
            },
            new QuestionType()
            {
                QuestionTypeId = 3,
                Type = "Mania"
            },
            new QuestionType()
            {
                QuestionTypeId = 4,
                Type = "Anxiety"
            },
            new QuestionType()
            {
                QuestionTypeId = 5,
                Type = "Somatic Symptoms"
            },
            new QuestionType()
            {
                QuestionTypeId = 6,
                Type = "Suicidal Ideation"
            },
            new QuestionType()
            {
                QuestionTypeId = 7,
                Type = "Psychosis"
            },
            new QuestionType()
            {
                QuestionTypeId = 8,
                Type = "Sleep Problems"
            },
            new QuestionType()
            {
                QuestionTypeId = 9,
                Type = "Memory"
            },
            new QuestionType()
            {
                QuestionTypeId = 10,
                Type = "Repetative Thoughts and Behaviors"
            },
            new QuestionType()
            {
                QuestionTypeId = 11,
                Type = "Dissociation"
            },
            new QuestionType()
            {
                QuestionTypeId = 12,
                Type = "Personality Functioning"
            },
            new QuestionType()
            {
                QuestionTypeId = 13,
                Type = "Substance Use"
            },
            new QuestionType()
            {
                QuestionTypeId = 14,
                Type = "Inattention"
            },
            new QuestionType()
            { 
                QuestionTypeId = 15,
                Type = "Irritability"
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
                QuestionDesc = "12.Hearing things other people couldn’t hear, such as voices even when no one was around ?",
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
                QuestionTypeId = 15,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 30,
                QuestionDesc = "8. Felt angry or lost your temper?",
                QuestionTypeId = 2,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 31,
                QuestionDesc = "9. Started lots more projects than usual or done more risky things than usual?",
                QuestionTypeId = 3,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 32,
                QuestionDesc = "10. Slept less than usual but still had a lot of energy?",
                QuestionTypeId = 3,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 33,
                QuestionDesc = "11. Felt nervous, anxious, or scared?",
                QuestionTypeId = 4,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 34,
                QuestionDesc = "12. Not been able to stop worrying?",
                QuestionTypeId = 4,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 35,
                QuestionDesc = "13. Not been able to do things you wanted to or should have done, because they made you feel nervous?",
                QuestionTypeId = 4,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 36,
                QuestionDesc = "14. Heard voices—when there was no one there—speaking about you or telling you what to do or saying bad things to you?",
                QuestionTypeId = 7,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 37,
                QuestionDesc = "15. Had visions when you were completely awake—that is, seen something or someone that no one else could see?",
                QuestionTypeId = 7,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 38,
                QuestionDesc = "16. Had thoughts that kept coming into your mind that you would do something bad or that something bad would happen to you or to someone else?",
                QuestionTypeId = 10,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 39,
                QuestionDesc = "17. Felt the need to check on certain things over and over again, like whether a door was locked or whether the stove was turned off?",
                QuestionTypeId = 10,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 40,
                QuestionDesc = "18. Worried a lot about things you touched being dirty or having germs or being poisoned?",
                QuestionTypeId = 10,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 41,
                QuestionDesc = "19. Felt you had to do things in a certain way, like counting or saying special things, to keep something bad from happening?",
                QuestionTypeId = 10,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 42,
                QuestionDesc = "20. Had an alcoholic beverage (beer, wine, liquor, etc.)?",
                QuestionTypeId = 13,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 43,
                QuestionDesc = "21. Smoked a cigarette, a cigar, or pipe, or used snuff or chewing tobacco?",
                QuestionTypeId = 13,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 44,
                QuestionDesc = "22. Used drugs like marijuana, cocaine or crack, club drugs (like Ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)?",
                QuestionTypeId = 13,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 45,
                QuestionDesc = "23. Used any medicine without a doctor’s prescription to get high or change the way you feel (e.g., painkillers [like Vicodin], stimulants [like Ritalin or Adderall], sedatives or tranquilizers [like sleeping pills or Valium], or steroids)?",
                QuestionTypeId = 13,
                TestId = 2
            },
            new Question()
            {
                QuestionId = 46,
                QuestionDesc = "24. In the last 2 weeks, have you thought about killing yourself or committing suicide?",
                QuestionTypeId = 6,
                TestId = 2
            },
            new Question() 
            {
                QuestionId = 47,
                QuestionDesc = "25. Have you EVER tried to kill yourself?",
                QuestionTypeId = 6,
                TestId = 2
            }
            );
        }
    }
}
