using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Api.Models
{
    public partial class OfficeSpaceAllocationContext : DbContext
    {
        public OfficeSpaceAllocationContext()
        {
        }

        public OfficeSpaceAllocationContext(DbContextOptions<OfficeSpaceAllocationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<OfficeFloorDetail> OfficeFloorDetail { get; set; }
        public virtual DbSet<OfficeSeatDetail> OfficeSeatDetail { get; set; }
        public virtual DbSet<RoleMaster> RoleMaster { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserRoleMaster> UserRoleMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:hackathon-cs.database.windows.net,1433;Database=OfficeSpaceAllocation;user id=hackathon;password=cloudecare@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.LoginKey);

                entity.Property(e => e.LoginKey).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserKeyNavigation)
                    .WithMany(p => p.LoginInfo)
                    .HasForeignKey(d => d.UserKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoginInfo_UserInfo");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.OfficeKey);

                entity.Property(e => e.OfficeKey).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OfficeFloorDetail>(entity =>
            {
                entity.HasKey(e => e.OfficeFloorDetailKey);

                entity.Property(e => e.OfficeFloorDetailKey).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ZoneName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.OfficeKeyNavigation)
                    .WithMany(p => p.OfficeFloorDetail)
                    .HasForeignKey(d => d.OfficeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfficeFloorDetail_Office");
            });

            modelBuilder.Entity<OfficeSeatDetail>(entity =>
            {
                entity.HasKey(e => e.OfficeSeatDetailKey);

                entity.Property(e => e.OfficeSeatDetailKey).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.SeatNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.OfficeFloorDetailKeyNavigation)
                    .WithMany(p => p.OfficeSeatDetail)
                    .HasForeignKey(d => d.OfficeFloorDetailKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfficeSeatDetail_OfficeFloorDetail");
            });

            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.HasKey(e => e.RoleKey);

                entity.Property(e => e.RoleKey).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserKey);

                entity.Property(e => e.UserKey).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Oecode)
                    .IsRequired()
                    .HasColumnName("OECode")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRoleMaster>(entity =>
            {
                entity.HasKey(e => e.UserRoleKey);

                entity.Property(e => e.UserRoleKey).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RoleKeyNavigation)
                    .WithMany(p => p.UserRoleMaster)
                    .HasForeignKey(d => d.RoleKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoleMaster_RoleMaster");

                entity.HasOne(d => d.UserKeyNavigation)
                    .WithMany(p => p.UserRoleMaster)
                    .HasForeignKey(d => d.UserKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoleMaster_UserInfo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        public async Task<DataTable> SelectTable(string procName, SqlParameter[] sqlParams)
        {
            var task = Task.Run(() =>
            {
                var dtDatble = new DataTable();
                var connectionString = Database.GetDbConnection().ConnectionString;

                using (var sqlCommand = new SqlCommand(procName, new SqlConnection(connectionString)))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(sqlParams);

                    if (sqlCommand.Connection.State != ConnectionState.Open)
                        sqlCommand.Connection.Open();

                    using var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dtDatble);
                }
                return dtDatble;
            });
            var res = await task;
            return res;
        }
    }
}
