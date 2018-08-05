using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIUniTranslate.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Interpreter> Interpreter { get; set; }
        public virtual DbSet<Keyword> Keyword { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public virtual DbSet<QuestionAnswerHasKeyword> QuestionAnswerHasKeyword { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:unitranslate.database.windows.net,1433;Initial Catalog=Interpreters;Persist Security Info=False;User ID=thelittlewozniak;Password=azerty1234@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interpreter>(entity =>
            {
                entity.ToTable("interpreter");

                entity.Property(e => e.Clan)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ethnic)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Kind)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.Property(e => e.Text)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.Property(e => e.Answer)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestionAnswerHasKeyword>(entity =>
            {
                entity.HasKey(e => new { e.QuestionAnswerId, e.KeywordId });

                entity.ToTable("QuestionAnswer_has_Keyword");

                entity.HasIndex(e => e.KeywordId)
                    .HasName("fk_QuestionAnswer_has_Keyword_Keyword1_idx");

                entity.HasIndex(e => e.QuestionAnswerId)
                    .HasName("fk_QuestionAnswer_has_Keyword_QuestionAnswer_idx");

                entity.Property(e => e.QuestionAnswerId).HasColumnName("QuestionAnswer_Id");

                entity.Property(e => e.KeywordId).HasColumnName("Keyword_Id");

                entity.HasOne(d => d.QuestionAnswer)
                    .WithMany(p => p.QuestionAnswerHasKeyword)
                    .HasForeignKey(d => d.QuestionAnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionAnswer_has_Keyword_QuestionAnswer");
            });
        }
    }
}
