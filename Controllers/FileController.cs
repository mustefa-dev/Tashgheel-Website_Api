using Microsoft.AspNetCore.Mvc;
using Tashgheel_Api.Controllers;
using Tashgheel_Api.Services;

namespace TicketSystem.Controllers;

public class FileController: BaseController{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService) {
        _fileService = fileService;
    }

    
    [HttpPost("multi")]
    public async Task<IActionResult> UploadVideo([FromForm] IFormFile[] files) => Ok(await _fileService.Upload(files));
    [HttpPost("uploadVideo")]
    public async Task<IActionResult> UploadChunks(IFormFile file) => Ok(await _fileService.UploadVideo(file));



}