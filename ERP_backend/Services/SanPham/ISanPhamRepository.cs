
using ERP_backend.Models;

public interface ISanPhamRepository
{
    public List<SanPham> getAll();
    public SanPham GetById(int id);
    public SanPham Add(SanPham sanPham);

    public SanPham Update(SanPham sanPham);
}

