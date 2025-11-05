using EVOpsPro.Repositories.KhiemNVD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace EVOpsPro.Repositories.KhiemNVD.DBContext;

public partial class FA25_PRN232_SE1713_G2_EVOpsProContext : DbContext
{
    public FA25_PRN232_SE1713_G2_EVOpsProContext()
    {
    }

    public FA25_PRN232_SE1713_G2_EVOpsProContext(DbContextOptions<FA25_PRN232_SE1713_G2_EVOpsProContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppointmentStatusTrungDn> AppointmentStatusTrungDns { get; set; }

    public virtual DbSet<AppointmentTrungDn> AppointmentTrungDns { get; set; }

    public virtual DbSet<CustomerVehicleTriNc> CustomerVehicleTriNcs { get; set; }

    public virtual DbSet<MaintenanceProcessVietHq> MaintenanceProcessVietHqs { get; set; }

    public virtual DbSet<MaintenanceStepVietHq> MaintenanceStepVietHqs { get; set; }

    public virtual DbSet<PartCategoryDuongNm> PartCategoryDuongNms { get; set; }

    public virtual DbSet<PartDuongNm> PartDuongNms { get; set; }

    public virtual DbSet<ReminderKhiemNvd> ReminderKhiemNvds { get; set; }

    public virtual DbSet<ReminderTypeKhiemNvd> ReminderTypeKhiemNvds { get; set; }

    public virtual DbSet<ShiftKhoaPa> ShiftKhoaPas { get; set; }

    public virtual DbSet<SystemUserAccount> SystemUserAccounts { get; set; }

    public virtual DbSet<TechnicianKhoaPa> TechnicianKhoaPas { get; set; }


    public virtual DbSet<VehicleTypeTriNc> VehicleTypeTriNcs { get; set; }

    public virtual DbSet<WorkOrderChecklistTienHn> WorkOrderChecklistTienHns { get; set; }

    public virtual DbSet<WorkOrderTienHn> WorkOrderTienHns { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=1234;Database=FA25_PRN232_SE1713_G2_EVOpsPro;TrustServerCertificate=True");

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppointmentStatusTrungDn>(entity =>
        {
            entity.HasKey(e => e.AppointmentStatusTrungDnid).HasName("PK__Appointm__DC4E86EB13F14196");

            entity.ToTable("AppointmentStatusTrungDN");

            entity.Property(e => e.AppointmentStatusTrungDnid).HasColumnName("AppointmentStatusTrungDNID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<AppointmentTrungDn>(entity =>
        {
            entity.HasKey(e => e.AppointmentTrungDnid).HasName("PK__Appointm__33A5CE81FB8B1C25");

            entity.ToTable("AppointmentTrungDN");

            entity.Property(e => e.AppointmentTrungDnid).HasColumnName("AppointmentTrungDNID");
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.AppointmentStatusTrungDnid).HasColumnName("AppointmentStatusTrungDNID");
            entity.Property(e => e.ConfirmedBy).HasMaxLength(50);
            entity.Property(e => e.ConfirmedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(200);
            entity.Property(e => e.ServiceCenter).HasMaxLength(100);
            entity.Property(e => e.ServiceType).HasMaxLength(100);
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");

            entity.HasOne(d => d.AppointmentStatusTrungDn).WithMany(p => p.AppointmentTrungDns)
                .HasForeignKey(d => d.AppointmentStatusTrungDnid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Appoi__4BAC3F29");

            entity.HasOne(d => d.SystemUserAccount).WithMany(p => p.AppointmentTrungDns)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__UserA__4AB81AF0");
        });

        modelBuilder.Entity<CustomerVehicleTriNc>(entity =>
        {
            entity.HasKey(e => e.CustomerVehicleTriNcid).HasName("PK__Customer__ED1968D778131081");

            entity.ToTable("CustomerVehicleTriNC");

            entity.Property(e => e.CustomerVehicleTriNcid).HasColumnName("CustomerVehicleTriNCID");
            entity.Property(e => e.CustomerFullName).HasMaxLength(100);
            entity.Property(e => e.VehicleName).HasMaxLength(120);
            entity.Property(e => e.Email).HasMaxLength(120);
            entity.Property(e => e.ServiceDate).HasColumnType("datetime");
            entity.Property(e => e.VehicleTypeTriNcid).HasColumnName("VehicleTypeTriNCId");
            entity.Property(e => e.Vin)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("VIN");
            entity.Property(e => e.WorkDescription).HasMaxLength(1000);

            entity.HasOne(d => d.VehicleTypeTriNc).WithMany(p => p.CustomerVehicleTriNcs)
                .HasForeignKey(d => d.VehicleTypeTriNcid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CVS_ManufacturersTriNC");
        });

        modelBuilder.Entity<MaintenanceProcessVietHq>(entity =>
        {
            entity.HasKey(e => e.MaintenanceProcessVietHqid).HasName("PK__Maintena__90D5E3E206858484");

            entity.ToTable("MaintenanceProcessVietHQ");

            entity.Property(e => e.MaintenanceProcessVietHqid).HasColumnName("MaintenanceProcessVietHQID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MaintenanceStepVietHqid).HasColumnName("MaintenanceStepVietHQID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(200);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            entity.Property(e => e.VehicleVin)
                .HasMaxLength(50)
                .HasColumnName("VehicleVIN");

            entity.HasOne(d => d.MaintenanceStepVietHq).WithMany(p => p.MaintenanceProcessVietHqs)
                .HasForeignKey(d => d.MaintenanceStepVietHqid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Maintenan__Maint__6477ECF3");

            entity.HasOne(d => d.SystemUserAccount).WithMany(p => p.MaintenanceProcessVietHqs)
                .HasForeignKey(d => d.UserAccountId)
                .HasConstraintName("FK__Maintenan__UserA__656C112C");
        });

        modelBuilder.Entity<MaintenanceStepVietHq>(entity =>
        {
            entity.HasKey(e => e.MaintenanceStepVietHqid).HasName("PK__Maintena__D538F2BC35629DB8");

            entity.ToTable("MaintenanceStepVietHQ");

            entity.Property(e => e.MaintenanceStepVietHqid).HasColumnName("MaintenanceStepVietHQID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StepName).HasMaxLength(100);
        });

        modelBuilder.Entity<PartCategoryDuongNm>(entity =>
        {
            entity.HasKey(e => e.PartCategoryDuongNmid).HasName("PK__PartCate__6DFE33675426663B");

            entity.ToTable("PartCategoryDuongNM");

            entity.Property(e => e.PartCategoryDuongNmid).HasColumnName("PartCategoryDuongNMID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<PartDuongNm>(entity =>
        {
            entity.HasKey(e => e.PartDuongNmid).HasName("PK__PartDuon__1B0186566B456E54");

            entity.ToTable("PartDuongNM");

            entity.HasIndex(e => e.PartCode, "UQ__PartDuon__6525D39D38DEA3D1").IsUnique();

            entity.Property(e => e.PartDuongNmid).HasColumnName("PartDuongNMID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PartCategoryDuongNmid).HasColumnName("PartCategoryDuongNMID");
            entity.Property(e => e.PartCode).HasMaxLength(50);
            entity.Property(e => e.PartName).HasMaxLength(100);
            entity.Property(e => e.Supplier).HasMaxLength(100);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");

            entity.HasOne(d => d.PartCategoryDuongNm).WithMany(p => p.PartDuongNms)
                .HasForeignKey(d => d.PartCategoryDuongNmid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PartDuong__PartC__6EF57B66");

            entity.HasOne(d => d.SystemUserAccount).WithMany(p => p.PartDuongNms)
                .HasForeignKey(d => d.UserAccountId)
                .HasConstraintName("FK__PartDuong__UserA__6FE99F9F");
        });

        modelBuilder.Entity<ReminderKhiemNvd>(entity =>
        {
            entity.HasKey(e => e.ReminderKhiemNvdid).HasName("PK__Reminder__65F314A79D12F21C");

            entity.ToTable("ReminderKhiemNVD");

            entity.Property(e => e.ReminderKhiemNvdid).HasColumnName("ReminderKhiemNVDID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Message).HasMaxLength(200);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ReminderTypeKhiemNvdid).HasColumnName("ReminderTypeKhiemNVDID");
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            entity.Property(e => e.VehicleVin)
                .HasMaxLength(50)
                .HasColumnName("VehicleVIN");

            entity.HasOne(d => d.ReminderTypeKhiemNvd).WithMany(p => p.ReminderKhiemNvds)
                .HasForeignKey(d => d.ReminderTypeKhiemNvdid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReminderK__Remin__412EB0B6");

            entity.HasOne(d => d.SystemUserAccount).WithMany(p => p.ReminderKhiemNvds)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReminderK__UserA__403A8C7D");
        });

        modelBuilder.Entity<ReminderTypeKhiemNvd>(entity =>
        {
            entity.HasKey(e => e.ReminderTypeKhiemNvdid).HasName("PK__Reminder__B0C59458F1FAAF48");

            entity.ToTable("ReminderTypeKhiemNVD");

            entity.Property(e => e.ReminderTypeKhiemNvdid).HasColumnName("ReminderTypeKhiemNVDID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<ShiftKhoaPa>(entity =>
        {
            entity.HasKey(e => e.ShiftKhoaPaid).HasName("PK__ShiftKho__BB7764024E751BA7");

            entity.ToTable("ShiftKhoaPA");

            entity.Property(e => e.ShiftKhoaPaid).HasColumnName("ShiftKhoaPAID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ShiftName).HasMaxLength(50);
        });

        modelBuilder.Entity<SystemUserAccount>(entity =>
        {
            entity.HasKey(e => e.UserAccountId);

            entity.ToTable("System.UserAccount");

            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            entity.Property(e => e.ApplicationCode).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.EmployeeCode).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.RequestCode).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<TechnicianKhoaPa>(entity =>
        {
            entity.HasKey(e => e.TechnicianKhoaPaid).HasName("PK__Technici__CAE6FA5BBCD7292C");

            entity.ToTable("TechnicianKhoaPA");

            entity.Property(e => e.TechnicianKhoaPaid).HasColumnName("TechnicianKhoaPAID");
            entity.Property(e => e.Certificate).HasMaxLength(100);
            entity.Property(e => e.EfficiencyScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ShiftKhoaPaid).HasColumnName("ShiftKhoaPAID");
            entity.Property(e => e.Specialty).HasMaxLength(100);
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");

            entity.HasOne(d => d.ShiftKhoaPa).WithMany(p => p.TechnicianKhoaPas)
                .HasForeignKey(d => d.ShiftKhoaPaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Technicia__Shift__797309D9");

            entity.HasOne(d => d.SystemUserAccount).WithMany(p => p.TechnicianKhoaPas)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Technicia__UserA__787EE5A0");
        });


        modelBuilder.Entity<VehicleTypeTriNc>(entity =>
        {
            entity.HasKey(e => e.VehicleTypeTriNcid).HasName("PK__Manufact__103B7ADF16C715D2");

            entity.ToTable("VehicleTypeTriNC");

            entity.HasIndex(e => e.Name, "UQ_ManufacturersTriNC_Name").IsUnique();

            entity.Property(e => e.VehicleTypeTriNcid).HasColumnName("VehicleTypeTriNCId");
            entity.Property(e => e.Country).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Website).HasMaxLength(200);
        });

        modelBuilder.Entity<WorkOrderChecklistTienHn>(entity =>
        {
            entity.HasKey(e => e.WorkOrderChecklistTienHnid).HasName("PK__WorkOrde__2EA0F0849FFD9174");

            entity.ToTable("WorkOrderChecklistTienHN");

            entity.Property(e => e.WorkOrderChecklistTienHnid).HasColumnName("WorkOrderChecklistTienHNID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemName).HasMaxLength(100);
        });

        modelBuilder.Entity<WorkOrderTienHn>(entity =>
        {
            entity.HasKey(e => e.WorkOrderTienHnid).HasName("PK__WorkOrde__F7C6CAC060D303D8");

            entity.ToTable("WorkOrderTienHN");

            entity.Property(e => e.WorkOrderTienHnid).HasColumnName("WorkOrderTienHNID");
            entity.Property(e => e.ChecklistResult).HasMaxLength(200);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            entity.Property(e => e.WorkOrderChecklistTienHnid).HasColumnName("WorkOrderChecklistTienHNID");

            entity.HasOne(d => d.SystemUserAccount).WithMany(p => p.WorkOrderTienHns)
                .HasForeignKey(d => d.UserAccountId)
                .HasConstraintName("FK__WorkOrder__UserA__5BE2A6F2");

            entity.HasOne(d => d.WorkOrderChecklistTienHn).WithMany(p => p.WorkOrderTienHns)
                .HasForeignKey(d => d.WorkOrderChecklistTienHnid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkOrder__WorkO__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
