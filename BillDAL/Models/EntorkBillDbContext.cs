using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BillDAL.Models;

public partial class EntorkBillDbContext : DbContext
{
    public EntorkBillDbContext()
    {
    }

    public EntorkBillDbContext(DbContextOptions<EntorkBillDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog= EntorkBillDB; Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bill__11F2FC4A52702373");

            entity.ToTable("Bill");

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.BillAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BillDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.BillStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ReadingId).HasColumnName("ReadingID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
