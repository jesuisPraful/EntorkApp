using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MeterReadingDAL.Models;

public partial class EntorkMeterReadingDbContext : DbContext
{
    public EntorkMeterReadingDbContext()
    {
    }

    public EntorkMeterReadingDbContext(DbContextOptions<EntorkMeterReadingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MeterReading> MeterReadings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog= EntorkMeterReadingDB; Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeterReading>(entity =>
        {
            entity.HasKey(e => e.MeterReadingId).HasName("PK__MeterRea__AFB4FDB9EA610386");

            entity.ToTable("MeterReading");

            entity.Property(e => e.MeterReadingId).HasColumnName("MeterReadingID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ReadingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
