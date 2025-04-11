using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Models;

public partial class QlySanXuatErpContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
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

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<ChiTietHoatDongSanXuat> ChiTietHoatDongSanXuats { get; set; }

    public virtual DbSet<DinhMucNguyenVatLieu> DinhMucNguyenVatLieus { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<KeHoachSanXuat> KeHoachSanXuats { get; set; }

    public virtual DbSet<KetQuaKiemTra> KetQuaKiemTras { get; set; }

    public virtual DbSet<Kho> Khos { get; set; }

    public virtual DbSet<KiemTraChatLuong> KiemTraChatLuongs { get; set; }

    public virtual DbSet<LenhGoBo> LenhGoBos { get; set; }

    public virtual DbSet<LenhSanXuat> LenhSanXuats { get; set; }

    public virtual DbSet<NguyenVatLieu> NguyenVatLieus { get; set; }

    public virtual DbSet<NhaMay> NhaMays { get; set; }

    public virtual DbSet<NhapKho> NhapKhos { get; set; }

    public virtual DbSet<QuyTrinhSanXuat> QuyTrinhSanXuats { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<SanPhamImg> SanPhamImgs { get; set; }

    public virtual DbSet<TonKho> TonKhos { get; set; }

    public virtual DbSet<YeuCauNguyenVatLieu> YeuCauNguyenVatLieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-0DG5ETM\\SQLEXPRESS01;Initial Catalog=QlySanXuatERP;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
     

        modelBuilder.Entity<BaoCaoSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaBaoCao).HasName("PK__BaoCaoSa__25A9188C98FDDD4C");

            entity.ToTable("BaoCaoSanXuat");

            entity.HasIndex(e => e.MaKeHoach, "IX_BaoCaoSanXuat_MaKeHoach");

            entity.HasIndex(e => e.MaSanPham, "IX_BaoCaoSanXuat_MaSanPham");

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
                .HasConstraintName("FK__BaoCaoSan__MaKeH__160F4887");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.BaoCaoSanXuats)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaoCaoSan__MaSan__17036CC0");
        });

        modelBuilder.Entity<BaoTri>(entity =>
        {
            entity.HasKey(e => e.MaBaoTri).HasName("PK__BaoTri__51A9CA5121EE9C7F");

            entity.ToTable("BaoTri");

            entity.HasIndex(e => e.MaNhaMay, "IX_BaoTri_MaNhaMay");

            entity.Property(e => e.MaBaoTri).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TenBaoTri).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNhaMayNavigation).WithMany(p => p.BaoTris)
                .HasForeignKey(d => d.MaNhaMay)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaoTri__MaNhaMay__17F790F9");
        });

        modelBuilder.Entity<ChiPhiSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaChiPhiSanXuat).HasName("PK__ChiPhiSa__5ECCCAAC84AF582F");

            entity.ToTable("ChiPhiSanXuat");

            entity.HasIndex(e => e.MaLenh, "IX_ChiPhiSanXuat_MaLenhSanXuat");

            entity.Property(e => e.MaChiPhiSanXuat).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LoaiChiPhi).HasMaxLength(100);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaLenhNavigation).WithMany(p => p.ChiPhiSanXuats)
                .HasForeignKey(d => d.MaLenh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiPhiSan__MaLen__18EBB532");
        });

        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => e.MaChiTietDonHang).HasName("PK__ChiTietD__4B0B45DD30EB6642");

            entity.ToTable("ChiTietDonHang");

            entity.Property(e => e.GiaSanPham).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThanhTien)
                .HasComputedColumnSql("([SoLuong]*[GiaSanPham])", true)
                .HasColumnType("decimal(29, 2)");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaDonHang)
                .HasConstraintName("FK_ChiTietDonHang_DonHang");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("FK_ChiTietDonHang_SanPham");
        });

        modelBuilder.Entity<ChiTietHoatDongSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaHoatDong).HasName("PK__ChiTietH__BD808BE794304521");

            entity.ToTable("ChiTietHoatDongSanXuat");

            entity.Property(e => e.MaHoatDong).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DieuKienBatDauGiaiDoanTiepTheo).HasMaxLength(50);
            entity.Property(e => e.GiaiDoanSanXuat).HasMaxLength(100);
            entity.Property(e => e.SoLuongChoXuLy).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenHoatDong).HasMaxLength(255);
            entity.Property(e => e.ThoiGianMacDinh).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaQuyTrinhNavigation).WithMany(p => p.ChiTietHoatDongSanXuats)
                .HasForeignKey(d => d.MaQuyTrinh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaQuy__1BC821DD");
        });

        modelBuilder.Entity<DinhMucNguyenVatLieu>(entity =>
        {
            entity.HasKey(e => e.MaDinhMuc).HasName("PK__DinhMucN__DD5A07C3B2791F48");

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
                .HasConstraintName("FK__DinhMucNg__MaNgu__1CBC4616");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.DinhMucNguyenVatLieus)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DinhMucNg__MaSan__1DB06A4F");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang).HasName("PK__DonHang__129584ADEF26CBBC");

            entity.ToTable("DonHang");

            entity.Property(e => e.MaDonHang).HasDefaultValueSql("(newid())");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.NgayDatHang)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonHang_IdentityUser");
        });

        modelBuilder.Entity<KeHoachSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaKeHoach).HasName("PK__KeHoachS__88C5741FE901778F");

            entity.ToTable("KeHoachSanXuat");

            entity.HasIndex(e => e.MaNhaMay, "IX_KeHoachSanXuat_MaNhaMay");

            entity.HasIndex(e => e.MaSanPham, "IX_KeHoachSanXuat_MaSanPham");

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
                .HasConstraintName("FK__KeHoachSa__MaNha__1F98B2C1");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.KeHoachSanXuats)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KeHoachSa__MaSan__208CD6FA");
        });

        modelBuilder.Entity<KetQuaKiemTra>(entity =>
        {
            entity.HasKey(e => e.KetQuaId).HasName("PK__KetQuaKi__0CFF02031C0DCD29");

            entity.ToTable("KetQuaKiemTra");

            entity.Property(e => e.KetQuaId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KetQua).HasMaxLength(50);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.MaKiemTraNavigation).WithMany(p => p.KetQuaKiemTras)
                .HasForeignKey(d => d.MaKiemTra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KetQuaKie__MaKie__2180FB33");
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity.HasKey(e => e.MaKho).HasName("PK__Kho__3BDA93504E2015FA");

            entity.ToTable("Kho");

            entity.Property(e => e.MaKho).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.TenKho).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<KiemTraChatLuong>(entity =>
        {
            entity.HasKey(e => e.MaKiemTra).HasName("PK__KiemTraC__5274B031FA9F0FE2");

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
                .HasConstraintName("FK__KiemTraCh__MaSan__22751F6C");
        });

        modelBuilder.Entity<LenhGoBo>(entity =>
        {
            entity.HasKey(e => e.MaLenhGoBo).HasName("PK__LenhGoBo__A1B4B96B9F5EB503");

            entity.ToTable("LenhGoBo");

            entity.HasIndex(e => e.MaKeHoach, "IX_LenhGoBo_MaKeHoach");

            entity.HasIndex(e => e.MaSanPham, "IX_LenhGoBo_MaSanPham");

            entity.Property(e => e.LyDoGoBo).HasMaxLength(500);
            entity.Property(e => e.NguoiChiuTrachNhiem).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKeHoachNavigation).WithMany(p => p.LenhGoBos)
                .HasForeignKey(d => d.MaKeHoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhGoBo__MaKeHo__236943A5");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.LenhGoBos)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhGoBo__MaSanP__245D67DE");
        });

        modelBuilder.Entity<LenhSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaLenh).HasName("PK__LenhSanX__7D94BAAF9D20458C");

            entity.ToTable("LenhSanXuat");

            entity.HasIndex(e => e.MaKeHoach, "IX_LenhSanXuat_MaKeHoach");

            entity.HasIndex(e => e.MaQuyTrinh, "IX_LenhSanXuat_MaQuyTrinh");

            entity.HasIndex(e => e.MaSanPham, "IX_LenhSanXuat_MaSanPham");

            entity.Property(e => e.KhuVucSanXuat).HasMaxLength(100);
            entity.Property(e => e.NguoiChiuTrachNhiem).HasMaxLength(100);
            entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKeHoachNavigation).WithMany(p => p.LenhSanXuats)
                .HasForeignKey(d => d.MaKeHoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhSanXu__MaKeH__25518C17");

            entity.HasOne(d => d.MaQuyTrinhNavigation).WithMany(p => p.LenhSanXuats)
                .HasForeignKey(d => d.MaQuyTrinh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhSanXu__MaQuy__2645B050");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.LenhSanXuats)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LenhSanXu__MaSan__2739D489");
        });

        modelBuilder.Entity<NguyenVatLieu>(entity =>
        {
            entity.HasKey(e => e.MaNguyenVatLieu).HasName("PK__NguyenVa__23D814DD764186A7");

            entity.ToTable("NguyenVatLieu");

            entity.HasIndex(e => e.MaVach, "UQ__NguyenVa__8BBF4A1C7A995378").IsUnique();

            entity.Property(e => e.MaNguyenVatLieu).HasDefaultValueSql("(newid())");
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
            entity.HasKey(e => e.MaNhaMay).HasName("PK__NhaMay__DE2FC056188C0FED");

            entity.ToTable("NhaMay");

            entity.Property(e => e.MaNhaMay).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ChiPhi).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiaChi).HasMaxLength(500);
            entity.Property(e => e.NguoiQuanLy).HasMaxLength(50);
            entity.Property(e => e.PhanLoai).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenNhaMay).HasMaxLength(255);
        });

        modelBuilder.Entity<NhapKho>(entity =>
        {
            entity.HasKey(e => e.MaNhapKho).HasName("PK__NhapKho__B06029506CE39CCD");

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
                .HasConstraintName("FK__NhapKho__MaSanPh__282DF8C2");
        });

        modelBuilder.Entity<QuyTrinhSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaQuyTrinh).HasName("PK__QuyTrinh__EEEEC988CD96B23C");

            entity.ToTable("QuyTrinhSanXuat");

            entity.Property(e => e.MaQuyTrinh).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TenQuyTrinh).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442D9F0A2758");

            entity.ToTable("SanPham");

            entity.HasIndex(e => e.MaVach, "UQ__SanPham__8BBF4A1CDBB1BE25").IsUnique();

            entity.Property(e => e.MaSanPham).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DonViTinh).HasMaxLength(50);
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaVach).HasMaxLength(50);
            entity.Property(e => e.NhomSanPham).HasMaxLength(100);
            entity.Property(e => e.TenSanPham).HasMaxLength(255);
        });

        modelBuilder.Entity<SanPhamImg>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__SanPhamI__7516F70CD0599F12");

            entity.ToTable("SanPhamImg");

            entity.Property(e => e.ImageId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ImgUrl).HasColumnName("ImgURL");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.SanPhamImgs)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SanPhamIm__MaSan__29221CFB");
        });

        modelBuilder.Entity<TonKho>(entity =>
        {
            entity.HasKey(e => new { e.MaKho, e.MaNguyenVatLieu }).HasName("PK__TonKho__F9E7121D1F4F1453");

            entity.ToTable("TonKho");

            entity.Property(e => e.MucToiThieu).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NgayCapNhatCuoi).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoLuongTon).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaKhoNavigation).WithMany(p => p.TonKhos)
                .HasForeignKey(d => d.MaKho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TonKho_Kho");

            entity.HasOne(d => d.MaNguyenVatLieuNavigation).WithMany(p => p.TonKhos)
                .HasForeignKey(d => d.MaNguyenVatLieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TonKho_NV");
        });

        modelBuilder.Entity<YeuCauNguyenVatLieu>(entity =>
        {
            entity.HasKey(e => e.MaYeuCauNvl).HasName("PK__YeuCauNg__BBF67A9390972796");

            entity.ToTable("YeuCauNguyenVatLieu");

            entity.HasIndex(e => e.MaKeHoach, "IX_YeuCauNguyenVatLieu_MaKeHoach");

            entity.HasIndex(e => e.MaNguyenVatLieu, "IX_YeuCauNguyenVatLieu_MaNguyenVqatLieu");

            entity.Property(e => e.MaYeuCauNvl)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("MaYeuCauNVL");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoLuongCanThiet).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThaiDonHang).HasMaxLength(50);

            entity.HasOne(d => d.MaKeHoachNavigation).WithMany(p => p.YeuCauNguyenVatLieus)
                .HasForeignKey(d => d.MaKeHoach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__YeuCauNgu__MaKeH__2BFE89A6");

            entity.HasOne(d => d.MaNguyenVatLieuNavigation).WithMany(p => p.YeuCauNguyenVatLieus)
                .HasForeignKey(d => d.MaNguyenVatLieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__YeuCauNgu__MaNgu__2CF2ADDF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
