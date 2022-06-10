using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarWash_DAL.Models
{
    public partial class CarWashDBContext : DbContext
    {
        public CarWashDBContext()
        {
        }

        public CarWashDBContext(DbContextOptions<CarWashDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cwaddress> Cwaddresses { get; set; }
        public virtual DbSet<CwcarRecord> CwcarRecords { get; set; }
        public virtual DbSet<Cwpackage> Cwpackages { get; set; }
        public virtual DbSet<Cwpayment> Cwpayments { get; set; }
        public virtual DbSet<CwscheduleLater> CwscheduleLaters { get; set; }
        public virtual DbSet<CwuserProfile> CwuserProfiles { get; set; }
        public virtual DbSet<CwwashNow> CwwashNows { get; set; }
        public virtual DbSet<CwwashRequest> CwwashRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Udaykumar;Initial Catalog=CarWashDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cwaddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__CWAddres__091C2AFB654501CE");

                entity.ToTable("CWAddress");

                entity.Property(e => e.AddressCity)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AddressLandmark)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AddressLine2).HasMaxLength(100);

                entity.Property(e => e.AddressPincode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AddressState)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cwaddresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CWAddress__UserI__38996AB5");
            });

            modelBuilder.Entity<CwcarRecord>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__CWCarRec__68A0342E947C8E52");

                entity.ToTable("CWCarRecords");

                entity.HasIndex(e => e.CarRegistrationNumber, "UQ__CWCarRec__FB6BBA44FD7E9130")
                    .IsUnique();

                entity.Property(e => e.CarColor)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CarCompany)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CarModel)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CarRegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CwcarRecords)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CWCarReco__UserI__2A4B4B5E");
            });

            modelBuilder.Entity<Cwpackage>(entity =>
            {
                entity.HasKey(e => e.PackageId)
                    .HasName("PK__CWPackag__322035CC64BE2D83");

                entity.ToTable("CWPackage");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PackageCost)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PackageDetails)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Cwpayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__CWPaymen__9B556A38607FCFC3");

                entity.ToTable("CWPayment");

                entity.Property(e => e.CardHolderName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ExpiryDate).HasMaxLength(20);

                entity.Property(e => e.PaymentMethods)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cwpayments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CWPayment__UserI__2E1BDC42");
            });

            modelBuilder.Entity<CwscheduleLater>(entity =>
            {
                entity.HasKey(e => e.SchedulelaterId)
                    .HasName("PK__CWSchedu__84E8054585F2E2E8");

                entity.ToTable("CWScheduleLater");

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SchedulelaterCarLocation)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SchedulelaterRequestTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchedulelaterSelectedcar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchedulelaterWashNotes).HasMaxLength(100);

                entity.Property(e => e.UsercreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CwscheduleLaters)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CWSchedul__UserI__32E0915F");
            });

            modelBuilder.Entity<CwuserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__CWUserPr__1788CC4C9F33F9B1");

                entity.ToTable("CWUserProfile");

                entity.HasIndex(e => e.UserEmail, "UQ__CWUserPr__08638DF8E4A731C7")
                    .IsUnique();

                entity.HasIndex(e => e.UserMobileNumber, "UQ__CWUserPr__8C28638FC26A49D7")
                    .IsUnique();

                entity.Property(e => e.UserCreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserGender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserMobileNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserRole)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CwwashNow>(entity =>
            {
                entity.HasKey(e => e.WashNowId)
                    .HasName("PK__CWWashNo__058FFA319FFECC5A");

                entity.ToTable("CWWashNow");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RequestStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WashNowCarLocation)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WashNowRequestTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WashNowSelectedCar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WashNowWashNotes).HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CwwashNows)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CWWashNow__UserI__3C69FB99");
            });

            modelBuilder.Entity<CwwashRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__CWWashRe__33A8517AB8F0E2C4");

                entity.ToTable("CWWashRequest");

                entity.Property(e => e.CarLocation)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RequestTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SelectedCar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WashNotes).HasMaxLength(100);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.CwwashRequests)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK__CWWashReq__Packa__440B1D61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CwwashRequests)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CWWashReq__UserI__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
