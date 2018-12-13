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
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Test>().HasData(
            new Test() 
            {
            TestID = 1,
            Title = "Level 1 Cross-Cutting Symptom Measure—Adult"
            }
            );

            modelBuilder.Entity<QuestionType>().HasData(
            new QuestionType()
            {
            QuestionTypeID = 1,
            Type = "Depression"
            },
            new QuestionType()
            {
                QuestionTypeID = 2,
                Type = "Anger"
            },
            new QuestionType()
            {
                QuestionTypeID = 3,
                Type = "Mania"
            },
            new QuestionType()
            {
                QuestionTypeID = 4,
                Type = "Anxiety"
            },
            new QuestionType()
            {
                QuestionTypeID = 5,
                Type = "Somatic Symptoms"
            },
            new QuestionType()
            {
                QuestionTypeID = 6,
                Type = "Suicidal Ideation"
            },
            new QuestionType()
            {
                QuestionTypeID = 7,
                Type = "Psychosis"
            },
            new QuestionType()
            {
                QuestionTypeID = 8,
                Type = "Sleep Problems"
            },
            new QuestionType()
            {
                QuestionTypeID = 9,
                Type = "Memory"
            },
            new QuestionType()
            {
                QuestionTypeID = 10,
                Type = "Repetative Thoughts and Behaviors"
            },
            new QuestionType()
            {
                QuestionTypeID = 11,
                Type = "Dissociation"
            },
            new QuestionType()
            {
                QuestionTypeID = 12,
                Type = "Personality Functioning"
            },
            new QuestionType()
            {
                QuestionTypeID = 13,
                Type = "Substance Use"
            }
            );

            modelBuilder.Entity<Question>().HasData(
            new Question()
            {
                QuestionID = 1,
                QuestionDesc = "1. Little interest or pleasure in doing things?",
                QuestionTypeId = 1,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 2,
                QuestionDesc = "2. Feeling down, depressed, or hopeless?",
                QuestionTypeId = 1,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 3,
                QuestionDesc = "3. Feeling more irritated, grouchy, or angry than usual?",
                QuestionTypeId = 2,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 4,
                QuestionDesc = "4. Sleeping less than usual, but still have a lot of energy?",
                QuestionTypeId = 3,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 5,
                QuestionDesc = "5. Starting lots more projects than usual or doing more risky things than usual?",
                QuestionTypeId = 3,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 6,
                QuestionDesc = "6. Feeling nervous, anxious, frightened, worried, or on edge?",
                QuestionTypeId = 4,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 7,
                QuestionDesc = "7. Feeling panic or being frightened?",
                QuestionTypeId = 4,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 8,
                QuestionDesc = "8. Avoiding situations that make you anxious?",
                QuestionTypeId = 4,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 9,
                QuestionDesc = "9. Unexplained aches and pains (e.g., head, back, joints, abdomen, legs)?",
                QuestionTypeId = 5,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 10,
                QuestionDesc = "10. Feeling that your illnesses are not being taken seriously enough??",
                QuestionTypeId = 5,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 11,
                QuestionDesc = "11. Thoughts of actually hurting yourself?",
                QuestionTypeId = 6,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 12,
                QuestionDesc = "12.Hearing things other people couldn’t hear, such as voices even when no one was around ?",
                QuestionTypeId = 7,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 13,
                QuestionDesc = "13. Feeling that someone could hear your thoughts, or that you could hear what another person was thinking?",
                QuestionTypeId = 7,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 14,
                QuestionDesc = "14. Problems with sleep that affected your sleep quality over all?",
                QuestionTypeId = 8,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 15,
                QuestionDesc = "15. Problems with memory (e.g., learning new information) or with location (e.g., finding your way home)? ",
                QuestionTypeId = 9,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 16,
                QuestionDesc = "16. Unpleasant thoughts, urges, or images that repeatedly enter your mind?",
                QuestionTypeId = 10,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 17,
                QuestionDesc = "17. Feeling driven to perform certain behaviors or mental acts over and over again?",
                QuestionTypeId = 10,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 18,
                QuestionDesc = "18. Feeling detached or distant from yourself, your body, your physical surroundings, or your memories?",
                QuestionTypeId = 11,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 19,
                QuestionDesc = "19. Not knowing who you really are or what you want out of life?",
                QuestionTypeId = 12,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 20,
                QuestionDesc = "20. Not feeling close to other people or enjoying your relationships with them?",
                QuestionTypeId = 12,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 21,
                QuestionDesc = "21. Drinking at least 4 drinks of any kind of alcohol in a single day?",
                QuestionTypeId = 13,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 22,
                QuestionDesc = "22. Smoking any cigarettes, a cigar, or pipe, or using snuff or chewing tobacco?",
                QuestionTypeId = 13,
                TestId = 1
            },
            new Question()
            {
                QuestionID = 23,
                QuestionDesc = "23. Using any of the following medicines ON YOUR OWN, that is, without a doctor’s prescription, in greater amounts or longer than prescribed [e.g., painkillers (like Vicodin), stimulants (like Ritalin or Adderall), sedatives or tranquilizers (like sleeping pills or Valium), or drugs like marijuana, cocaine or crack, club drugs (like ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)]?",
                QuestionTypeId = 13,
                TestId = 1
            }
            );
        }
    }
}
