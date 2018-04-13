using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BVAppDAL.Models
{
    public partial class bvappContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MessageRecipient> MessageRecipient { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<ParentStudent> ParentStudent { get; set; }
        public virtual DbSet<Party> Party { get; set; }
        public virtual DbSet<PartyType> PartyType { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<PhoneCareer> PhoneCareer { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentClass> StudentClass { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TeacherClass> TeacherClass { get; set; }

        public bvappContext(DbContextOptions<bvappContext> options)
: base(options)
        { }

        public bvappContext()
: base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=bvappsvr.database.windows.net;Database=bvapp;Persist Security Info=True;User ID=bvappadmin;Password=passbv!123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.PartyId)
                    .HasName("AccountIX2")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("AccountIX1")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("binary(64)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Party)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNT_REFERENCE_PARTY");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.PartyId);

                entity.Property(e => e.PartyId)
                    .HasColumnName("PartyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Party)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADMIN_REFERENCE_PARTY");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasIndex(e => e.ClassName)
                    .HasName("ClassIX1")
                    .IsUnique();

                entity.HasIndex(e => e.GradeId)
                    .HasName("ClassIX2");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLASS_REFERENCE_GRADE");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasIndex(e => e.GradeName)
                    .HasName("GradeIX1")
                    .IsUnique();

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GradeName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasIndex(e => e.MessageGroupId)
                    .HasName("MessageIX2");

                entity.HasIndex(e => e.SenderPartyId)
                    .HasName("MessageIX1");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MessageGroupId).HasColumnName("MessageGroupID");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasMaxLength(7999)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SenderPartyId).HasColumnName("SenderPartyID");

                entity.Property(e => e.SentToClass)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");

                entity.HasOne(d => d.SenderParty)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.SenderPartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MESSAGE_REFERENCE_PARTY");
            });

            modelBuilder.Entity<MessageRecipient>(entity =>
            {
                entity.HasIndex(e => e.MessageId)
                    .HasName("MessageRecipientIX4");

                entity.HasIndex(e => e.ParentPartyId)
                    .HasName("MessageRecipientIX1");

                entity.HasIndex(e => e.StudentPartyId)
                    .HasName("MessageRecipientIX2");

                entity.HasIndex(e => e.TeacherPartyId)
                    .HasName("MessageRecipientIX3");

                entity.Property(e => e.MessageRecipientId).HasColumnName("MessageRecipientID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ParentPartyId).HasColumnName("ParentPartyID");

                entity.Property(e => e.ReadDate).HasColumnType("datetime");

                entity.Property(e => e.StudentPartyId).HasColumnName("StudentPartyID");

                entity.Property(e => e.TeacherPartyId).HasColumnName("TeacherPartyID");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.MessageRecipient)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MESSAGER_REFERENCE_MESSAGE");

                entity.HasOne(d => d.ParentParty)
                    .WithMany(p => p.MessageRecipientParentParty)
                    .HasForeignKey(d => d.ParentPartyId)
                    .HasConstraintName("FK_MESSAGER_REFERENCE_PARTY1");

                entity.HasOne(d => d.StudentParty)
                    .WithMany(p => p.MessageRecipientStudentParty)
                    .HasForeignKey(d => d.StudentPartyId)
                    .HasConstraintName("FK_MESSAGER_REFERENCE_PARTY2");

                entity.HasOne(d => d.TeacherParty)
                    .WithMany(p => p.MessageRecipientTeacherParty)
                    .HasForeignKey(d => d.TeacherPartyId)
                    .HasConstraintName("FK_MESSAGER_REFERENCE_PARTY3");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => e.PartyId);

                entity.Property(e => e.PartyId)
                    .HasColumnName("PartyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ParentStudent>(entity =>
            {
                entity.HasIndex(e => e.ParentPartyId)
                    .HasName("ParentStudentIX2");

                entity.HasIndex(e => new { e.StudentPartyId, e.ParentPartyId })
                    .HasName("ParentStudentIX1")
                    .IsUnique();

                entity.Property(e => e.ParentStudentId).HasColumnName("ParentStudentID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ParentPartyId).HasColumnName("ParentPartyID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StudentPartyId).HasColumnName("StudentPartyID");

                entity.HasOne(d => d.ParentParty)
                    .WithMany(p => p.ParentStudent)
                    .HasForeignKey(d => d.ParentPartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARENTST_REFERENCE_PARENT");

                entity.HasOne(d => d.StudentParty)
                    .WithMany(p => p.ParentStudent)
                    .HasForeignKey(d => d.StudentPartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARENTST_REFERENCE_STUDENT");
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress)
                    .HasName("PartyIX2");

                entity.HasIndex(e => e.PartyTypeId)
                    .HasName("PartyIX3");

                entity.HasIndex(e => new { e.LastName, e.FirstName })
                    .HasName("PartyIX1");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PartyTypeId).HasColumnName("PartyTypeID");

                entity.Property(e => e.Title)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.PartyType)
                    .WithMany(p => p.Party)
                    .HasForeignKey(d => d.PartyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARTY_REFERENCE_PARTYTYP");
            });

            modelBuilder.Entity<PartyType>(entity =>
            {
                entity.HasIndex(e => e.PartyType1)
                    .HasName("PartyTypeIX1")
                    .IsUnique();

                entity.Property(e => e.PartyTypeId).HasColumnName("PartyTypeID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PartyType1)
                    .IsRequired()
                    .HasColumnName("PartyType")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasIndex(e => e.PartyId)
                    .HasName("PhoneIX3");

                entity.HasIndex(e => e.PhoneCareerId)
                    .HasName("PhoneIX2");

                entity.HasIndex(e => e.PhoneNumber)
                    .HasName("PhoneIX1")
                    .IsUnique();

                entity.Property(e => e.PhoneId).HasColumnName("PhoneID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PhoneCareerId).HasColumnName("PhoneCareerID");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHONE_REFERENCE_PARTY");

                entity.HasOne(d => d.PhoneCareer)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.PhoneCareerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHONE_REFERENCE_PHONECAR");
            });

            modelBuilder.Entity<PhoneCareer>(entity =>
            {
                entity.HasIndex(e => e.PhoneCareerName)
                    .HasName("PhoneCareerIX1")
                    .IsUnique();

                entity.Property(e => e.PhoneCareerId).HasColumnName("PhoneCareerID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PhoneCareerName)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Smsgateway)
                    .IsRequired()
                    .HasColumnName("SMSGateway")
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.PartyId);

                entity.HasIndex(e => e.StudentIdentifier)
                    .HasName("StudentIX1")
                    .IsUnique();

                entity.Property(e => e.PartyId)
                    .HasColumnName("PartyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StudentIdentifier)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Party)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_REFERENCE_PARTY");
            });

            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.HasIndex(e => e.ClassId)
                    .HasName("StudentClassIX2");

                entity.HasIndex(e => new { e.PartyId, e.ClassId })
                    .HasName("StudentClassIX1")
                    .IsUnique();

                entity.Property(e => e.StudentClassId).HasColumnName("StudentClassID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentClass)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTC_REFERENCE_CLASS");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.StudentClass)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTC_REFERENCE_STUDENT");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.PartyId);

                entity.HasIndex(e => e.TeacherIdentifier)
                    .HasName("TeacherIX1")
                    .IsUnique();

                entity.Property(e => e.PartyId)
                    .HasColumnName("PartyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AvailHoursEnd)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AvailHoursStart)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TeacherIdentifier)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Party)
                    .WithOne(p => p.Teacher)
                    .HasForeignKey<Teacher>(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEACHER_REFERENCE_PARTY");
            });

            modelBuilder.Entity<TeacherClass>(entity =>
            {
                entity.HasIndex(e => e.TeacherPartyId)
                    .HasName("TeacherClassIX2");

                entity.HasIndex(e => new { e.ClassId, e.TeacherPartyId })
                    .HasName("TeacherClassIX1")
                    .IsUnique();

                entity.Property(e => e.TeacherClassId).HasColumnName("TeacherClassID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TeacherPartyId).HasColumnName("TeacherPartyID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TeacherClass)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEACHERC_REFERENCE_CLASS");

                entity.HasOne(d => d.TeacherParty)
                    .WithMany(p => p.TeacherClass)
                    .HasForeignKey(d => d.TeacherPartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEACHERC_REFERENCE_TEACHER");
            });
        }
    }
}
