using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers
{
    public class TextWrapper
    {
        public string Text { get; set; }
    }

    [Route("api/image")]
    public class ImageController : BaseApiController
    {
        private const string _imagesFolderPath = "../Images";

        [HttpPost]
        public ActionResult<string> UploadImage([FromForm] IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";

                    string filePath = Path.Combine(_imagesFolderPath, uniqueFileName);

                    EnsureDirectoryExists();

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var textWrapper = new TextWrapper()
                    {
                        Text = uniqueFileName
                    };
                    Result<TextWrapper> resultWrapper = Result.Ok(textWrapper);

                    return CreateResponse(resultWrapper);
                }
                else
                {
                    return BadRequest("No file or empty file provided.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpGet("{imageURL}")]
        public IActionResult GetImage(string imageURL)
        {
            string imagePath = Path.Combine(_imagesFolderPath, imageURL);

            if (!System.IO.File.Exists(imagePath))
            {
                imagePath = Path.Combine(_imagesFolderPath, "noImage.jpg");
            }
            string contentType;
            switch (Path.GetExtension(imagePath).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".bmp":
                    contentType = "image/bmp";
                    break;
                default:
                    contentType = "application/octet-stream";
                    break;
            }

            var stream = System.IO.File.OpenRead(imagePath);
            return File(stream, contentType);
        }

        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(_imagesFolderPath))
            {
                Directory.CreateDirectory(_imagesFolderPath);
            }
        }

    }
}
