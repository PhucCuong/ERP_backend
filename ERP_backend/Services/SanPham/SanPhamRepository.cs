using Microsoft.EntityFrameworkCore;

namespace ERP_backend.Services.SanPham;

using System.Collections.Generic;
using ERP_backend.Models;

public class SanPhamRepository : ISanPhamRepository
{
    private readonly QlySanXuatErpContext _dbcontext;

    public SanPhamRepository(QlySanXuatErpContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public SanPham Add(SanPham sanPham)
    {
        _dbcontext.SanPhams.Add(sanPham);
        _dbcontext.SaveChanges();
        return sanPham;
    }

    public List<SanPham> getAll()
    {
        return _dbcontext.SanPhams.ToList();
    }

    public SanPham GetById(int id)
    {
        var sanpham = _dbcontext.SanPhams.SingleOrDefault(sp => sp.MaSanPham == id);

        return sanpham;
    }

    public SanPham Update(SanPham sanPham)
    {
        var _sanpham = _dbcontext.SanPhams.SingleOrDefault(sp => sp.MaSanPham == sanPham.MaSanPham);
        _sanpham.TenSanPham = sanPham.TenSanPham;
        _sanpham.MaVach = sanPham.MaVach;
        _sanpham.DonViTinh = sanPham.DonViTinh;
        _sanpham.NhomSanPham = sanPham.NhomSanPham;
        _sanpham.GiaBan = sanPham.GiaBan;
        _sanpham.MoTa = sanPham.MoTa;
        _sanpham.Img = sanPham.Img;
        _sanpham.ChiPhiSanXuat = sanPham.ChiPhiSanXuat;

        _dbcontext.SaveChanges();

        return _sanpham;
    }
}

