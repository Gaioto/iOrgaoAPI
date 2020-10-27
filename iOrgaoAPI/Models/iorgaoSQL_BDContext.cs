using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace iOrgaoAPI.Models
{
    public partial class iorgaoSQL_BDContext : DbContext
    {
        public iorgaoSQL_BDContext()
        {
        }

        public iorgaoSQL_BDContext(DbContextOptions<iorgaoSQL_BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAdress> TbAdresses { get; set; }
        public virtual DbSet<TbDoctor> TbDoctors { get; set; }
        public virtual DbSet<TbDonation> TbDonations { get; set; }
        public virtual DbSet<TbDonator> TbDonators { get; set; }
        public virtual DbSet<TbOrgan> TbOrgans { get; set; }
        public virtual DbSet<TbOrganList> TbOrganLists { get; set; }
        public virtual DbSet<TbPatient> TbPatients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=iorgaoserver.database.windows.net;Initial Catalog=iorgaoSQL_BD;User ID=orgao;Password=GeneralDev123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAdress>(entity =>
            {
                entity.HasKey(e => e.IdAdress)
                    .HasName("PK__TB_ADRES__4826D6167FEC4263");

                entity.ToTable("TB_ADRESS");

                entity.Property(e => e.IdAdress).HasColumnName("id_adress");

                entity.Property(e => e.CityAdress)
                    .IsRequired()
                    .HasColumnName("city_adress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ComplementAdress)
                    .IsRequired()
                    .HasColumnName("complement_adress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreatedAdress)
                    .HasColumnName("date_created_adress")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdatedAdress)
                    .HasColumnName("date_updated_adress")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumberAdress).HasColumnName("number_adress");

                entity.Property(e => e.StateAdress)
                    .IsRequired()
                    .HasColumnName("state_adress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAdress)
                    .IsRequired()
                    .HasColumnName("street_adress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ZipcodeAdress)
                    .IsRequired()
                    .HasColumnName("zipcode_adress")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbDoctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__TB_DOCTO__34D8A305062ED47C");

                entity.ToTable("TB_DOCTOR");

                entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

                entity.Property(e => e.CrmDoctor).HasColumnName("crm_doctor");

                entity.Property(e => e.DateCreatedDoctor)
                    .HasColumnName("date_created_doctor")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdatedDoctor)
                    .HasColumnName("date_updated_doctor")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailDoctor)
                    .HasColumnName("email_doctor")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdPatient).HasColumnName("id_patient");

                entity.Property(e => e.NameDoctor)
                    .IsRequired()
                    .HasColumnName("name_doctor")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordDoctor)
                    .HasColumnName("password_doctor")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneDoctor)
                    .IsRequired()
                    .HasColumnName("phone_doctor")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.RgDoctor)
                    .IsRequired()
                    .HasColumnName("rg_doctor")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.TbDoctors)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("FK__TB_DOCTOR__date___2FCF1A8A");
            });

            modelBuilder.Entity<TbDonation>(entity =>
            {
                entity.HasKey(e => e.IdDonation)
                    .HasName("PK__TB_DONAT__B6DFE9DD355EAEEE");

                entity.ToTable("TB_DONATION");

                entity.Property(e => e.IdDonation).HasColumnName("id_donation");

                entity.Property(e => e.DateCreatedDonation)
                    .HasColumnName("date_created_donation")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdatedDonation)
                    .HasColumnName("date_updated_donation")
                    .HasColumnType("datetime");

                entity.Property(e => e.DsDonation)
                    .HasColumnName("ds_donation")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

                entity.Property(e => e.IdDonator).HasColumnName("id_donator");

                entity.Property(e => e.IdPatient).HasColumnName("id_patient");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.TbDonations)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("FK__TB_DONATI__id_do__3493CFA7");

                entity.HasOne(d => d.IdDonatorNavigation)
                    .WithMany(p => p.TbDonations)
                    .HasForeignKey(d => d.IdDonator)
                    .HasConstraintName("FK__TB_DONATI__date___32AB8735");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.TbDonations)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("FK__TB_DONATI__id_pa__339FAB6E");
            });

            modelBuilder.Entity<TbDonator>(entity =>
            {
                entity.HasKey(e => e.IdDonator)
                    .HasName("PK__TB_DONAT__46BA08946E269DE8");

                entity.ToTable("TB_DONATOR");

                entity.Property(e => e.IdDonator).HasColumnName("id_donator");

                entity.Property(e => e.BirthdateDonator)
                    .HasColumnName("birthdate_donator")
                    .HasColumnType("date");

                entity.Property(e => e.BloodTypeDonator)
                    .IsRequired()
                    .HasColumnName("blood_type_donator")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CpfDonator)
                    .IsRequired()
                    .HasColumnName("cpf_donator")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreatedDonator)
                    .HasColumnName("date_created_donator")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdatedDonator)
                    .HasColumnName("date_updated_donator")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailDonator)
                    .IsRequired()
                    .HasColumnName("email_donator")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GenreDonator)
                    .IsRequired()
                    .HasColumnName("genre_donator")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HeightDonator).HasColumnName("height_donator");

                entity.Property(e => e.IdAdress).HasColumnName("id_adress");

                entity.Property(e => e.IdOrgan).HasColumnName("id_organ");

                entity.Property(e => e.NameDonator)
                    .IsRequired()
                    .HasColumnName("name_donator")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordDonator)
                    .IsRequired()
                    .HasColumnName("password_donator")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneDonator)
                    .IsRequired()
                    .HasColumnName("phone_donator")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.RgDonator)
                    .IsRequired()
                    .HasColumnName("rg_donator")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.WeightDonator).HasColumnName("weight_donator");

                entity.HasOne(d => d.IdAdressNavigation)
                    .WithMany(p => p.TbDonators)
                    .HasForeignKey(d => d.IdAdress)
                    .HasConstraintName("FK__TB_DONATO__date___282DF8C2");

                entity.HasOne(d => d.IdOrganNavigation)
                    .WithMany(p => p.TbDonators)
                    .HasForeignKey(d => d.IdOrgan)
                    .HasConstraintName("FK__TB_DONATO__id_or__29221CFB");
            });

            modelBuilder.Entity<TbOrgan>(entity =>
            {
                entity.HasKey(e => e.IdOrgan)
                    .HasName("PK__TB_ORGAN__062B9172E118B7C8");

                entity.ToTable("TB_ORGAN");

                entity.Property(e => e.IdOrgan).HasColumnName("id_organ");

                entity.Property(e => e.AgeOrgan).HasColumnName("age_organ");

                entity.Property(e => e.ConditionOrgan)
                    .IsRequired()
                    .HasColumnName("condition_organ")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionOrgan)
                    .IsRequired()
                    .HasColumnName("description_organ")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.GenderOrgan)
                    .IsRequired()
                    .HasColumnName("gender_organ")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HeightOrgan).HasColumnName("height_organ");

                entity.Property(e => e.NameOrgan)
                    .IsRequired()
                    .HasColumnName("name_organ")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WeightOrgan).HasColumnName("weight_organ");
            });

            modelBuilder.Entity<TbOrganList>(entity =>
            {
                entity.HasKey(e => e.IdOrg)
                    .HasName("PK__TB_ORGAN__6E0C5F09A87B2068");

                entity.ToTable("TB_ORGAN_LIST");

                entity.Property(e => e.IdOrg).HasColumnName("id_org");

                entity.Property(e => e.NameOrg)
                    .HasColumnName("name_org")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbPatient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("PK__TB_PATIE__4339908AAAC41282");

                entity.ToTable("TB_PATIENT");

                entity.Property(e => e.IdPatient).HasColumnName("id_patient");

                entity.Property(e => e.BirthdatePatient)
                    .HasColumnName("birthdate_patient")
                    .HasColumnType("date");

                entity.Property(e => e.BloodTypePatient)
                    .IsRequired()
                    .HasColumnName("blood_type_patient")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CpfPatient)
                    .IsRequired()
                    .HasColumnName("cpf_patient")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreatedPatient)
                    .HasColumnName("date_created_patient")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdatedPatient)
                    .HasColumnName("date_updated_patient")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailPatient)
                    .IsRequired()
                    .HasColumnName("email_patient")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GenrePatient)
                    .IsRequired()
                    .HasColumnName("genre_patient")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HeightPatient).HasColumnName("height_patient");

                entity.Property(e => e.IdAdress).HasColumnName("id_adress");

                entity.Property(e => e.IdOrgan).HasColumnName("id_organ");

                entity.Property(e => e.NamePatient)
                    .IsRequired()
                    .HasColumnName("name_patient")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordPatient)
                    .IsRequired()
                    .HasColumnName("password_patient")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhonePatient)
                    .IsRequired()
                    .HasColumnName("phone_patient")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.RgPatient)
                    .IsRequired()
                    .HasColumnName("rg_patient")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.WeightPatient).HasColumnName("weight_patient");

                entity.HasOne(d => d.IdAdressNavigation)
                    .WithMany(p => p.TbPatients)
                    .HasForeignKey(d => d.IdAdress)
                    .HasConstraintName("FK__TB_PATIEN__date___2BFE89A6");

                entity.HasOne(d => d.IdOrganNavigation)
                    .WithMany(p => p.TbPatients)
                    .HasForeignKey(d => d.IdOrgan)
                    .HasConstraintName("FK__TB_PATIEN__id_or__2CF2ADDF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
