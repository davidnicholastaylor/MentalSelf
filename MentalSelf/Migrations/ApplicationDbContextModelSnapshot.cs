﻿// <auto-generated />
using System;
using MentalSelf.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MentalSelf.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MentalSelf.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionDesc")
                        .IsRequired();

                    b.Property<int>("QuestionTypeId");

                    b.Property<int>("TestId");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuestionTypeId");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");

                    b.HasData(
                        new { QuestionId = 1, QuestionDesc = "1. Little interest or pleasure in doing things?", QuestionTypeId = 1, TestId = 1 },
                        new { QuestionId = 2, QuestionDesc = "2. Feeling down, depressed, or hopeless?", QuestionTypeId = 1, TestId = 1 },
                        new { QuestionId = 3, QuestionDesc = "3. Feeling more irritated, grouchy, or angry than usual?", QuestionTypeId = 2, TestId = 1 },
                        new { QuestionId = 4, QuestionDesc = "4. Sleeping less than usual, but still have a lot of energy?", QuestionTypeId = 3, TestId = 1 },
                        new { QuestionId = 5, QuestionDesc = "5. Starting lots more projects than usual or doing more risky things than usual?", QuestionTypeId = 3, TestId = 1 },
                        new { QuestionId = 6, QuestionDesc = "6. Feeling nervous, anxious, frightened, worried, or on edge?", QuestionTypeId = 4, TestId = 1 },
                        new { QuestionId = 7, QuestionDesc = "7. Feeling panic or being frightened?", QuestionTypeId = 4, TestId = 1 },
                        new { QuestionId = 8, QuestionDesc = "8. Avoiding situations that make you anxious?", QuestionTypeId = 4, TestId = 1 },
                        new { QuestionId = 9, QuestionDesc = "9. Unexplained aches and pains (e.g., head, back, joints, abdomen, legs)?", QuestionTypeId = 5, TestId = 1 },
                        new { QuestionId = 10, QuestionDesc = "10. Feeling that your illnesses are not being taken seriously enough??", QuestionTypeId = 5, TestId = 1 },
                        new { QuestionId = 11, QuestionDesc = "11. Thoughts of actually hurting yourself?", QuestionTypeId = 6, TestId = 1 },
                        new { QuestionId = 12, QuestionDesc = "12.Hearing things other people couldn’t hear, such as voices even when no one was around ?", QuestionTypeId = 7, TestId = 1 },
                        new { QuestionId = 13, QuestionDesc = "13. Feeling that someone could hear your thoughts, or that you could hear what another person was thinking?", QuestionTypeId = 7, TestId = 1 },
                        new { QuestionId = 14, QuestionDesc = "14. Problems with sleep that affected your sleep quality over all?", QuestionTypeId = 8, TestId = 1 },
                        new { QuestionId = 15, QuestionDesc = "15. Problems with memory (e.g., learning new information) or with location (e.g., finding your way home)? ", QuestionTypeId = 9, TestId = 1 },
                        new { QuestionId = 16, QuestionDesc = "16. Unpleasant thoughts, urges, or images that repeatedly enter your mind?", QuestionTypeId = 10, TestId = 1 },
                        new { QuestionId = 17, QuestionDesc = "17. Feeling driven to perform certain behaviors or mental acts over and over again?", QuestionTypeId = 10, TestId = 1 },
                        new { QuestionId = 18, QuestionDesc = "18. Feeling detached or distant from yourself, your body, your physical surroundings, or your memories?", QuestionTypeId = 11, TestId = 1 },
                        new { QuestionId = 19, QuestionDesc = "19. Not knowing who you really are or what you want out of life?", QuestionTypeId = 12, TestId = 1 },
                        new { QuestionId = 20, QuestionDesc = "20. Not feeling close to other people or enjoying your relationships with them?", QuestionTypeId = 12, TestId = 1 },
                        new { QuestionId = 21, QuestionDesc = "21. Drinking at least 4 drinks of any kind of alcohol in a single day?", QuestionTypeId = 13, TestId = 1 },
                        new { QuestionId = 22, QuestionDesc = "22. Smoking any cigarettes, a cigar, or pipe, or using snuff or chewing tobacco?", QuestionTypeId = 13, TestId = 1 },
                        new { QuestionId = 23, QuestionDesc = "23. Using any of the following medicines ON YOUR OWN, that is, without a doctor’s prescription, in greater amounts or longer than prescribed [e.g., painkillers (like Vicodin), stimulants (like Ritalin or Adderall), sedatives or tranquilizers (like sleeping pills or Valium), or drugs like marijuana, cocaine or crack, club drugs (like ecstasy), hallucinogens (like LSD), heroin, inhalants or solvents (like glue), or methamphetamine (like speed)]?", QuestionTypeId = 13, TestId = 1 }
                    );
                });

            modelBuilder.Entity("MentalSelf.Models.QuestionType", b =>
                {
                    b.Property<int>("QuestionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("QuestionTypeId");

                    b.ToTable("QuestionTypes");

                    b.HasData(
                        new { QuestionTypeId = 1, Type = "Depression" },
                        new { QuestionTypeId = 2, Type = "Anger" },
                        new { QuestionTypeId = 3, Type = "Mania" },
                        new { QuestionTypeId = 4, Type = "Anxiety" },
                        new { QuestionTypeId = 5, Type = "Somatic Symptoms" },
                        new { QuestionTypeId = 6, Type = "Suicidal Ideation" },
                        new { QuestionTypeId = 7, Type = "Psychosis" },
                        new { QuestionTypeId = 8, Type = "Sleep Problems" },
                        new { QuestionTypeId = 9, Type = "Memory" },
                        new { QuestionTypeId = 10, Type = "Repetative Thoughts and Behaviors" },
                        new { QuestionTypeId = 11, Type = "Dissociation" },
                        new { QuestionTypeId = 12, Type = "Personality Functioning" },
                        new { QuestionTypeId = 13, Type = "Substance Use" }
                    );
                });

            modelBuilder.Entity("MentalSelf.Models.Response", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<int>("UserResponseId");

                    b.Property<int>("UserTestId");

                    b.HasKey("ResponseId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserResponseId");

                    b.HasIndex("UserTestId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("MentalSelf.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("TestId");

                    b.ToTable("Tests");

                    b.HasData(
                        new { TestId = 1, Title = "Level 1 Cross-Cutting Symptom Measure—Adult" }
                    );
                });

            modelBuilder.Entity("MentalSelf.Models.UserResponse", b =>
                {
                    b.Property<int>("UserResponseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rating");

                    b.HasKey("UserResponseId");

                    b.ToTable("UserResponse");

                    b.HasData(
                        new { UserResponseId = 1, Rating = "Not at all" },
                        new { UserResponseId = 2, Rating = "Rare, less than a couple days" },
                        new { UserResponseId = 3, Rating = "Several days" },
                        new { UserResponseId = 4, Rating = "More than half the days" },
                        new { UserResponseId = 5, Rating = "Nearly every day" }
                    );
                });

            modelBuilder.Entity("MentalSelf.Models.UserTest", b =>
                {
                    b.Property<int>("UserTestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTaken")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("TestId");

                    b.HasKey("UserTestId");

                    b.HasIndex("TestId");

                    b.ToTable("UserTests");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MentalSelf.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("MentalSelf.Models.Question", b =>
                {
                    b.HasOne("MentalSelf.Models.QuestionType", "QuestionType")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MentalSelf.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MentalSelf.Models.Response", b =>
                {
                    b.HasOne("MentalSelf.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MentalSelf.Models.ApplicationUser", "User")
                        .WithMany("Responses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MentalSelf.Models.UserResponse", "UserResponse")
                        .WithMany()
                        .HasForeignKey("UserResponseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MentalSelf.Models.UserTest", "UserTest")
                        .WithMany()
                        .HasForeignKey("UserTestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MentalSelf.Models.UserTest", b =>
                {
                    b.HasOne("MentalSelf.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}