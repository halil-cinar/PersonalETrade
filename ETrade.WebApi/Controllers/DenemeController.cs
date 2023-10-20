using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace ETrade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {

        [HttpPost]
        [Route("add")]
        public IActionResult Add2( Microsoft.AspNetCore.Http.IFormFile file)
        {
            Debug.WriteLine(file.FileName);
            return Ok(file.FileName);
        }

        [HttpGet]
        [Route("download")]
        public IActionResult Get()
        {
            string path = "C:\\Users\\HalilCINAR\\Pictures\\img2.jpg";


    if (System.IO.File.Exists(path))
            {
                return File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));
            }
            return NotFound();
        }

        [HttpPost("UploadFile")]
        public async Task<string> UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];

                string fName = file.FileName;
                
                return $"{file.FileName} successfully uploaded to the Server";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile2(List<IFormFile> files)
        {
            try
            {
                if (files == null || files.Count == 0)
                {
                    return BadRequest("Dosya seçilmedi veya boş dosya yüklenemez.");
                }
                List<string> list = new List<string>();
                foreach (var file in files)
                {
                    list.Add(file.FileName);
                }

                

                return Ok($"Dosya yükleme başarılı. Dosyanın adı: {string.Join(",",list)}");
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "Dosya yükleme sırasında bir hata oluştu."+ex.Message);
            }
        }
    }
}
