using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NguyenThePhuc_241230818_DeThiMau.Models;

namespace NguyenThePhuc_241230818_DeThiMau.Data;

public partial class QLHangHoaContext : DbContext
{
    public QLHangHoaContext()
    {
    }

    public QLHangHoaContext(DbContextOptions<QLHangHoaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HangHoa> HangHoas { get; set; }

    public virtual DbSet<LoaiHang> LoaiHangs { get; set; }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=QLHangHoa;User Id=sa;Password=123456;TrustServerCertificate=True;Encrypt=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HangHoa>(entity =>
        {
            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.HangHoas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HangHoa_LoaiHang");
        });

        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.Property(e => e.Password).IsFixedLength();
            entity.Property(e => e.Username).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
