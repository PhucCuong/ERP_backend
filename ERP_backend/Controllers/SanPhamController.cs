using ERP_backend.Models;
using ERP_backend.Services.SanPham;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepository _sanphamrepository;

        public SanPhamController(ISanPhamRepository sanphamrepository) 
        {
            _sanphamrepository = sanphamrepository;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                var list_sanpham = _sanphamrepository.getAll();
                return Ok(list_sanpham);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var sanpham = _sanphamrepository.GetById(id);
                return Ok(sanpham);
            }
            catch (Exception ex) 
            { 
                return NotFound();
            }
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult Add([FromForm] SanPham sanPham)
        {

            try
            {
                var imageFile = Request.Form.Files.FirstOrDefault();  // Lấy ảnh từ request
                if (imageFile != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        imageFile.CopyTo(ms);
                        sanPham.Img = ms.ToArray();  // Chuyển file ảnh thành byte[] rồi gán vào Img
                    }
                }

                var result = _sanphamrepository.Add(sanPham);
                if (result == null)
                    return BadRequest("Không thể thêm sản phẩm.");

                return Ok(new { message = "Thêm sản phẩm thành công!", data = result });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public IActionResult Update([FromForm] SanPham sanPham)
        {
            try
            {
                var existingSanPham = _sanphamrepository.GetById(sanPham.MaSanPham);
                if (existingSanPham == null)
                {
                    return NotFound("Sản phẩm không tồn tại!");
                }

                // Kiểm tra nếu có file ảnh mới thì cập nhật
                var imageFile = Request.Form.Files.FirstOrDefault();
                if (imageFile != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        imageFile.CopyTo(ms);
                        sanPham.Img = ms.ToArray();
                    }
                }
                else
                {
                    // Nếu không có ảnh mới, giữ nguyên ảnh cũ
                    sanPham.Img = existingSanPham.Img;
                }

                var updatedSanPham = _sanphamrepository.Update(sanPham);
                return Ok(new { message = "Cập nhật sản phẩm thành công!", data = updatedSanPham });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Lỗi cập nhật sản phẩm!", error = ex.Message });
            }
        }

    }
}
