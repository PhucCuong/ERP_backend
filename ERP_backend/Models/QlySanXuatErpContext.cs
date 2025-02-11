using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Models;

public partial class QlySanXuatErpContext : DbContext
{
    public QlySanXuatErpContext()
    {
    }

    public QlySanXuatErpContext(DbContextOptions<QlySanXuatErpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaoCaoSanXuat> BaoCaoSanXuats { get; set; }

    public virtual DbSet<BaoTri> BaoTris { get; set; }

    public virtual DbSet<ChiPhiSanXuat> ChiPhiSanXuats { get; set; }

    public virtual DbSet<ChiTietHoatDongSanXuat> ChiTietHoatDongSanXuats { get; set; }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<DinhMucNguyenVatLieu> DinhMucNguyenVatLieus { get; set; }

    public virtual DbSet<KeHoachSanXuat> KeHoachSanXuats { get; set; }

    public virtual DbSet<KiemTraChatLuong> KiemTraChatLuongs { get; set; }

    public virtual DbSet<LenhGoBo> LenhGoBos { get; set; }

    public virtual DbSet<LenhLamViec> LenhLamViecs { get; set; }

    public virtual DbSet<LenhSanXuat> LenhSanXuats { get; set; }

    public virtual DbSet<NguyenVatLieu> NguyenVatLieus { get; set; }

    public virtual DbSet<NhaMay> NhaMays { get; set; }

    public virtual DbSet<NhapKho> NhapKhos { get; set; }

    public virtual DbSet<QuyTrinhSanXuat> QuyTrinhSanXuats { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<YeuCauNguyenVatLieu> YeuCauNguyenVatLieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-0DG5ETM\\SQLEXPRESS;Database=QlySanXuatERP;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaoCaoSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaBaoCao).HasName("PK__BaoCaoSa__25A9188CBF9BD202");

            entity.ToTable("BaoCaoSanXuat");

            entity.HasIndex(e => e.MaKeHoach, "IX_BaoCaoSanXuat_MaKeHoach");

            entity.HasIndex(e => e.MaSanPham, "IX_BaoCaoSanXuat_MaSanPham");

            entity.Property(e => e.MaBaoCao).HasDefaultValueSql("(newid())");
            entity.Property(e => e.HieuSuatSanXuat)
                .HasComputedColumnSql("([SoLuongSxThucTe]/[SoLuongSxMucTieu])", true)
                .HasColumnType("decimal(38, 20)");
            entity.Property(e => e.NgayChinhSua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoLuongSxMucTieu).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SoLuongSxThucTe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenSanPham).HasMaxLength(255);
            entity.Property(e => e.ThoiGianSanXuatKeHoach).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThoiGianSanXuatThucTe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKeHoachNavigation).WithMany(p => p.BaoCaoSanXuats)
                .HasForeignKey(d => d.MaKeHoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaoCaoSan__MaKeH__60A75C0F");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.BaoCaoSanXuats)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaoCaoSan__MaSan__619B8048");
        });

        modelBuilder.Entity<BaoTri>(entity =>
        {
            entity.HasKey(e => e.MaBaoTri).HasName("PK__BaoTri__51A9CA5157571B35");

            entity.ToTable("BaoTri");

            entity.HasIndex(e => e.MaNhaMay, "IX_BaoTri_MaNhaMay");

            entity.Property(e => e.MaBaoTri).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TenBaoTri).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNhaMayNavigation).WithMany(p => p.BaoTris)
                .HasForeignKey(d => d.MaNhaMay)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaoTri__MaNhaMay__4AB81AF0");
        });

        modelBuilder.Entity<ChiPhiSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaChiPhiSanXuat).HasName("PK__ChiPhiSa__5ECCCAAC65501F0F");

            entity.ToTable("ChiPhiSanXuat");

            entity.HasIndex(e => e.MaLenhSanXuat, "IX_ChiPhiSanXuat_MaLenhSanXuat");

            entity.Property(e => e.MaChiPhiSanXuat).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LoaiChiPhi).HasMaxLength(100);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaLenhSanXuatNavigation).WithMany(p => p.ChiPhiSanXuats)
                .HasForeignKey(d => d.MaLenhSanXuat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiPhiSan__MaLen__4F7CD00D");
        });

        modelBuilder.Entity<ChiTietHoatDongSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaHoatDong).HasName("PK__ChiTietH__BD808BE75151BC9A");

            entity.ToTable("ChiTietHoatDongSanXuat");

            entity.Property(e => e.MaHoatDong).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DieuKienBatDauGiaiDoanTiepTheo).HasMaxLength(50);
            entity.Property(e => e.GiaiDoanSanXuat).HasMaxLength(100);
            entity.Property(e => e.LoaiTinhThoiGian).HasMaxLength(50);
            entity.Property(e => e.SoLuongCho).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenHoatDong).HasMaxLength(255);
            entity.Property(e => e.ThoiGianMacDinh).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaQuyTrinhNavigation).WithMany(p => p.ChiTietHoatDongSanXuats)
                .HasForeignKey(d => d.MaQuyTrinh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaQuy__37A5467C");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.MaChucVu).HasName("PK__ChucVu__D4639533802CA270");

            entity.ToTable("ChucVu");

            entity.Property(e => e.MaChucVu).ValueGeneratedNever();
            entity.Property(e => e.TenChucVu).HasMaxLength(50);
        });

        modelBuilder.Entity<DinhMucNguyenVatLieu>(entity =>
        {
            entity.HasKey(e => e.MaDinhMuc).HasName("PK__DinhMucN__DD5A07C317B813EA");

            entity.ToTable("DinhMucNguyenVatLieu");

            entity.Property(e => e.MaDinhMuc).HasDefaultValueSql("(newid())");
            entity.Property(e => e.MucDoSuDung).HasMaxLength(50);
            entity.Property(e => e.NgayChinhSua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThoiGianSanXuat).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaNguyenVatLieuNavigation).WithMany(p => p.DinhMucNguyenVatLieus)
                .HasForeignKey(d => d.MaNguyenVatLieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DinhMucNg__MaNgu__2A4B4B5E");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.DinhMucNguyenVatLieus)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DinhMucNg__MaSan__29572725");
        });

        modelBuilder.Entity<KeHoachSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaKeHoach).HasName("PK__KeHoachS__88C5741F08A80648");

            entity.ToTable("KeHoachSanXuat");

            entity.HasIndex(e => e.MaNhaMay, "IX_KeHoachSanXuat_MaNhaMay");

            entity.HasIndex(e => e.MaSanPham, "IX_KeHoachSanXuat_MaSanPham");

            entity.Property(e => e.MaKeHoach).HasDefaultValueSql("(newid())");
            entity.Property(e => e.MucTonKhoAnToan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NgayChinhSua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NguoiChinhSua).HasMaxLength(100);
            entity.Property(e => e.NguoiTao).HasMaxLength(100);
            entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SoLuongSanXuatToiDa).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SoLuongSanXuatToiThieu).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNhaMayNavigation).WithMany(p => p.KeHoachSanXuats)
                .HasForeignKey(d => d.MaNhaMay)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KeHoachSa__MaNha__239E4DCF");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.KeHoachSanXuats)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KeHoachSa__MaSan__22AA2996");
        });

        modelBuilder.Entity<KiemTraChatLuong>(entity =>
        {
            entity.HasKey(e => e.MaKiemTra).HasName("PK__KiemTraC__5274B031DCDBA39B");

            entity.ToTable("KiemTraChatLuong");

            entity.HasIndex(e => e.MaSanPham, "IX_KiemTraChatLuong_MaSanPham");

            entity.Property(e => e.MaKiemTra).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DoiKiemTra).HasMaxLength(100);
            entity.Property(e => e.KetQua).HasMaxLength(50);
            entity.Property(e => e.NgayChinhSua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NguoiPhuTrach).HasMaxLength(100);

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.KiemTraChatLuongs)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KiemTraCh__MaSan__5535A963");
        });

        modelBuilder.Entity<LenhGoBo>(entity =>
        {
            entity.HasKey(e => e.MaLenhGoBo).HasName("PK__LenhGoBo__A1B4B96B754D8F5C");

            entity.ToTable("LenhGoBo");

            entity.HasIndex(e => e.MaKeHoach, "IX_LenhGoBo_MaKeHoach");

            entity.HasIndex(e => e.MaSanPham, "IX_LenhGoBo_MaSanPham");

            entity.Property(e => e.MaLenhGoBo).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LyDoGoBo).HasMaxLength(500);
            entity.Property(e => e.NguoiChiuTrachNhiem).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKeHoachNavigation).WithMany(p => p.LenhGoBos)
                .HasForeignKey(d => d.MaKeHoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhGoBo__MaKeHo__45F365D3");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.LenhGoBos)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhGoBo__MaSanP__46E78A0C");
        });

        modelBuilder.Entity<LenhLamViec>(entity =>
        {
            entity.HasKey(e => e.MaLenhLamViec).HasName("PK__LenhLamV__0AFDD6409B571780");

            entity.ToTable("LenhLamViec");

            entity.Property(e => e.MaLenhLamViec).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KhuVucLamViec).HasMaxLength(100);
            entity.Property(e => e.SoLuongSanXuat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenLenhLamViec).HasMaxLength(255);
            entity.Property(e => e.TongSoLuongYeuCau).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongThoiGianThucHien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaLenhSanXuatNavigation).WithMany(p => p.LenhLamViecs)
                .HasForeignKey(d => d.MaLenhSanXuat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhLamVi__MaLen__412EB0B6");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.LenhLamViecs)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhLamVi__MaSan__4222D4EF");
        });

        modelBuilder.Entity<LenhSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaLenh).HasName("PK__LenhSanX__7D94BAAFD0B4E79E");

            entity.ToTable("LenhSanXuat");

            entity.HasIndex(e => e.MaKeHoach, "IX_LenhSanXuat_MaKeHoach");

            entity.HasIndex(e => e.MaQuyTrinh, "IX_LenhSanXuat_MaQuyTrinh");

            entity.HasIndex(e => e.MaSanPham, "IX_LenhSanXuat_MaSanPham");

            entity.Property(e => e.MaLenh).HasDefaultValueSql("(newid())");
            entity.Property(e => e.NguoiChiuTrachNhiem).HasMaxLength(100);
            entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKeHoachNavigation).WithMany(p => p.LenhSanXuats)
                .HasForeignKey(d => d.MaKeHoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhSanXu__MaKeH__3B75D760");

            entity.HasOne(d => d.MaQuyTrinhNavigation).WithMany(p => p.LenhSanXuats)
                .HasForeignKey(d => d.MaQuyTrinh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhSanXu__MaQuy__3C69FB99");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.LenhSanXuats)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhSanXu__MaSan__3D5E1FD2");
        });

        modelBuilder.Entity<NguyenVatLieu>(entity =>
        {
            entity.HasKey(e => e.MaNguyenVatLieu).HasName("PK__NguyenVa__23D814DD74C3E8A6");

            entity.ToTable("NguyenVatLieu");

            entity.HasIndex(e => e.MaVach, "UQ__NguyenVa__8BBF4A1C8D85EBA8").IsUnique();

            entity.Property(e => e.DonViTinh).HasMaxLength(50);
            entity.Property(e => e.GiaNhap).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaVach).HasMaxLength(50);
            entity.Property(e => e.NhomNguyenVatLieu).HasMaxLength(100);
            entity.Property(e => e.TenNguyenVatLieu).HasMaxLength(255);
            entity.Property(e => e.TonKhoToiDa).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TonKhoToiThieu).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<NhaMay>(entity =>
        {
            entity.HasKey(e => e.MaNhaMay).HasName("PK__NhaMay__DE2FC0564541DF69");

            entity.ToTable("NhaMay");

            entity.Property(e => e.MaNhaMay).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DiaChi).HasMaxLength(500);
            entity.Property(e => e.NguoiQuanLy).HasMaxLength(50);
            entity.Property(e => e.PhanLoai).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenNhaMay).HasMaxLength(255);
        });

        modelBuilder.Entity<NhapKho>(entity =>
        {
            entity.HasKey(e => e.MaNhapKho).HasName("PK__NhapKho__B0602950E7A84C10");

            entity.ToTable("NhapKho");

            entity.HasIndex(e => e.MaSanPham, "IX_NhapKho_MaSanPham");

            entity.Property(e => e.MaNhapKho).HasDefaultValueSql("(newid())");
            entity.Property(e => e.NgayChinhSua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NguoiNhap).HasMaxLength(100);
            entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.NhapKhos)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhapKho__MaSanPh__5AEE82B9");
        });

        modelBuilder.Entity<QuyTrinhSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaQuyTrinh).HasName("PK__QuyTrinh__EEEEC988A184033A");

            entity.ToTable("QuyTrinhSanXuat");

            entity.Property(e => e.MaQuyTrinh).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TenQuyTrinh).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442D53FE9769");

            entity.ToTable("SanPham");

            entity.HasIndex(e => e.MaVach, "UQ__SanPham__8BBF4A1C7CBEFC02").IsUnique();

            entity.Property(e => e.ChiPhiSanXuat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonViTinh).HasMaxLength(50);
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaVach).HasMaxLength(50);
            entity.Property(e => e.NhomSanPham).HasMaxLength(100);
            entity.Property(e => e.TenSanPham).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.MaUser).HasName("PK__User__55DAC4B7E79D8850");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "IX_User_Email");

            entity.HasIndex(e => e.TenDangNhap, "IX_User_TenDangNhap");

            entity.HasIndex(e => e.TenDangNhap, "UQ__User__55F68FC029336264").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534D1887516").IsUnique();

            entity.Property(e => e.MaUser).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.NgayChinhSua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.VaiTro).HasMaxLength(50);

            entity.HasOne(d => d.MaChucVuNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.MaChucVu)
                .HasConstraintName("fk_User_ChucVu");
        });

        modelBuilder.Entity<YeuCauNguyenVatLieu>(entity =>
        {
            entity.HasKey(e => e.MaYeuCauNvl).HasName("PK__YeuCauNg__BBF67A93A86D50B1");

            entity.ToTable("YeuCauNguyenVatLieu");

            entity.HasIndex(e => e.MaKeHoach, "IX_YeuCauNguyenVatLieu_MaKeHoach");

            entity.HasIndex(e => e.MaNguyenVatLieu, "IX_YeuCauNguyenVatLieu_MaNguyenVatLieu");

            entity.Property(e => e.MaYeuCauNvl)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("MaYeuCauNVL");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoLuongCanThiet).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThaiDonHang).HasMaxLength(50);

            entity.HasOne(d => d.MaKeHoachNavigation).WithMany(p => p.YeuCauNguyenVatLieus)
                .HasForeignKey(d => d.MaKeHoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__YeuCauNgu__MaKeH__2F10007B");

            entity.HasOne(d => d.MaNguyenVatLieuNavigation).WithMany(p => p.YeuCauNguyenVatLieus)
                .HasForeignKey(d => d.MaNguyenVatLieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__YeuCauNgu__MaNgu__300424B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
